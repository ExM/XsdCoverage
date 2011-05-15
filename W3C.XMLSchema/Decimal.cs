using System;
using XsdCoverage;
using System.Xml.Linq;
using System.Collections.Generic;

namespace W3C.XMLSchema
{
	[NameSpace(XMLSchemaXsd.NameSpace)]
	public class Decimal<T>: ICursor<T>
		where T: XObject
	{
		private readonly T _target;
		T ICursor<T>.Target { get { return _target; } }
		bool ICursor<T>.Build { get; set; }
		
		public Decimal(T t)
		{
			_target = t;
		}
		
	}
}

