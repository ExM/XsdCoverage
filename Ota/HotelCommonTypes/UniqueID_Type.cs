using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XsdCoverage;

namespace Ota.HotelCommonTypes
{
	[NameSpace(OtaXsd.NameSpace)]
	public class UniqueID_Type : ICursor<XElement>
	{
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }

		public UniqueID_Type(XElement t)
		{
			_target = t;
		}
	}
}
