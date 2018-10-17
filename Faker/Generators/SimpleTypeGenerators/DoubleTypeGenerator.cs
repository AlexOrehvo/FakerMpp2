using FakerNameSpace.Generators.SimpleTypeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	class DoubleTypeGenerator: ISimpleTypeGenerator
	{
		Random random;

		public Type GeneratedType { get; }

		public object Generate()
		{
			return random.NextDouble();
		}

		public DoubleTypeGenerator()
		{
			GeneratedType = typeof(double);
			random = new Random();
		}
	}
}
