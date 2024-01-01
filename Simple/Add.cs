namespace Simple
{
	public class Add : IExpression
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

		public Add(IExpression left, IExpression right)
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
				Number left = (Number)Left;
				Number right = (Number)Right;
				return new Number((int)left.Value + (int)right.Value);
			}
		}

		public override string ToString()
		{
			return $"{Left} + {Right}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}
	}
}
