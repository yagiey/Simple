using System;

namespace Simple
{
	public class Machine
	{
        public IExpression Expression
        {
            get;
            set;
        }

		public Environment Environment
		{
			get;
			set;
		}

		public Machine(IExpression expression, Environment environment)
        {
            Expression = expression;
			Environment = environment;

		}

        public void Step()
        {
			Expression = Expression.Reduce(Environment);
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
