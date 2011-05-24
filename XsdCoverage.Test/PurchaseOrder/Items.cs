using System;
using XsdCoverage;
using System.Xml.Linq;
using PurchaseOrders;
using System.Collections.Generic;
using W3C.XMLSchema;

namespace PurchaseOrder
{
	[NameSpace(PurchaseOrderXsd.NameSpace)]
	public class Items: ICursor<XElement>
	{
		ICursor<XElement> ICursor<XElement>.Parent { get; set; }
		XElement ICursor<XElement>.Target { get; set; }
		bool ICursor<XElement>.Build { get; set; }
		
		public Items(ICursor<XElement> p, XElement t)
		{
			ICursor<XElement>.Parent = p;
			ICursor<XElement>.Target = t;
		}
		
	}
}

