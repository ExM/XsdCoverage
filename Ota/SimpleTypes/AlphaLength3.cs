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
	public class AlphaLength3 : Cursor<XAttribute>
	{


		//    <xs:restriction base="xs:string">
		//      <xs:pattern value="[a-zA-Z]{3}"/>
		//    </xs:restriction>
	}
}
