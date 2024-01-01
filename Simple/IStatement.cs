using System;

namespace Simple
{
	public interface IStatement
	{
		bool IsReducible();

		Tuple<IStatement, Environment?> Reduce(Environment environment);

		string Inspect();
	}
}
