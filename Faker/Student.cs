using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
	class Student
	{

		private int size = 10;

		//private string _name;
		public int age { get; set; }
		public double height { get; set; }
		public Lesson lesson { get; set; }
		
		public Student(int age, double height, Lesson lesson)
		{
			this.age = age;
			this.height = height;
			this.lesson = lesson;
		}

		public override string ToString()
		{
			return "size: " + size + " age: " + age + " height: " + height;
		}
	}

}
