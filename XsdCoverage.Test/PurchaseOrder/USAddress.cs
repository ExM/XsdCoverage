using System;
using XsdCoverage;
using System.Xml.Linq;
using PurchaseOrders;
using System.Collections.Generic;
using W3C.XMLSchema;

namespace PurchaseOrder
{
	[Order("name", "street", "city", "state", "zip")]
	[NameSpace(PurchaseOrderXsd.NameSpace)]
	public class USAddress: ICursor<XElement>
	{
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<XElement>.Parent { get { return _parent; } }
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }
		
		public USAddress(ICursor<XElement> p, XElement t)
		{
			_parent = p;
			_target = t;
		}
		
		public String<XElement> Name
		{
			get
			{
				return this.Element<String<XElement>>("name");
			}
		}
		
		public String<XElement> Street
		{
			get
			{
				return this.Element<String<XElement>>("street");
			}
		}
		
		public String<XElement> City
		{
			get
			{
				return this.Element<String<XElement>>("city");
			}
		}
		
		public String<XElement> State
		{
			get
			{
				return this.Element<String<XElement>>("state");
			}
		}
		
		public Decimal<XElement> Zip
		{
			get
			{
				return this.Element<Decimal<XElement>>("zip");
			}
		}
	}
}

