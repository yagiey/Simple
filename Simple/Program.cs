﻿namespace Simple
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

			new Machine(expression).Run();
		}
	}
}
