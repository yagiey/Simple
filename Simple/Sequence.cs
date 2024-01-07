using System;

namespace Simple
{
	internal class Sequence : IStatement
	{
		private IStatement First
		{
			get;
			set;
		}

		private IStatement Second
		{
			get;
			set;
		}

		public Sequence(IStatement first, IStatement second)
		{
			First = first;
			Second = second;
		}

		public override string ToString()
		{
			return $"{First}; {Second}";
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
			if (First is DoNothing)
			{
				return
					Tuple.Create(
						Second,
						(Environment?)environment
					);
			}
			else
			{
				var reduced = First.Reduce(environment);
				return
					Tuple.Create(
						(IStatement)new Sequence(reduced.Item1, Second),
						reduced.Item2
					);
			}
		}

		public Environment Evaluate(Environment environment)
		{
			return Second.Evaluate(First.Evaluate(environment));
		}
	}
}
