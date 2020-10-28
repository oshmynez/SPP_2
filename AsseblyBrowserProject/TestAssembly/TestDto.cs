using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssembly
{
    
    public class TestDto
    {

        public class newClass
        {
            public string s1;
        }

        public static string s = "Привет мир";
        public static char c = 'и';
        int i = s.CharCount(c);
        public object TestField2;
        public TestDto TestField3;
        public List<int> Listint;
        private TestDto TestField12;
        public string TestField4 { get; }
        public int TestInt { get; set; }
        public string Teststring { get; set; }
        public DateTime TestDateTime { get; set; }
        public double TestDouble { get; set; }
        public float TestFloat { get; set; }

    }

    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
    public class TestDto2Constructors
    {
        public int NewTestTestInt { get; }
        public double NewTestTestDouble;
        public string NewTestTeststring;
        public DateTime NewTestTestDateTime { get; set; }
        public TestDto TestObject { get; set; }

        private TestDto2Constructors(double one, string two, DateTime three)
        {
            NewTestTestDouble = one;
            NewTestTeststring = two;
            NewTestTestDateTime = three;
        }

        public TestDto2Constructors()
        {

        }

        public TestDto2Constructors(double one, string two, int five)
        {
            NewTestTestDouble = one;
            NewTestTeststring = two;
            NewTestTestInt = five;
        }

        public TestDto2Constructors(double one, string two)
        {
            NewTestTestDouble = one;
            NewTestTeststring = two;
        }

        public TestDto2Constructors(string two)
        {
            NewTestTestDouble = 111;
            NewTestTeststring = two;
        }

        public void SomeDo(int i)
        {

        }
        public bool SomeDo2(int i,bool b)
        {
            return true;
        }
        public void SomeDo3()
        {

        }
        enum Name
        {
            Dima, Maks, Vasya, Volodya, Nik, Denis, Artem, Vika, Ella, Don, Andrey, Nastya, Vadim, Alex, Lesha, Anya, Fedor, Zhenya, Kostya, Algerd, Misha, Larisa, Lera, Violetta, Olga
        }
    }
}
