using System;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	class BoolTypeGenerator : ISimpleTypeGenerator
	{
		public Type GeneratedType { get; }

		public object Generate()
		{
			return true;
		}

		public BoolTypeGenerator()
		{
			GeneratedType = typeof(Boolean);
		}
	}
}
