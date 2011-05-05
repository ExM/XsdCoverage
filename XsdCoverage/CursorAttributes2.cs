using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace XsdCoverage
{
	public static class CursorAttributes<TCursor, TTarget>
		where TCursor: ICursor<TTarget>
		where TTarget: XObject
	{
		public static readonly XNamespace NameSpace;
		public static readonly IList<string> Order;

		static CursorAttributes()
		{
			Type t = typeof(TCursor);
			NameSpaceAttribute nsattr =
				t.GetCustomAttributes(typeof(NameSpaceAttribute), false).FirstOrDefault() as NameSpaceAttribute;
			if(nsattr != null)
				NameSpace = XNamespace.Get(nsattr.NameSpace);
			else
				NameSpace = XNamespace.None;
			
			OrderAttribute oattr =
				t.GetCustomAttributes(typeof(OrderAttribute), false).FirstOrDefault() as OrderAttribute;
			if(oattr != null)
				Order = new List<string>(oattr.Names).AsReadOnly();
			else
				Order = null;
		}
	}
}
