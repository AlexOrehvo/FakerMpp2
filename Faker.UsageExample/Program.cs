using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsageExample;
using FakerNameSpace;

namespace UsageExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Faker faker = new Faker();
			Student student = faker.Create<Student>();
			Console.WriteLine(student.ToString());
		}
	}
}
