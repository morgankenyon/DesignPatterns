using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    //https://en.wikipedia.org/wiki/Visitor_pattern#C#_example
    public interface IExpressionVisitor
    {
        void Visit(Literal literal);
        void Visit(Addition addition);
        void Visit(Subtraction subtraction);
    }

    public interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }

    public class Literal : IExpression
    {
        internal double Value { get; set; }

        public Literal(double value)
        {
            Value = value;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Addition : IExpression
    {
        internal IExpression Left { get; set; }
        internal IExpression Right { get; set; }

        public Addition(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Subtraction : IExpression
    {
        internal IExpression Left { get; set; }
        internal IExpression Right { get; set; }

        public Subtraction(IExpression left, IExpression right)
        {
            Left = left;
            Right = right;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

    }

    public class PrefixExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb;

        public PrefixExpressionPrinter(StringBuilder sb)
        {
            this.sb = sb;
        }

        public void Visit(Literal literal)
        {
            sb.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            sb.Append("+ ");
            addition.Left.Accept(this);
            sb.Append(" ");
            addition.Right.Accept(this);
        }

        public void Visit(Subtraction subtraction)
        {
            sb.Append("-");
            subtraction.Left.Accept(this);
            sb.Append(" ");
            subtraction.Right.Accept(this);
        }

    }

    public class InfixExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb;

        public InfixExpressionPrinter(StringBuilder sb)
        {
            this.sb = sb;
        }

        public void Visit(Literal literal)
        {
            sb.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            sb.Append("(");
            addition.Left.Accept(this);
            sb.Append("+");
            addition.Right.Accept(this);
            sb.Append(")");
        }

        public void Visit(Subtraction subtraction)
        {
            sb.Append("(");
            subtraction.Left.Accept(this);
            sb.Append("-");
            subtraction.Right.Accept(this);
            sb.Append(")");
        }
    }

    public class PostfixExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb;

        public PostfixExpressionPrinter(StringBuilder sb)
        {
            this.sb = sb;
        }

        public void Visit(Literal literal)
        {
            sb.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            addition.Left.Accept(this);
            sb.Append(" ");
            addition.Right.Accept(this);
            sb.Append(" +");
        }

        public void Visit(Subtraction subtraction)
        {
            subtraction.Left.Accept(this);
            sb.Append(" ");
            subtraction.Right.Accept(this);
            sb.Append(" -");
        }
    }

    public class WikipediaExample
    {
        public void Run()
        {
            var addition1 = new Addition(
                new Literal(5.0), new Literal(6.0));

            var sb = new StringBuilder();
            var expressionPrinter = new InfixExpressionPrinter(sb);
            addition1.Accept(expressionPrinter);
            Console.WriteLine(sb);

            var complexAddition = new Addition(
                new Addition(
                    new Subtraction(
                        new Literal(5.0), new Literal(6.0)),
                    new Literal(20.0)),
                new Addition(
                    new Literal(1.0), new Literal(3.0)));

            sb.Clear();
            complexAddition.Accept(expressionPrinter);
            Console.WriteLine(sb);

            sb.Clear();
            var postfixExpressionPrinter = new PostfixExpressionPrinter(sb);
            complexAddition.Accept(postfixExpressionPrinter);
            Console.WriteLine(sb);

            sb.Clear();
            var prefixExpressionPrinter = new PrefixExpressionPrinter(sb);
            complexAddition.Accept(prefixExpressionPrinter);
            Console.WriteLine(sb);
        }
    }

}
