namespace Simple
{
	public class Environment
	{
		private Dictionary<string, IExpression> Map
		{
			get;
			set;
		}

		public Environment()
		{
			Map = [];
		}

		public Environment(Dictionary<string, IExpression> map)
		{
			Map = new Dictionary<string, IExpression>(map);
		}

		public bool Set(string key, IExpression value)
		{
			bool result = Map.ContainsKey(key);
			if (result)
			{
				Map[key] = value;
			}
			else
			{
				Map.Add(key, value);
			}
			return result;
		}

		public IExpression Find(string key)
		{
			return Map[key];
		}

		public Environment Merge(Dictionary<string, IExpression> map)
		{
			Environment newEnv = new(Map);
			foreach (var pair in map)
			{
				newEnv.Set(pair.Key, pair.Value);
			}
			return newEnv;
		}

		public override string ToString()
		{
			return "{" + string.Join(", ", Map.Select(it => $"\"{it.Key}\"=>{it.Value.Inspect()}")) + "}";
		}
	}
}
