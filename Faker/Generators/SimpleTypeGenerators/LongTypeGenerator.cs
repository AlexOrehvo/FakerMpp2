using FakerNameSpace.Generators.SimpleTypeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	class LongTypeGenerator : ISimpleTypeGenerator
	{
		Random random;

		public Type GeneratedType { get; }

		public object Generate()
		{
			return random.Next();
		}

		public LongTypeGenerator()
		{
			GeneratedType = typeof(long);
			random = new Random();
		}
	}
}
