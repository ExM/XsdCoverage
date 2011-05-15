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
		where TCursor: ICursor<TTarget>
		where TTarget: XObject
	{
		private static Func<TTarget, TCursor> _creater;

		static CursorCreater()
		{
			ConstructorInfo ci = typeof(TCursor).GetConstructor(new Type[] {typeof(TTarget) });
			if(ci == null)
				throw new InvalidOperationException(string.Format("the type {0} not contain ctor({1})",
					typeof(TCursor).FullName, typeof(TTarget).FullName));
			var targetParam = Expression.Parameter(typeof(TTarget));
			var body = Expression.New(ci, targetParam);

			var expression = Expression.Lambda(body, targetParam);
			_creater = (Func<TTarget, TCursor>)expression.Compile();
		}

		public static TCursor Create(TTarget target)
		{
			return _creater(target);
		}
	}
}
