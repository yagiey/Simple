using System;

namespace Simple
{
	internal class DoNothing : IStatement, IEquatable<DoNothing>
	{
		public bool Equals(DoNothing? other)
		{
			if (other is null)
			{
				return false;
			}
			return true;
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as DoNothing);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool IsReducible()
		{
			return false;
		}

		public Tuple<IStatement, Environment?> Reduce(Environment environment)
		{
			return Tuple.Create((IStatement)this, (Environment?)environment);
		}

		public override string ToString()
		{
			return "do-nothing";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}

	}
}
