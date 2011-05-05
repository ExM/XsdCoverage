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
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<XElement>.Parent { get { return _parent; } }
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }
		
		public Items(ICursor<XElement> p, XElement t)
		{
			_parent = p;
			_target = t;
		}
		
	}
}

