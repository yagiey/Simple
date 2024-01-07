using System;

namespace Simple
{
	internal class If : IStatement
	{
		private IExpression Condition
		{
			get;
			set;
		}

		private IStatement Consequence
		{
			get;
			set;
		}

		private IStatement Alternative
		{
			get;
			set;
		}

		public If(IExpression condition, IStatement consequence, IStatement alternative)
		{
			Condition = condition;
			Consequence = consequence;
			Alternative = alternative;
		}

		public override string ToString()
		{
			return $"if ({Condition}) {{ {Consequence} }} else {{ {Alternative} }}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}

		public bool IsReducible()
		{
			return true;
		}

		public Tuple<IStatement, Environment?> Reduce(Environment environment)
		{
			if (Condition.IsReducible())
			{
				return
					Tuple.Create(
						(IStatement)new If(Condition.Reduce(environment), Consequence, Alternative),
						(Environment?)environment
					);
			}
			else
			{
				object o = ((Boolean)Condition).Value;
				bool cond = (bool)o;
				if(cond == true)
				{
					return
						Tuple.Create(
							Consequence,
							(Environment?)environment
						);
				}
				else
				{
					return
						Tuple.Create(
							Alternative,
							(Environment?)environment
						);
				}
			}
		}

		public Environment Evaluate(Environment environment)
		{
			IExpression resultCondition = Condition.Evaluate(environment);
			Boolean obj = (Boolean)resultCondition;
			bool b = (bool)obj.Value;
			if (b)
			{
				return Consequence.Evaluate(environment);
			}
			else
			{
				return Alternative.Evaluate(environment);
			}
		}
	}
}
