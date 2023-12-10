namespace Simple
{
	public class Boolean : IExpression
	{
        public bool Value
        {
            get;
            set;
        }

        public Boolean(bool value)
        {
            Value = value;
        }

		public bool IsReducible() { return false; }

		public IExpression Reduce(Environment environment) { return this; }

		public override string ToString()
		{
			return $"≪{Value}≫";
		}
	}
}
