using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.SystemTypeGenerators
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
