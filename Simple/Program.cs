using System;
using System.Collections.Generic;

namespace Simple
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine("==============================");
			Console.WriteLine("small-step semantics");
			Console.WriteLine("==============================");
			RunAsSmallStep();

			Console.WriteLine("==============================");
			Console.WriteLine("big-step semantics");
			Console.WriteLine("==============================");
			RunAsBigStep();
		}
		static void RunAsSmallStep()
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

			new Machine(
				new Sequence(
					new Assign("x", new Add(new Number(1), new Number(1))),
					new Assign("y", new Add(new Variable("x"), new Number(3)))
				),
				new Environment(new Dictionary<string, IExpression> { { "x", new Boolean(false) } })
			).Run();
			Console.WriteLine("----------");

			new Machine(
				new While(
					new LessThan(new Variable("x"), new Number(5)),
					new Assign("x", new Multiply(new Variable("x"), new Number(3)))
				),
				new Environment(new Dictionary<string, IExpression> { { "x", new Number(1) } })
			).Run();
			Console.WriteLine("----------");

			//new Machine(
			//	new Sequence(
			//		new Assign("x", new Boolean(true)),
			//		new Assign("x", new Add(new Variable("x"), new Number(1)))
			//	),
			//	new Environment()
			//).Run();
			//Console.WriteLine("----------");
		}

		static void RunAsBigStep()
		{
			Console.WriteLine(
				new Variable("x").Evaluate(new Environment(new Dictionary<string, IExpression> { { "x", new Number(23) } })).Inspect()
			);
			Console.WriteLine(
				new Number(23).Evaluate(new Environment()).Inspect()
			);
			Console.WriteLine(
				new LessThan(
					new Add(new Variable("x"), new Number(2)),
					new Variable("y")
				).Evaluate(new Environment(new Dictionary<string, IExpression>() { { "x", new Number(2) }, { "y", new Number(5) } })).Inspect()
			);
			Console.WriteLine("----------");

			Sequence seq =
				new Sequence(
					new Assign("x", new Add(new Number(1), new Number(1))),
					new Assign("y", new Add(new Variable("x"), new Number(3)))
				);
			Console.WriteLine(seq.Inspect());
			Console.WriteLine(seq.Evaluate(new Environment()));
			Console.WriteLine("----------");

			While w =
				new While(
					new LessThan(new Variable("x"), new Number(5)),
					new Assign("x", new Multiply(new Variable("x"), new Number(3)))
				);
			Console.WriteLine(w.Inspect());
			Console.WriteLine(w.Evaluate(new Environment(new Dictionary<string, IExpression> { { "x", new Number(1) } })));
			Console.WriteLine("----------");
		}
	}
}
