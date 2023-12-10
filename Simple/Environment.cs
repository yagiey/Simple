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
            Map = new Dictionary<string, IExpression>();
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
    }
}
