namespace Simple
{
	public class LessThan : IExpression
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

		public LessThan(IExpression left, IExpression right)
		{
			Left = left;
			Right = right;
		}

		public bool IsReducible() { return true; }

		public IExpression Reduce(Environment environment)
		{
			if (Left.IsReducible())
			{
				return new LessThan(Left.Reduce(environment), Right);
			}
			else if (Right.IsReducible())
			{
				return new LessThan(Left, Right.Reduce(environment));
			}
			else
			{
				return new Boolean(((Number)Left).Value < ((Number)Right).Value);
			}
		}

		public override string ToString()
		{
			return $"{Left} < {Right}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}
	}
}
