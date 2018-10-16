using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.SystemTypeGenerators
{
	class LongTypeGenerator : IGenerator
	{
		Random random;

		public object Generate()
		{
			return random.Next();
		}

		public LongTypeGenerator()
		{
			random = new Random();
		}
	}
}
