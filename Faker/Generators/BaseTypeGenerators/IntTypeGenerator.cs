using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.BaseTypeGenerators
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
