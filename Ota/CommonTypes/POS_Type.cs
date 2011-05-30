using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XsdCoverage;

namespace Ota.CommonTypes
{
	/// <summary>
	/// Point of Sale (POS) identifies the party or connection channel making the request.
	/// </summary>
	[NameSpace(OtaXsd.NameSpace)]
	public class POS_Type : Cursor<XElement>
	{
		/// <summary>
		/// This holds the details about the requestor. It may be repeated to also accommodate the delivery systems.
		/// </summary>
		public SourceType Source
		{
			get
			{
				return this.Element<SourceType>("Source");
			}
		}
	}
}
