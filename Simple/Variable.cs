namespace Simple
{
	public class Variable : IExpression
	{
		public object Value
		{
			get;
			set;
		}

		public Variable(string name)
		{
			Value = name;
		}

		public bool IsReducible() { return true; }

		public IExpression Reduce(Environment environment)
		{
			return environment.Find(Value.ToString()!);
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
