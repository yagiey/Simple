namespace Simple
{
	public class Multiply : IExpression
	{
		public IExpression Left
		{
			get;
			set;
		}

		public IExpression Right
		{
			get;
			set;
		}

		public Multiply(IExpression left, IExpression right)
		{
			Left = left;
			Right = right;
		}

		public bool IsReducible() { return true; }

		public IExpression Reduce(Environment environment)
		{
			if (Left.IsReducible())
			{
				return new Add(Left.Reduce(environment), Right);
			}
			else if (Right.IsReducible())
			{
				return new Add(Left, Right.Reduce(environment));
			}
			else
			{
				return new Number(((Number)Left).Value * ((Number)Right).Value);
			}
		}

		public override string ToString()
		{
			return $"{Left} * {Right}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}
	}
}
