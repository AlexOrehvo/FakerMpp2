using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerNameSpace.Generators;

namespace DateGeneratorPlugin
{
	public class DateGenerator : IGenerator
	{
		public object Generate()
		{
			DateTime dateTime = new DateTime();
			dateTime = DateTime.Today;
			Console.WriteLine(dateTime.ToLocalTime());
			return dateTime;
		}
	}
}
