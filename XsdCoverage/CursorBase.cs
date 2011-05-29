using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public abstract class CursorBase
	{
		protected Cursor<XElement> _parent = null;
		protected NotFoundResult _mode = NotFoundResult.Throw;
		protected XName _name;
		
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
		
		public void SetName(XName name)
		{
			_name = name;
		}
	}
}
