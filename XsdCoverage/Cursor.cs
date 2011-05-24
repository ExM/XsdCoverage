using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public abstract class Cursor<T> where T: XObject
	{
		public Cursor<XElement> Parent { get; set; }
		public T Target { get; set; }
		public bool Build { get; set; }
		
		
	}
}
