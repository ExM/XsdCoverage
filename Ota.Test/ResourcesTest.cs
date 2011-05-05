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
using System.Resources;

namespace OtaTest
{
	[TestFixture]
	public class ResourcesTest
	{
		[TestCase("OTA_HotelResRS")]
		[TestCase("OTA_HotelResRQ")]
		public void Exist(string name)
		{
			string xsdText = OtaXsd.GetXsdText(name);
			Assert.IsNotNullOrEmpty(xsdText);
		}
	}
}
