using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ota.SimpleTypes;
using System.Xml.Linq;
using XsdCoverage;

namespace Ota.CommonTypes
{
	/// <summary>
	/// Provides information on the source of a request.
	/// </summary>
	[NameSpace(OtaXsd.NameSpace)]
	public class SourceType : ICursor<XElement>
	{
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }

		/// <summary>
		/// The currency code in which the reservation will be ticketed.
		/// </summary>
		public AlphaLength3 ISOCurrency
		{
			get
			{
				return this.Attribute<AlphaLength3>("ISOCurrency");
			}
		}
		public SourceType(XElement t)
		{
			_target = t;
		}


	}
}
