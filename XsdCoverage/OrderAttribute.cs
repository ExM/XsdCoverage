using System;
namespace XsdCoverage
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
	public class OrderAttribute: Attribute
	{
		public readonly string[] Names;
		
		public OrderAttribute(params string[] names)
		{
			if(names == null || names.Length < 2)
				throw new ArgumentOutOfRangeException("names.Length must be greater than or equal to 2");
			Names = names;
		}
	}
}

