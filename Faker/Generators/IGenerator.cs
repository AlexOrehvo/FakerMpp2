using System;

namespace FakerNameSpace.Generators
{
	public interface IGenerator
	{
		Type GeneratedType { get; }
	}
}
