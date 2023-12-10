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

		public IExpression Reduce() { return this; }

		public override string ToString()
		{
			return Value.ToString();
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}
	}
}
