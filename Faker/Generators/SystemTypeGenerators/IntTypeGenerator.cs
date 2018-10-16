using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.SystemTypeGenerators
{
	class IntTypeGenerator : IGenerator
	{
		Random random;

		public object Generate()
		{
			return random.Next();
		}

		public IntTypeGenerator()
		{
			random = new Random();
		}
	}
}
