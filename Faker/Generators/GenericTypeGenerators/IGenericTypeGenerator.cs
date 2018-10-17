using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerNameSpace.Generators.ListTypeGenerators
{
	public interface IGenericTypeGenerator : IGenerator
	{
		object Generate(string fullName, ref int length);
	}
}
