using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XsdCoverage;

namespace Ota.CommonTypes
{
	/// <summary>
	/// Point of Sale (POS) identifies the party or connection channel making the request.
	/// </summary>
	[NameSpace(OtaXsd.NameSpace)]
	public class POS_Type : ICursor<XElement>
	{
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<XElement>.Parent { get { return _parent; } }
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }

		/// <summary>
		/// This holds the details about the requestor. It may be repeated to also accommodate the delivery systems.
		/// </summary>
		public SourceType Source
		{
			get
			{
				return this.Element<SourceType>("Source");
			}
		}

		public POS_Type(ICursor<XElement> p, XElement t)
		{
			_parent = p;
			_target = t;
		}
	}
}
