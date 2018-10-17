using System;
using FakerNameSpace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakerTest
{
	[TestClass]
	public class FakerTest
	{
		private Faker faker = new Faker();
		private TestEntity entity = null;
		
		[TestMethod]
		public void TestGenerateEntity()
		{
			Assert.IsNotNull(entity);
		}

		[TestMethod]
		public void TestGenerateBoolean()
		{
			Assert.IsTrue(entity.isStudent);
		}

		[TestMethod]
		public void TestGenerateInt()
		{
			Assert.AreNotEqual(0, entity.age);
		}

		[TestMethod]
		public void TestGenerateDouble()
		{
			Assert.AreNotEqual(0, entity.height);
		}

		[TestMethod]
		public void TestGenerateDateTime()
		{
			Assert.AreNotEqual(null, entity.birthday);
		}

		[TestMethod]
		public void TestGenerateInnerDto()
		{
			Assert.AreNotEqual(null, entity.testEntity2);
		}

		public FakerTest()
		{
			this.entity = faker.Create<TestEntity>();
		}
	}
}
