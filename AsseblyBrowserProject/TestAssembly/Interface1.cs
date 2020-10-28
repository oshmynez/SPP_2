using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{

    public struct User
    {
        public string name;
        public int age;
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;
        public struct User1
        {
            public int Age;
        }

        public void DisplayInfo()
        {

            Notify?.Invoke($"На счет поступило:");
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }
    public interface Interface1
    {

        public string TestField4 { get; }
        public int TestInt { get; set; }
        public string Teststring { get; set; }
        public DateTime TestDateTime { get; set; }
        public double TestDouble { get; set; }
        public float TestFloat { get; set; }


    }
    interface IMovable
    {
        public int minSpeed { get; set; }
        public double TestDouble { get; set; }
        public float TestFloat { get; set; }

    }
    enum Name
    {
        Dima, Maks, Vasya, Volodya, Nik, Denis, Artem, Vika, Ella, Don, Andrey, Nastya, Vadim, Alex, Lesha, Anya, Fedor, Zhenya, Kostya, Algerd, Misha, Larisa, Lera, Violetta, Olga
    }
}
