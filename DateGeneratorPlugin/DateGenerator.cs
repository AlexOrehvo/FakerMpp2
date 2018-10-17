using System;
using FakerNameSpace.Generators.SimpleTypeGenerators;

namespace DateGeneratorPlugin
{
	public class DateGenerator : ISimpleTypeGenerator
	{
		public Type GeneratedType { get; }

		public object Generate()
		{
			DateTime dateTime = new DateTime();
			dateTime = DateTime.Today;
			return dateTime;
		}

		public DateGenerator()
		{
			GeneratedType = typeof(DateTime);
		}
	}
}
