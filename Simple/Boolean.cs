namespace Simple
{
	public class Boolean : IExpression
	{
		public object Value
		{
			get;
			set;
		}

		public Boolean(bool value)
		{
			Value = value;
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
	}
}
