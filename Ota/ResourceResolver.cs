using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace Ota
{
	public class ResourceResolver : XmlResolver
	{
		public override ICredentials Credentials
		{
			set
			{
				throw new NotImplementedException();
			}
		}
		
		public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
		{
			//Console.WriteLine("absoluteUri:{0}, role:{1}, ofObjectToReturn:{2}", absoluteUri, role, ofObjectToReturn);
			try
			{
				string name = Path.GetFileNameWithoutExtension(absoluteUri.LocalPath);
				Console.WriteLine("Load: {0}", name);
				return new StringReader(OtaXsd.GetXsdText(name));
			}
			catch (SystemException err)
			{
				Console.WriteLine("Exception for {0}. {1}", absoluteUri, err);
				return null;
			}
		}
	}
}
