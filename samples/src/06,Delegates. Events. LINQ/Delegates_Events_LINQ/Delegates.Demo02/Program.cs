using System;
using System.Linq;
using System.Reflection;

namespace Delegates.Demo02
{
    public delegate object TwoInt32s(int n1, int n2);
    public delegate object OneString(string s1);

    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                var usage = @"Usage:" 
                + "{0} delType methodName [Arg1] [Arg2]"
                + "{0}   where delType must be TwoInt32s or OneString" 
                + "{0}   if delType is TwoInt32s, methodName must be Add or Subtract" 
                + "{0}   if delType is OneString, methodName must be NumChars or Reverse"
                + "{0}"
                + "{0}Examples:" 
                + "{0}   TwoInt32s Add 123 321"
                + "{0}   TwoInt32s Subtract 123 321"
                + "{0}   OneString NumChars \"Hello there\"" 
                + "{0}   OneString Reverse  \"Hello there\"";
                Console.WriteLine(usage, Environment.NewLine);
                return;
            }

            var delType = Type.GetType(args[0]);
            if (delType == null)
            {
                Console.WriteLine("Invalid delType argument: " + args[0]);
                return;
            }

            Delegate d;
            try
            {          
                // Преобразование аргумента Arg1 в метод    
                MethodInfo mi = typeof(Program).GetTypeInfo().GetDeclaredMethod(args[1]);

                // Создание делегата, служащего оберткой статического метода 
                d = mi.CreateDelegate(delType);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid methodName argument: " + args[1]);
                return;
            }

            // Создание массива, содержащего аргументы,    
            // передаваемые методу через делегат    
            var  callbackArgs = new object[args.Length -  2];
            if (d.GetType() == typeof(TwoInt32s))
            {
                try
                {             // Преобразование аргументов типа String в тип Int32   
                    for (var a = 2; a < args.Length; a++)
                        callbackArgs[a - 2] = int.Parse(args[a]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Parameters must be integers.");
                    return;
                }
            }

            if (d.GetType() == typeof(OneString))
            {         
                // Простое копирование аргумента типа String   
                Array.Copy(args, 2, callbackArgs, 0, callbackArgs.Length);
            }

            try
            {   
                // Вызов делегата и вывод результата  
                var result = d.DynamicInvoke(callbackArgs);
                Console.WriteLine("Result = " + result);
            }
            catch (TargetParameterCountException)
            {
                Console.WriteLine("Incorrect number of parameters specified.");
            }   

        }

        private static object Add(int n1, int n2)
        {
            return n1 + n2;
        }

        private static object Subtract(int n1, int n2)
        {
            return n1 - n2;
        }

        private static object NumChars(string s1)
        {
            return s1.Length;
        }

        private static object Reverse(string s1)
        {
            return new string(s1.Reverse().ToArray());
        }

    }
}
