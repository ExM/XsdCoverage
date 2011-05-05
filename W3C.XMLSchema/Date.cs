using System;
using XsdCoverage;
using System.Xml.Linq;
using System.Collections.Generic;

namespace W3C.XMLSchema
{
	/// <summary>
	/// http://www.w3.org/TR/xmlschema-2/#date
	/// </summary>
	[NameSpace(XMLSchemaXsd.NameSpace)]
	public class Date<T>: ICursor<T>
		where T: XObject
	{
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<T>.Parent { get { return _parent; } }
		private readonly T _target;
		T ICursor<T>.Target { get { return _target; } }
		bool ICursor<T>.Build { get; set; }
		
		public Date(ICursor<XElement> p, T t)
		{
			_parent = p;
			_target = t;
		}
		
	}
}

