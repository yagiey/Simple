namespace Simple
{
	public class Machine
	{
        public IExpression Expression
        {
            get;
            set;
        }

        public Machine(IExpression expression)
        {
            Expression = expression;
        }

        public void Step()
        {
			Expression = Expression.Reduce();
		}

		public void Run()
        {
            while (Expression.IsReducible())
            {
                Console.WriteLine(Expression);
                Step();
            }
			Console.WriteLine(Expression);
		}
	}
}
