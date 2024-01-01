using System;

namespace Simple
{
	public class Machine
	{
		public IStatement Statement
		{
			get;
			set;
		}

		public Environment Environment
		{
			get;
			set;
		}

		public Machine(IStatement statement, Environment environment)
		{
			Statement = statement;
			Environment = environment;
		}

		public void Step()
		{
			var tuple = Statement.Reduce(Environment);
			Statement = tuple.Item1;
			Environment = tuple.Item2!;
		}

		public void Run()
		{
			while (Statement.IsReducible())
			{
				Console.WriteLine($"{Statement}, {Environment}");
				Step();
			}
			Console.WriteLine($"{Statement}, {Environment}");
		}
	}
}
