using System;
using System.Xml.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using PurchaseOrder;
using XsdCoverage;

namespace XsdCoverage.Test
{
	[TestFixture]
	public class ReadFields
	{
		[Test]
		public void OrderDate()
		{
			XDocument doc = XDocument.Parse(File.ReadAllText("XmlExamples/po.xml"));
			
			PurchaseOrderType po = new PurchaseOrderType(doc.Root);
			XAttribute at = po.OrderDate.GetTarget();
			
			Assert.AreEqual("1999-10-20", at.Value);
		}
		
		[Test]
		public void Comment()
		{
			XDocument doc = XDocument.Parse(File.ReadAllText("XmlExamples/po.xml"));
			
			PurchaseOrderType po = new PurchaseOrderType(doc.Root);
			XElement el = po.Comment.GetTarget();
			Assert.AreEqual("Hurry, my lawn is going wild!", el.Value);
		}
	}
}
