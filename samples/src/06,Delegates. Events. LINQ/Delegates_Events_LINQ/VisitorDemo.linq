<Query Kind="Program" />

abstract class Expression
{
}

class Literal : Expression
{
	public double Value { get; }

	public Literal(double value)
	{
		this.Value = value;
	}
}

class Addition : Expression
{
	public Expression Left { get; }
	public Expression Right { get; }

	public Addition(Expression left, Expression right)
	{
		Left = left;
		Right = right;
	}
}

class ExpressionPrinter
{
	public static void Print(Literal literal, StringBuilder sb)
	{
		sb.Append(literal.Value);
	}

	public static void Print(Addition addition, StringBuilder sb)
	{
		sb.Append("(");
		Print((dynamic)addition.Left, sb);
		sb.Append("+");
		Print((dynamic)addition.Right, sb);
		sb.Append(")");
	}
}


void Main()
{
	
    // emulate 1+2+3
	var e = new Addition(
	  new Addition(
		new Literal(1),
		new Literal(2)
	  ),
	  new Literal(3)
	);
	var sb = new StringBuilder();
	ExpressionPrinter.Print((dynamic)e, sb);
	Console.WriteLine(sb.ToString());
}

// Define other methods and classes here
