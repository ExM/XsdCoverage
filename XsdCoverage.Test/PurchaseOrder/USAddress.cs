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
	public class USAddress: Cursor<XElement>
	{
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

