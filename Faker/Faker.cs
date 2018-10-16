using FakerNameSpace.Generators;
using FakerNameSpace.Generators.SystemTypeGenerators;
using FakerNameSpace.Generators.ListTypeGenerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace FakerNameSpace
{
	public class Faker : IFaker
	{

		private Dictionary<Type, IGenerator> systemTypeGenerator;
		private Dictionary<Type, IGenericTypeGenerator> genericTypeGenerator;

		public Faker()
		{
			systemTypeGenerator = new Dictionary<Type, IGenerator>();
			genericTypeGenerator = new Dictionary<Type, IGenericTypeGenerator>();

			Assembly a = null;
			IGenerator pluginGenerator;

			try
			{

				a = Assembly.LoadFrom("Plugins/DateGeneratorPlugin.dll");
				Console.WriteLine("File is loaded!");
				foreach (Type type in a.GetTypes())
				{
					foreach (Type typeInterface in type.GetInterfaces())
					{
						if (typeInterface.Equals(typeof(IGenerator)))
						{
							pluginGenerator = (IGenerator)Activator.CreateInstance(type);
							systemTypeGenerator.Add(typeof(DateTime), pluginGenerator);
						}
					}
				}
			}
			catch (BadImageFormatException)
			{ }
			catch (FileNotFoundException)
			{
				Console.WriteLine("Can not load file!");
			}


			

			systemTypeGenerator.Add(typeof(int), new IntTypeGenerator());
			systemTypeGenerator.Add(typeof(double), new DoubleTypeGenerator());
			systemTypeGenerator.Add(typeof(long), new LongTypeGenerator());
			//systemTypeGenerator.Add(typeof(DateTime), new DateTypeGenerator());

			

			genericTypeGenerator.Add(typeof(List<>), new ListTypeGenerator());
		}

		public T Create<T>()
		{
			//T obj = (T)Activator.CreateInstance(typeof(T));
			T obj = (T)Create(typeof(T));
			return obj;
		}

		private object Create(Type type)
		{
			object obj = CreateByConstructor(type, type.GetConstructors()[0]);
			//SetFields(type, obj);
			//SetProperties(type, obj);
			return obj;
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

		private void SetFields(Type type, object obj)
		{
			foreach (FieldInfo field in type.GetFields())
			{
				field.SetValue(obj, GenerateValue(field.FieldType));
			}
		}

		private void SetProperties(Type type, object obj)
		{
			foreach (PropertyInfo property in type.GetProperties())
			{
				property.SetValue(obj, GenerateValue(property.PropertyType));
			}
		}

		private object GenerateValue(Type type)
		{
			object obj;
			if (systemTypeGenerator.TryGetValue(type, out IGenerator generator))
			{
				obj = generator.Generate();
				return obj;
			}
			else if (type.IsGenericType && genericTypeGenerator.TryGetValue(type.GetGenericTypeDefinition(), out IGenericTypeGenerator genericGenerator))
			{
				int listLength = 0;
				IList list = (IList)genericGenerator.Generate(type.FullName, ref listLength);
				for (int i = 0; i < listLength; i++)
				{
					list.Add(Create(type.GenericTypeArguments[0]));
				}
				obj = list;
				return obj;
			}
			
			else if (type.IsClass)
			{
				obj = Create(type);
				return obj;
			}/*
			else if (type.IsValueType && !type.IsClass && systemTypeGenerator.TryGetValue(type, out IGenerator generator))
			{
				obj = generator.Generate();
				return obj;
			}*/
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
