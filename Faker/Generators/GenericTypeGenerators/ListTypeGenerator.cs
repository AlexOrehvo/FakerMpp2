using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.ListTypeGenerators
{
	class ListTypeGenerator : IGenericTypeGenerator
	{
		Random random;

		public Type GeneratedType { get; }

		public object Generate(string fullName, ref int length)
		{
			length = random.Next(2, 10);
			return (IList)Activator.CreateInstance(Type.GetType(fullName));
		}

		public ListTypeGenerator() {
			GeneratedType = typeof(List<>);
			random = new Random();
		}

	}
}
