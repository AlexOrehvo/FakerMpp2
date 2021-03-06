﻿using FakerNameSpace.Generators.SimpleTypeGenerators;
using System;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	class DateTypeGenerator : ISimpleTypeGenerator
	{
		private Random random;

		public Type GeneratedType { get; }

		public object Generate()
		{
			int year = random.Next(1990, 2018);
			int month = random.Next(1, 12);
			int day = random.Next(1, 27);
			int second = random.Next(1, 60);
			int minute = random.Next(1, 60);
			int hour = random.Next(1, 24);
			DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
			return dateTime;
		}

		public DateTypeGenerator()
		{
			GeneratedType = typeof(DateTime);
			random = new Random();
		}
	}
}
