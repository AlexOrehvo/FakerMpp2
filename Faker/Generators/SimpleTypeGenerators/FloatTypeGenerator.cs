using System;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	class FloatTypeGenerator : ISimpleTypeGenerator
	{
		public Type GeneratedType { get; }
		private Random random;

		public object Generate()
		{
			object obj = (float)random.NextDouble();
			return obj;
		}

		public FloatTypeGenerator()
		{
			GeneratedType = typeof(float);
			random = new Random();
		}
	}
}
