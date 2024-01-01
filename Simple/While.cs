using System;

namespace Simple
{
	internal class While : IStatement
	{
		private IExpression Condition
		{
			get;
			set;
		}

		private IStatement Body
		{
			get;
			set;
		}

		public While(IExpression condition, IStatement body)
		{
			Condition = condition;
			Body = body;
		}

		public override string ToString()
		{
			return $"while ({Condition}) {{ {Body} }}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}

		public bool IsReducible()
		{
			return true ;
		}

		public Tuple<IStatement, Environment?> Reduce(Environment environment)
		{
			return
				Tuple.Create(
					(IStatement)new If(Condition, new Sequence(Body, this), new DoNothing()),
					(Environment?)environment
				);
		}
	}
}
