using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerTest
{
	class TestEntity
	{
		public int age { get; set; }
		public double height { get; set; }
		public TestEntity2 testEntity2 { get; set; }
		public DateTime birthday { get; set; }
		public Boolean isStudent { get; set; }

		public TestEntity(int age, double height, TestEntity2 testEntity2, DateTime birthday, Boolean isStudent)
		{
			this.age = age;
			this.height = height;
			this.testEntity2 = testEntity2;
			this.birthday = birthday;
			this.isStudent = isStudent;
		}
	}
}
