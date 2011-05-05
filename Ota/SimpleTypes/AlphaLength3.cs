using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XsdCoverage;

namespace Ota.SimpleTypes
{
	/// <summary>
	/// Used for an Alpha String, length exactly 3.
	/// </summary>
	[NameSpace(OtaXsd.NameSpace)]
	public class AlphaLength3 : ICursor<XAttribute>
	{
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<XAttribute>.Parent { get { return _parent; } }
		private readonly XAttribute _target;
		XAttribute ICursor<XAttribute>.Target { get{ return _target; } }
		bool ICursor<XAttribute>.Build { get; set; }

		public AlphaLength3(ICursor<XElement> p, XAttribute t)
		{
			_parent = p;
			_target = t;
		}

		//    <xs:restriction base="xs:string">
		//      <xs:pattern value="[a-zA-Z]{3}"/>
		//    </xs:restriction>
	}
}
