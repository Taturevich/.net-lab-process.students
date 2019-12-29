using System;

namespace Generics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Covariance();
            Contravariance();
        }

        private static void Covariance()
        {
            ICovariant<Fruit> fruit = new Covariant<Fruit>();
            ICovariant<Fruit> apple = new Covariant<Apple>();
            // ICovariant<Apple> fruit = new Covariant<Fruit>(); // not allowed
            // Covariant<Fruit> appleNotCompiled = new Covariant<Apple>(); // won't compile
            // Implementations are always invariant, use interfaces to achieve variance
            Console.WriteLine(fruit.GetType());
            Console.WriteLine(apple.GetType());
        }

        private static void Contravariance()
        {
            IContravariant<Apple> fruit = new Contravariant<Fruit>();
            IContravariant<Apple> apple = new Contravariant<Apple>();
            // IContravariant<Fruit> apple = new Contravariant<Apple>(); // not allowed
            Console.WriteLine(fruit.GetType());
            Console.WriteLine(apple.GetType());
        }
    }
}
