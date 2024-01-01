namespace Simple
{
	internal class Program
	{
		static void Main()
		{
			IStatement expression4 = new Assign("x", new Add(new Variable("x"), new Number(1)));
			Environment environment4 = new(new Dictionary<string, IExpression> { { "x", new Number(2) } });
			new Machine(expression4, environment4).Run();
			Console.WriteLine("----------");
		}
	}
}
