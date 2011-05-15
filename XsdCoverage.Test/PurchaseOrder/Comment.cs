using System;
using XsdCoverage;
using System.Xml.Linq;
using PurchaseOrders;
using System.Collections.Generic;
using W3C.XMLSchema;

namespace PurchaseOrder
{
	[NameSpace(PurchaseOrderXsd.NameSpace)]
	public class Comment: String<XElement>
	{
		public Comment(XElement t):base(t)
		{
		}
	}
}

