using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
	public class Variable : IExpression
	{
		public string Name
		{
			get;
			set;
		}

		public Variable(string name)
		{
			Name = name;
		}

		public bool IsReducible() { return true; }

		public IExpression Reduce(Environment environment)
		{
			return environment.Find(Name);
		}

		public override string ToString()
		{
			return Name.ToString();
		}

		public string Inspect()
		{
			return $"≪{this}≫";
		}
	}
}
