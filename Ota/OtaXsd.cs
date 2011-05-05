using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Xml.Linq;

namespace Ota
{
	public static class OtaXsd
	{
		public const string NameSpace = "http://www.opentravel.org/OTA/2003/05";

		private static ResourceManager _resMan = new ResourceManager("Ota.XsdShemas", typeof(OtaXsd).Assembly);

		public static string GetXsdText(string name)
		{
			return _resMan.GetString(name);
		}

		/// <summary>
		/// This message sends a request for a reservation to another system.There is no requirement to determine availability prior to sending a reservation request. Travel agencies, or individual guests may send a request to book a reservation from an internet site if all the information required for booking is known. The OTA_HotelResRQ message can initiate the first message in the sequence of booking a reservation.
		/// </summary>
		//public static readonly HotelResRQ HotelResRQ = new HotelResRQ();
	}
}
