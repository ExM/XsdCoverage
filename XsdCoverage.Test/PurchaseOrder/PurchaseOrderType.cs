using System;
using XsdCoverage;
using System.Xml.Linq;
using PurchaseOrders;
using System.Collections.Generic;
using W3C.XMLSchema;

namespace PurchaseOrder
{
	[Order("shipTo", "billTo", "comment", "items")]
	[NameSpace(PurchaseOrderXsd.NameSpace)]
	public class PurchaseOrderType: ICursor<XElement>
	{
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<XElement>.Parent { get { return _parent; } }
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }
		
		public PurchaseOrderType(ICursor<XElement> p, XElement t)
		{
			_parent = p;
			_target = t;
		}
		
		public USAddress ShipTo
		{
			get
			{
				return this.Element<USAddress>("shipTo");
			}
		}
		
		public USAddress BillTo
		{
			get
			{
				return this.Element<USAddress>("billTo");
			}
		}
		
		public Comment Comment
		{
			get
			{
				return this.Element<Comment>("comment");
			}
		}
		
		public Items Items
		{
			get
			{
				return this.Element<Items>("items");
			}
		}
		
		public Date<XAttribute> OrderDate
		{
			get
			{
				// <xsd:attribute name="orderDate" type="xsd:date"/>
				return this.Attribute<Date<XAttribute>>("orderDate");
			}
		}
	}
}

