using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

using FakerNameSpace.Generators;
using FakerNameSpace.Generators.SimpleTypeGenerators;
using FakerNameSpace.Generators.ListTypeGenerators;

namespace FakerNameSpace
{
	public class Faker : IFaker
	{

		private Dictionary<Type, ISimpleTypeGenerator> simpleTypeGenerator;
		private Dictionary<Type, IGenericTypeGenerator> genericTypeGenerator;
		private string pluginsPath = "Plugins";

		public Faker()
		{
			simpleTypeGenerator = new Dictionary<Type, ISimpleTypeGenerator>();
			genericTypeGenerator = new Dictionary<Type, IGenericTypeGenerator>();

			List<Assembly> assemblies = GetAssemblies(pluginsPath);
			ISimpleTypeGenerator pluginGenerator = null;
			
			foreach (Assembly a in  assemblies)
			{
				foreach (Type type in a.GetTypes())
				{
					foreach (Type typeInterface in type.GetInterfaces())
					{
						if (typeInterface.Equals(typeof(ISimpleTypeGenerator)))
						{
							pluginGenerator = (ISimpleTypeGenerator)Activator.CreateInstance(type);
							simpleTypeGenerator.Add(pluginGenerator.GeneratedType, pluginGenerator);
						}
					}
				}
			}
			
			if (!simpleTypeGenerator.ContainsKey(typeof(DateTime)))
			{
				simpleTypeGenerator.Add(typeof(DateTime), new DateTypeGenerator());
			}
			if (!simpleTypeGenerator.ContainsKey(typeof(double)))
			{
				simpleTypeGenerator.Add(typeof(double), new DoubleTypeGenerator());
			}
			if (!simpleTypeGenerator.ContainsKey(typeof(int)))
			{
				simpleTypeGenerator.Add(typeof(int), new IntTypeGenerator());
			}
			if (!simpleTypeGenerator.ContainsKey(typeof(long)))
			{
				simpleTypeGenerator.Add(typeof(long), new LongTypeGenerator());
			}


			if (!genericTypeGenerator.ContainsKey(typeof(List<>)))
			{
				genericTypeGenerator.Add(typeof(List<>), new ListTypeGenerator());
			}
		}

		private List<Assembly> GetAssemblies(string path)
		{
			List<Assembly> assemblies = new List<Assembly>();
			try
			{
				foreach (string file in Directory.GetFiles(pluginsPath, "*.dll"))
				{
					try
					{
						assemblies.Add(Assembly.LoadFile(new FileInfo(file).FullName));
					}
					catch (BadImageFormatException)
					{ }
					catch (FileLoadException)
					{ }
				}
			}
			catch (DirectoryNotFoundException)
			{ }
			return assemblies;
		}

 		public T Create<T>()
		{
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
			if (simpleTypeGenerator.TryGetValue(type, out ISimpleTypeGenerator generator))
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
			}
			return null;
		}
	}
}
