namespace Simple
{
	public class Number : IExpression
	{
		public Number(int value)
		{
			Value = value;
		}

		public object Value
		{
			get;
			private set;
		}

		public bool IsReducible() { return false; }

		public IExpression Reduce(Environment environment)
		{
			return this;
		}

		public override string ToString()
		{
			return $"{Value}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}

		public IExpression Evaluate(Environment environment)
		{
			return this;
		}
	}
}
