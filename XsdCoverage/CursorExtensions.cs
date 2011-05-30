using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XsdCoverage
{
	public static class CursorExtensions
	{
		public static CursorList<T> Elements<T>(this Cursor<XElement> cursor, string localName) where T : Cursor<XElement>
		{
			CursorList<T> result = new CursorList<T>();
			result.SetParent(cursor);
			result.SetName(CursorAttributes<T, XElement>.NameSpace + localName);
			result.SetReadMode(cursor.GetReadMode());
			return result;
		}
		
		public static T Element<T>(this Cursor<XElement> cursor, string localName)
			where T : Cursor<XElement>, new()
		{
			XName name = CursorAttributes<T, XElement>.NameSpace + localName;
			NotFoundResult mode = cursor.GetReadMode();
			XElement resultTarget = cursor.GetTarget().Element(name);
			if (resultTarget == null)
			{
				if (mode == NotFoundResult.Throw)
				{
					throw new FormatException(string.Format("element `{0}' not found in {1}",
						name, cursor.GetTarget().GetAbsoluteXPath()));
				}
				else if(mode == NotFoundResult.Default)
				{
					resultTarget = new XElement(CursorAttributes<T, XElement>.NameSpace + localName);
					cursor.GetTarget().Add(resultTarget); //TODO: учесть порядок
				}
			}
			T result = new T();
			result.SetParent(cursor);
			result.SetTarget(resultTarget);
			result.SetName(name);
			result.SetReadMode(mode);
			return result;
		}
		
		public static T Attribute<T>(this Cursor<XElement> cursor, string localName)
			where T : Cursor<XAttribute>, new()
		{
			NotFoundResult mode = cursor.GetReadMode();
			XAttribute resultTarget = cursor.GetTarget().Attribute(localName); //HACK: почему атрибуты не включены в пространство имен?
			if (resultTarget == null)
			{
				if (mode == NotFoundResult.Throw)
				{
					throw new FormatException(string.Format("attribute `{0}' not found in {1}",
						localName, cursor.GetTarget().GetAbsoluteXPath()));
				}
				else if(mode == NotFoundResult.Default)
				{
					resultTarget = new XAttribute(localName, string.Empty);
					cursor.GetTarget().Add(resultTarget);
				}
			}
			T result = new T();
			result.SetParent(cursor);
			result.SetTarget(resultTarget);
			result.SetName(CursorAttributes<T, XAttribute>.NameSpace + localName);
			result.SetReadMode(mode);
			return result;
		}
		
		
		
		public static string GetAbsoluteXPath(this XAttribute attr)
		{
			if (attr == null)
				throw new ArgumentNullException("element");

			XElement parent = attr.Parent;
			if (parent == null)
				return "/" + attr.Name.ToString();

			return parent.GetAbsoluteXPath() + "/" + attr.Name.ToString();
		}

		/// <summary>
		/// Get the absolute XPath to a given XElement
		/// (e.g. "/people/person[6]/name[1]/last[1]").
		/// </summary>
		public static string GetAbsoluteXPath(this XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			Func<XElement, string> relativeXPath = e =>
			{
				int index = e.IndexPosition();
				if (index == -1)
					return "/" + e.Name.LocalName;
				else
					return string.Format("/{0}[{1}]", e.Name.LocalName, index);
			};

			var ancestors = from e in element.Ancestors()
							select relativeXPath(e);

			return string.Concat(ancestors.Reverse().ToArray()) + relativeXPath(element);
		}

		/// <summary>
		/// Get the index of the given XElement relative to its
		/// siblings with identical names. If the given element is
		/// the root, -1 is returned.
		/// </summary>
		/// <param name="element">
		/// The element to get the index of.
		/// </param>
		public static int IndexPosition(this XElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			if (element.Parent == null)
				return -1;

			int i = 1; // Indexes for nodes start at 1, not 0

			foreach (var sibling in element.Parent.Elements(element.Name))
			{
				if (sibling == element)
					return i;
				i++;
			}

			throw new InvalidOperationException("element has been removed from its parent.");
		}
	}
}
