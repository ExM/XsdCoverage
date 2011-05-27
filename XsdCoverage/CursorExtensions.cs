using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XsdCoverage
{
	public static class CursorExtensions
	{
		
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
