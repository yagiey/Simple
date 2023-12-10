namespace Simple
{
	public class Number : IExpression
	{
		public Number(int value)
		{
			Value = value;
		}

		public int Value
		{
			get;
			set;
		}

		public bool IsReducible() { return false; }

		public IExpression Reduce(Environment environment) { return this; }

		public override string ToString()
		{
			return $"≪{Value}≫";
		}
	}
}
