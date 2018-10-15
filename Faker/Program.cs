using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
	class Program
	{
		static void Main(string[] args)
		{
			IFaker faker = new Faker();
			Student student = faker.Create<Student>();
			Console.WriteLine(student.ToString());

			/*Student student = new Student(10, 1.2, new Lesson(12), new List<Lesson>());
			Type type = typeof(List<>);
			Console.WriteLine(type);
			Console.WriteLine(student.lessons.GetType().GetElementType());*/
		}
	}
}
