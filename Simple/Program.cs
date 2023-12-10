namespace Simple
{
	internal class Program
	{
		static void Main()
		{
			IExpression expression =
				new Add(
					new Multiply(new Number(1), new Number(2)),
					new Multiply(new Number(3), new Number(4))
				);

			new Machine(expression, new Environment()).Run();

			IExpression expression2 =
				new LessThan(
					new Number(5),
					new Add(new Number(2), new Number(2))
				);

			new Machine(expression2, new Environment()).Run();

			IExpression expression3 = new Add(new Variable("x"), new Variable("y"));
			Environment environment3 = new();
			environment3.Set("x", new Number(3));
			environment3.Set("y", new Number(4));
			new Machine(expression3, environment3).Run();
		}
	}
}
