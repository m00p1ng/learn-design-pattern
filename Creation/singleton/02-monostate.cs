using System;

namespace Singleton
{
    public class CEO
    {
        static string name;
        static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    class Demo
    {
        public static void Main()
        {
            var ceo = new CEO
            {
                Name = "Adam Smith",
                Age = 55
            };

            var ceo2 = new CEO();

            Console.WriteLine(ceo2);
        }
    }
}
