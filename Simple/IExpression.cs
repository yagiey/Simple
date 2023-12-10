namespace Simple
{
	public interface IExpression
	{
		bool IsReducible();
		IExpression Reduce();
		string Inspect();
	}
}
