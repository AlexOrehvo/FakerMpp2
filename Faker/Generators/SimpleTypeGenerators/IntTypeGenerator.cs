using FakerNameSpace.Generators.SimpleTypeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	class IntTypeGenerator : ISimpleTypeGenerator
	{
		Random random;

		public Type GeneratedType { get; }

		public object Generate()
		{
			return random.Next();
		}

		public IntTypeGenerator()
		{
			GeneratedType = typeof(int);
			random = new Random();
		}
	}
}
