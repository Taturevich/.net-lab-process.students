<Query Kind="Program" />

void Main()
{
	ParameterExpression p = Expression.Parameter (typeof (string), "s");
	ConstantExpression five = Expression.Constant(5);
	MemberExpression stringLength = Expression.Property(p, "Length");
	BinaryExpression comparison = Expression.LessThan(stringLength, five);
	Expression<Func<string, bool>> lambda = Expression.Lambda<Func<string, bool>>(comparison, p);
	Func<string, bool> runnable = lambda.Compile();
	Func<string, bool> del = s => s.Length < 5;

	Console.WriteLine (runnable ("kangaroo"));       
	Console.WriteLine(del("kangaroo"));
	
}
