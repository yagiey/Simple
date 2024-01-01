using System;
using System.Collections.Generic;

namespace Simple
{
	internal class Program
	{
		static void Main()
		{
			IStatement statement = new Assign("x", new Add(new Variable("x"), new Number(1)));
			Environment environment4 = new(new Dictionary<string, IExpression> { { "x", new Number(2) } });
			new Machine(statement, environment4).Run();
			Console.WriteLine("----------");

			new Machine(
				new If(
					new Variable("x"),
					new Assign("y", new Number(1)),
					new Assign("y", new Number(2))
				),
				new Environment(new Dictionary<string, IExpression> { {"x", new Boolean(true) } })
			).Run();
			Console.WriteLine("----------");

			new Machine(
				new If(
					new Variable("x"),
					new Assign("y", new Number(1)),
					new DoNothing()
				),
				new Environment(new Dictionary<string, IExpression> { { "x", new Boolean(false) } })
			).Run();
			Console.WriteLine("----------");
		}
	}
}
