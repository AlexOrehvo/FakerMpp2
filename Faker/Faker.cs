using Faker.Generators.BaseTypeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
	class Faker : IFaker
	{
		private Dictionary<Type, IBaseTypeGenerator> baseTypeGenerator;

		public Faker()
		{
			baseTypeGenerator = new Dictionary<Type, IBaseTypeGenerator>();

			baseTypeGenerator.Add(typeof(int), new IntTypeGenerator());
			baseTypeGenerator.Add(typeof(double), new DoubleTypeGenerator());
			baseTypeGenerator.Add(typeof(long), new LongTypeGenerator());
		}

		public T Create<T>()
		{
			//T obj = (T)Activator.CreateInstance(typeof(T));
			T obj = (T)Create(typeof(T));
			return obj;
		}

		private object Create(Type type)
		{
			return CreateByConstructor(type, type.GetConstructors()[0]);
		}

		private object CreateByConstructor(Type type, ConstructorInfo constructor)
		{
			var inputParametes = new List<object>();
			foreach (ParameterInfo parameter in constructor.GetParameters())
			{
				inputParametes.Add(GenerateValue(parameter.ParameterType));
			}
			return constructor.Invoke(inputParametes.ToArray());
		}

		private object GenerateValue(Type type)
		{
			IBaseTypeGenerator generator;
			object obj;
			if (baseTypeGenerator.TryGetValue(type, out generator))
			{
				obj = generator.Generate();
				return obj;
			}
			else if(type.IsClass)
			{
				obj = Create(type);
				return obj;
			}
			return null;
		}

		/*private Object Create(Type type)
		{		
		}*/


		/*private void SetBaseTypes<T>(Type type, T obj)
		{
			IBaseTypeGenerator generator;
			foreach (PropertyInfo property in type.GetProperties())
			{
				if (baseTypeGenerator.TryGetValue(property.PropertyType, out generator))
				{
					property.SetValue(obj, generator.Generate());
				}
			}
		}*/
	}
}
