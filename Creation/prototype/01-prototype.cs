using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    public static class ExtensionMethod
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

    }

    [Serializable]
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    [Serializable]
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }

    class Demo
    {
        public static void Main()
        {
            var john = new Person(new[] { "John", "Smith" },
              new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}

