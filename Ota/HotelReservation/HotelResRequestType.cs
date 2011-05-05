using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ota.HotelCommonTypes;
using Ota.CommonTypes;
using System.Xml.Linq;
using XsdCoverage;

namespace Ota.HotelReservation
{
	/// <summary>
	/// This is a request message for creating a reservation. It is used by HotelResRQ and HotelResNotifRQ to keep them synchronized.
	/// </summary>
	[NameSpace(OtaXsd.NameSpace)]
	[Order("HotelReservations", "UniqueID", "POS")]
	public class HotelResRequestType: ICursor<XElement>
	{
		private readonly ICursor<XElement> _parent;
		ICursor<XElement> ICursor<XElement>.Parent { get { return _parent; } }
		private readonly XElement _target;
		XElement ICursor<XElement>.Target { get{ return _target; } }
		bool ICursor<XElement>.Build { get; set; }

		/// <summary>
		/// A collection of hotel reservations.
		/// </summary>
		public HotelReservationsType HotelReservations
		{
			get
			{
				return this.Element<HotelReservationsType>("HotelReservations");
			}
		}
		/// <summary>
		/// ???
		/// </summary>
		public IList<UniqueID_Type> UniqueID
		{
			get
			{
				return this.Elements<UniqueID_Type>("UniqueID");
			}
			set
			{
				//this.Elements("UniqueID", value);
			}
		}
		/// <summary>
		/// The point-of-sale data, contained in the POS element, communicates the information that allows the receiving system to identify the trading partner that is sending the request or the response message.
		/// </summary>
		public POS_Type POS
		{
			get
			{
				return this.Element<POS_Type>("POS");
			}
		}

		internal HotelResRequestType(ICursor<XElement> p, XElement t)
		{
			_parent = p;
			_target = t;
			//POS = new POS_Type(this, "POS", new Occurs(0, 1));
			//HotelReservations = new HotelReservationsType(this, "HotelReservations", new Occurs(0, 1));
			//UniqueID = new UniqueID_Type(this, "UniqueID", new Occurs(0, 2));
		}
	}
}
