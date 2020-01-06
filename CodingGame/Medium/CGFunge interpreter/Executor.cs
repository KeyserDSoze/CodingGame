using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.CGFunge_interpreter
{
    internal class Executor
    {
        private Stack<int> MyStacks = new Stack<int>();
        public void Solve(List<string> values)
        {
            MyExecutionPosition myExecutionPosition = new MyExecutionPosition(values);
            while (!myExecutionPosition.HasEnded)
            {
                char c = values[myExecutionPosition.Y][myExecutionPosition.X];
                IInterpreter interpreter = InterpreterFactory.Create(c, myExecutionPosition);
                if (c == '_')
                {
                    string a = "";
                }
                interpreter.Interprete(this.MyStacks);
                myExecutionPosition.Next();
            }
            Console.Write(myExecutionPosition.Output);
        }
    }
    internal class InterpreterFactory
    {
        public static IInterpreter Create(char c, MyExecutionPosition myExecutionPosition)
        {
            if (myExecutionPosition.IsStringActive && c != '"')
            {
                return new MyString(c, myExecutionPosition);
            }
            else
            {
                switch (c)
                {
                    case 'I':
                    case 'C':
                        return new Printer(c, myExecutionPosition);
                    case 'S':
                        return new Skipper(myExecutionPosition);
                    case '_':
                    case '|':
                        return new IfStatement(c, myExecutionPosition);
                    case '>':
                    case '<':
                    case '^':
                    case 'v':
                        return new Position(c, myExecutionPosition);
                    case '+':
                    case '-':
                    case '*':
                        return new Operation(c, myExecutionPosition);
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        return new Number(c, myExecutionPosition);
                    case '"':
                        return new StartString(myExecutionPosition);
                    case 'E':
                        return new Exit(myExecutionPosition);
                    case 'P':
                        return new Pop();
                    case 'D':
                        return new Duplicate();
                    case 'X':
                        return new Invert();
                    default:
                        return new MyString(c, myExecutionPosition);
                }
            }
        }
    }
    internal interface IInterpreter
    {
        void Interprete(Stack<int> myStacks);
    }
    internal class Duplicate : IInterpreter
    {
        public void Interprete(Stack<int> myStacks)
        {
            int myStack = myStacks.Peek();
            myStacks.Push(myStack);
        }
    }
    internal class Invert : IInterpreter
    {
        public void Interprete(Stack<int> myStacks)
        {
            int first = myStacks.Pop();
            int second = myStacks.Pop();
            myStacks.Push(first);
            myStacks.Push(second);
        }
    }
    internal class Pop : IInterpreter
    {
        public void Interprete(Stack<int> myStacks)
        {
            myStacks.Pop();
        }
    }
    internal class Skipper : IInterpreter
    {
        public MyExecutionPosition MyExecutionPosition { get; }
        public Skipper(MyExecutionPosition myExecutionPosition)
            => this.MyExecutionPosition = myExecutionPosition;
        public void Interprete(Stack<int> myStacks)
        {
            this.MyExecutionPosition.Next();
        }
    }
    internal class Exit : IInterpreter
    {
        public MyExecutionPosition MyExecutionPosition { get; }
        public Exit(MyExecutionPosition myExecutionPosition)
            => this.MyExecutionPosition = myExecutionPosition;
        public void Interprete(Stack<int> myStacks)
        {
            this.MyExecutionPosition.HasEnded = true;
        }
    }
    internal class Printer : IInterpreter
    {
        public char C { get; }
        public MyExecutionPosition MyExecutionPosition { get; }
        public Printer(char c, MyExecutionPosition myExecutionPosition)
        {
            this.C = c;
            this.MyExecutionPosition = myExecutionPosition;
        }
        public void Interprete(Stack<int> myStacks)
        {
            int first = myStacks.Pop();
            if (this.C == 'I')
                this.MyExecutionPosition.Output += first.ToString();
            else
                this.MyExecutionPosition.Output += ((char)first).ToString();
        }
    }
    internal class IfStatement : IInterpreter
    {
        public char C { get; }
        public MyExecutionPosition MyExecutionPosition { get; }
        public IfStatement(char c, MyExecutionPosition myExecutionPosition)
        {
            this.C = c;
            this.MyExecutionPosition = myExecutionPosition;
        }
        public void Interprete(Stack<int> myStacks)
        {
            int first = myStacks.Pop();
            if (this.C == '_')
            {
                if (first == 0)
                    new Position('>', this.MyExecutionPosition).Interprete(myStacks);
                else
                    new Position('<', this.MyExecutionPosition).Interprete(myStacks);
            }
            else
            {
                if (first == 0)
                    new Position('v', this.MyExecutionPosition).Interprete(myStacks);
                else
                    new Position('^', this.MyExecutionPosition).Interprete(myStacks);
            }
        }
    }
    internal class MyString : IInterpreter
    {
        public char C { get; }
        public MyExecutionPosition MyExecutionPosition { get; }
        public MyString(char c, MyExecutionPosition myExecutionPosition)
        {
            this.C = c;
            this.MyExecutionPosition = myExecutionPosition;
        }
        public void Interprete(Stack<int> myStacks)
        {
            if (MyExecutionPosition.IsStringActive)
            {
                myStacks.Push(this.C);
            }
        }
    }
    internal class Operation : IInterpreter
    {
        public char C { get; }
        public MyExecutionPosition MyExecutionPosition { get; }
        public Operation(char c, MyExecutionPosition myExecutionPosition)
        {
            this.C = c;
            this.MyExecutionPosition = myExecutionPosition;
        }
        public void Interprete(Stack<int> myStacks)
        {
            int first = myStacks.Pop();
            int second = myStacks.Pop();
            switch (this.C)
            {
                case '+':
                    myStacks.Push((first + second) % 256);
                    break;
                case '-':
                    myStacks.Push((second - first) % 256);
                    break;
                case '*':
                    myStacks.Push((first * second) % 256);
                    break;
            }
        }
    }
    internal class Position : IInterpreter
    {
        public char C { get; }
        public MyExecutionPosition MyExecutionPosition { get; }
        public Position(char c, MyExecutionPosition myExecutionPosition)
        {
            this.C = c;
            this.MyExecutionPosition = myExecutionPosition;
        }
        public void Interprete(Stack<int> myStacks)
        {
            switch (this.C)
            {
                case '>':
                    MyExecutionPosition.XDirection = 1;
                    MyExecutionPosition.YDirection = 0;
                    break;
                case '<':
                    MyExecutionPosition.XDirection = -1;
                    MyExecutionPosition.YDirection = 0;
                    break;
                case '^':
                    MyExecutionPosition.XDirection = 0;
                    MyExecutionPosition.YDirection = -1;
                    break;
                case 'v':
                    MyExecutionPosition.XDirection = 0;
                    MyExecutionPosition.YDirection = 1;
                    break;
            }
        }
    }
    internal class Number : IInterpreter
    {
        public char C { get; }
        public MyExecutionPosition MyExecutionPosition { get; }
        public Number(char c, MyExecutionPosition myExecutionPosition)
        {
            this.C = c;
            this.MyExecutionPosition = myExecutionPosition;
        }
        public void Interprete(Stack<int> myStacks)
        {
            myStacks.Push(int.Parse(this.C.ToString()));
        }
    }
    internal class StartString : IInterpreter
    {
        public MyExecutionPosition MyExecutionPosition { get; }
        public StartString(MyExecutionPosition myExecutionPosition) => this.MyExecutionPosition = myExecutionPosition;
        public void Interprete(Stack<int> myStacks)
        {
            this.MyExecutionPosition.IsStringActive = !this.MyExecutionPosition.IsStringActive;
        }
    }
    internal class MyExecutionPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }
        public bool IsStringActive { get; set; }
        public bool HasEnded { get; set; }
        public string Output { get; set; }
        public int[] MaxX { get; }
        public int MaxY { get; }
        public MyExecutionPosition(List<string> values)
        {
            this.MaxY = values.Count;
            this.MaxX = new int[this.MaxY];
            for (int i = 0; i < this.MaxY; i++)
                this.MaxX[i] = values[i].Length;
            this.XDirection = 1;
        }
        public void Next()
        {
            if (this.XDirection != 0)
            {
                this.X += this.XDirection;
            }
            else if (this.YDirection != 0)
            {
                this.Y += this.YDirection;
            }
        }
    }
}
