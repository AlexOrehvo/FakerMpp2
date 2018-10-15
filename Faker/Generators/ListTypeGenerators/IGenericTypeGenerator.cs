using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ListTypeGenerators
{
	interface IGenericTypeGenerator
	{
		object Generate(string fullName, ref int length);
	}
}
