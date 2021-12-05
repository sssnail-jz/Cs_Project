using System;

namespace CS_4虚方法_重写方法_抽象方法
{
    using System;
    using System.Collections;
    public abstract class Expression
    {
        public abstract double Evaluate(Hashtable vars);
    }
    public class Constant : Expression
    {
        double value;
        public Constant(double value)
        {
            this.value = value;
        }
        public override double Evaluate(Hashtable vars)
        {
            return value;
        }
    }
    public class VariableReference : Expression
    {
        string name;
        public VariableReference(string name)
        {
            this.name = name;
        }
        public override double Evaluate(Hashtable vars)
        {
            object value = vars[name];
            if (value == null)
            {
                throw new Exception("Unknown variable: " + name);
            }
            return Convert.ToDouble(value);
        }
    }
    public class Operation : Expression
    {
        Expression left;
        char op;
        Expression right;
        public Operation(Expression left, char op, Expression right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }
        public override double Evaluate(Hashtable vars)
        {
            double x = left.Evaluate(vars);
            double y = right.Evaluate(vars);
            switch (op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
            }
            throw new Exception("Unknown operator");
        }
    }
    class Test
    {
        static void Main()
        {
            Expression e = new Operation(
                new VariableReference("x"),
                '*',
                new Operation(
                    new VariableReference("y"),
                    '+',
                    new Constant(2)
                )
            );
            Hashtable vars = new Hashtable();
            vars["x"] = 3;
            vars["y"] = 5;
            Console.WriteLine(e.Evaluate(vars));        // Outputs "21"
            vars["x"] = 1.5;
            vars["y"] = 9;
            Console.WriteLine(e.Evaluate(vars));        // Outputs "16.5"
            Console.ReadLine();
        }
    }
}
