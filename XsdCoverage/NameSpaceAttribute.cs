using System;
namespace XsdCoverage
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
	public class NameSpaceAttribute: Attribute
	{
		public readonly string NameSpace;
		
		public NameSpaceAttribute(string nameSpace)
		{
			if(string.IsNullOrWhiteSpace(nameSpace))
				throw new ArgumentNullException("nameSpace");
			NameSpace = nameSpace;
		}
	}
}

