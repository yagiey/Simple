using System;
using System.Collections.Generic;

namespace Simple
{
	internal class Assign : IStatement
	{
		private string Name
		{
			get;
			set;
		}

		private IExpression Expression
		{
			get;
			set;
		}

		public Assign(string name, IExpression expression)
		{
			Name = name;
			Expression = expression;
		}

		public override string ToString()
		{
			return $"{Name} = {Expression}";
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
			if (Expression.IsReducible())
			{
				return Tuple.Create(
					(IStatement)new Assign(Name, Expression.Reduce(environment)),
					(Environment?)environment
				);
			}
			else
			{
				return Tuple.Create(
					(IStatement)new DoNothing(),
					(Environment?)environment.Merge(new Dictionary<string, IExpression> { [Name] = Expression }));
			}
		}
	}
}
