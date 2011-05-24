using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace XsdCoverage
{
	public static class CursorCreater<TCursor, TTarget>
		where TCursor: Cursor<TTarget>
		where TTarget: XObject
	{
		private static Func<Cursor<XElement>, TTarget, TCursor> _creater;

		static CursorCreater()
		{
			ConstructorInfo ci = typeof(TCursor).GetConstructor(new Type[] { typeof(Cursor<XElement>), typeof(TTarget) });
			if(ci == null)
				throw new InvalidOperationException(string.Format("the type {0} not contain ctor({1}, {2})",
					typeof(TCursor).FullName, typeof(Cursor<XElement>).FullName, typeof(TTarget).FullName));
			var parentParam = Expression.Parameter(typeof(Cursor<XElement>));
			var targetParam = Expression.Parameter(typeof(TTarget));
			var body = Expression.New(ci, parentParam, targetParam);

			var expression = Expression.Lambda(body, parentParam, targetParam);
			_creater = (Func<Cursor<XElement>, TTarget, TCursor>)expression.Compile();
		}

		public static TCursor Create(Cursor<XElement> parent, TTarget target)
		{
			return _creater(parent, target);
		}
	}
}
