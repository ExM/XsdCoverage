using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public abstract class Cursor<T>: CursorBase
	{
		protected T _target = default(T);
		
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
