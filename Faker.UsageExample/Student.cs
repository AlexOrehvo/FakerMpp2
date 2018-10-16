using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsageExample
{
	class Student
	{

		public int size = 10;

		//private string _name;
		public int age { get; set; }
		public double height { get; set; }
		public Lesson lesson { get; set; }
		public List<Lesson> lessons { get; set; }
		public DateTime dateTime { get; set; }

		public Student(int age, Lesson lesson, List<Lesson> lessons, DateTime dateTime)
		{
			this.age = age;
			this.lesson = lesson;
			this.lessons = lessons;
			this.dateTime = dateTime;
		}

		public override string ToString()
		{
			return "Date: " + dateTime.ToLocalTime();
		}
	}
}
