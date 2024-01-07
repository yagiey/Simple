namespace Simple
{
	public interface IExpression
	{
		bool IsReducible();

		IExpression Reduce(Environment environment);

		string Inspect();

		IExpression Evaluate(Environment environment);
	}
}
