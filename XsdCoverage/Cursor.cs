using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public abstract class Cursor
	{
		protected Cursor<XElement> _parent = null;
		protected NotFoundResult _mode = NotFoundResult.Throw;
		
		public Cursor<XElement> GetParent()
		{
			return _parent;
		}
		
		public void SetParent(Cursor<XElement> p)
		{
			_parent = p;
		}
		
		public void SetReadMode(NotFoundResult m)
		{
			_mode = m;
		}
		
		public static CursorList<T> Elements<T>(this Cursor<XElement> cursor, string localName) where T : Cursor<XElement>
		{
			throw new NotImplementedException();
			//return new CursorList<T>(cursor, CursorAttributes<T, XElement>.NameSpace + localName);
		}

		public static T Element<T>(this Cursor<XElement> cursor, string localName) where T : Cursor<XElement>
		{
			throw new NotImplementedException();
			/*
			XElement resultTarget = cursor.Target.Element(CursorAttributes<T, XElement>.NameSpace + localName);
			if (resultTarget == null)
			{
				if (!cursor.Build)
				{

					throw new FormatException(string.Format("element `{0}' not found in {1}",
						CursorAttributes<T, XElement>.NameSpace + localName, cursor.Target.GetAbsoluteXPath()));
				}
				resultTarget = new XElement(CursorAttributes<T, XElement>.NameSpace + localName);
				cursor.Target.Add(resultTarget);
			}
			T result = CursorCreater<T, XElement>.Create(cursor, resultTarget);
			result.Build = cursor.Build;
			return result;
			*/
		}

		public static T Attribute<T>(this Cursor<XElement> cursor, string localName) where T : Cursor<XAttribute>
		{
			throw new NotImplementedException();
			/*
			XAttribute resultTarget = cursor.Target.Attribute(localName); //HACK: почему атрибуты не включены в пространство имен?
			if (resultTarget == null)
			{
				if (!cursor.Build)
					throw new FormatException(string.Format("attribute `{0}' not found", localName));
				resultTarget = new XAttribute(localName, string.Empty);
				cursor.Target.Add(resultTarget);
			}
			T result = CursorCreater<T, XAttribute>.Create(cursor, resultTarget);
			result.Build = cursor.Build;
			return result;
			*/
		}
}
