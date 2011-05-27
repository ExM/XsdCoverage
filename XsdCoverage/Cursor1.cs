using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public abstract class Cursor<T>: Cursor where T: XObject
	{
		protected T _target = null;
		
		public T GetTarget()
		{
			return _target;
		}
		
		public void SetTarget(T t)
		{
			_target = t;
		}
	}
}
