namespace Simple
{
	internal class Assign : IStatement
	{
		public string Name
		{
			get;
			private set;
		}

		public IExpression Expression
		{
			get;
			private set;
		}

		public Assign(string name, IExpression expression)
		{
			Name = name;
			Expression = expression;
		}

		public override string ToString()
		{
			return $"{Name} = {Expression}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}

		public bool IsReducible()
		{
			return true;
		}

		public Tuple<IStatement, Environment?> Reduce(Environment environment)
		{
			if (Expression.IsReducible())
			{
				return Tuple.Create(
					(IStatement)new Assign(Name, Expression.Reduce(environment)),
					(Environment?)environment
				);
			}
			else
			{
				return Tuple.Create(
					(IStatement)new DoNothing(),
					(Environment?)environment.Merge(new Dictionary<string, IExpression> { [Name] = Expression }));
			}
		}
	}
}
