﻿namespace Simple
{
	public class Add : IExpression
	{
		public IExpression Left
		{
			get;
			set;
		}

		public IExpression Right
		{
			get;
			set;
		}

		public Add(IExpression left, IExpression right)
		{
			Left = left;
			Right = right;
		}

		public bool IsReducible() { return true; }

		public IExpression Reduce()
		{
			if (Left.IsReducible())
			{
				return new Add(Left.Reduce(), Right);
			}
			else if (Right.IsReducible())
			{
				return new Add(Left, Right.Reduce());
			}
			else
			{
				return new Number(((Number)Left).Value + ((Number)Right).Value);
			}
		}

		public override string ToString()
		{
			return $"{Left} + {Right}";
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}
	}
}
