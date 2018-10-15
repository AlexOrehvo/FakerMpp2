using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.BaseTypeGenerators
{
	class DoubleTypeGenerator: IGenerator
	{
		Random random;

		public object Generate()
		{
			return random.NextDouble();
		}

		public DoubleTypeGenerator()
		{
			random = new Random();
		}
	}
}
