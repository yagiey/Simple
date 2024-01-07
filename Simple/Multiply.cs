namespace Simple
{
	public class Multiply : IExpression
	{
		private IExpression Left
		{
			get;
			set;
		}

		private IExpression Right
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
				return new Multiply(Left.Reduce(environment), Right);
			}
			else if (Right.IsReducible())
			{
				return new Multiply(Left, Right.Reduce(environment));
			}
			else
			{
				Number left = (Number)Left;
				Number right = (Number)Right;
				return new Number((int)left.Value * (int)right.Value);
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

		public IExpression Evaluate(Environment environment)
		{
			Number left = (Number)Left.Evaluate(environment);
			Number right = (Number)Right.Evaluate(environment);
			return new Number((int)left.Value * (int)right.Value);
		}
	}
}
