using FakerNameSpace.Generators;

namespace FakerNameSpace.Generators.SimpleTypeGenerators
{
	public interface ISimpleTypeGenerator :IGenerator
	{
		object Generate();
	}
}
