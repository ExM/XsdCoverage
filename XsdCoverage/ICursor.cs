using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public interface ICursor<T> where T: XObject
	{
		ICursor<XElement> Parent { get; }
		T Target { get; }
		bool Build { get; set; }
	}
}
