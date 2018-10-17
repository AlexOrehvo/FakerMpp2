using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateGeneratorPlugin
{
	interface ISimplerGenerator
	{
		object Generate();

		Type GeneratedType { get; }
	}
}
