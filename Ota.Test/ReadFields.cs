using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Xml.Linq;
using Ota;
using System.Xml.Schema;
using System.Xml;
using XsdCoverage;

namespace OtaTest
{
	[TestFixture]
	public class ReadFields
	{

		[Test]
		public void Validation()
		{
			XmlSchemaSet schemas = new XmlSchemaSet();
			schemas.XmlResolver = new ResourceResolver();
			schemas.Add(null, XmlReader.Create(new StringReader(OtaXsd.GetXsdText("OTA_HotelResRS"))));
			
			schemas.Compile();

			XDocument doc = XDocument.Parse(File.ReadAllText("OTA_HotelResRS.xml"));

			bool errors = false;
			doc.Validate(schemas, (sender, e) =>
			{
				Console.WriteLine(e.Message);
				errors = true;
			}, true);

			Assert.IsFalse(errors, "not validate");
		}

		[Test]
		public void Read()
		{
			
			XDocument doc = XDocument.Load("OTA_HotelResRQ.xml");
			Console.WriteLine(doc.ToString());

			HotelResRQ req = new HotelResRQ(null, doc.Root);

			Console.WriteLine("###");
			XElement hres = req.HotelReservations.GetTarget();
			Console.WriteLine(hres);

			Console.WriteLine("###");
			XElement pos = req.POS.GetTarget();
			Console.WriteLine(pos);

			Console.WriteLine("###");
			XAttribute cur = req.POS.Source.ISOCurrency.GetTarget();
			Console.WriteLine(cur.Value);

			Console.WriteLine("###");
			req.ToBuild();
			XElement uid = req.UniqueID[1].GetTarget();
			Console.WriteLine(uid);

			Console.WriteLine("###");
			//IEnumerable<XElement> sources = Ota.HotelResRQ.POS.Source.Elements(doc);
			//foreach(var s in sources)
			//	Console.WriteLine("> {0}", s);

			Console.WriteLine("###");
			//XAttribute cur1 = Ota.HotelResRQ.POS.Source[1].ISOCurrency.Attribute(doc, ReadMode.NotNull);
			//Console.WriteLine(cur1.Value);

			Console.WriteLine("###");
			//var curPos = Ota.HotelResRQ.POS;

			//XElement source = curPos.Source.Element(curPos, pos);

			//XElement source = pos.Element(curPos, curPos.Source);

			//Console.WriteLine(source);

		}
	}
}
