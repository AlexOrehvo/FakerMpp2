using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerTest
{
	class TestEntity2
	{
		public int age { get; set; }
		public double height { get; set; }
		public float experience;

		public TestEntity2(int age, double height)
		{
			this.age = age;
			this.height = height;
		}
	}
}
