using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateConsoleApp
{
    class Program
    {
        static int num = 10;
        delegate int NumberChanger(int n);
        delegate int Number2Changer(int a, int b);
        delegate void ShowConsole1<in T>(T obj);
        delegate void ShowConsole2<in T>(T a, T b);
        delegate void ShowConsole3<in T, U>(T a, U b);

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        static void Main(string[] args)
        {
            //testDelegate();
            //testLambda();
            //testLambda2();
            testLambda3();

            Console.ReadLine();
        }
        
        private static void testLambda3()
        {
            ShowConsole1<string> showConsole1_1 = (s) => Console.WriteLine("string:　"+s);
            showConsole1_1("Hello");
            showConsole1_1("Walker");

            ShowConsole1<int> showConsole1_2 = (n) => Console.WriteLine("int x int: "+n*n);
            showConsole1_2(4);

            ShowConsole2<string> showConsole2 = (s1, s2) => {
                Console.WriteLine("s1:" + s1 + ", s2=" + s2);
                Console.WriteLine("s1+s2:" + s1 + s2);
            };
            showConsole2("hello", "walker");

            ShowConsole3<string, int> showConsole3_1 = (s, i) => {
                Console.WriteLine("s:"+s + ", i:"+i);
            };
            showConsole3_1("Walker", 10);
        }

        private static void testLambda2()
        {
            Number2Changer n2c = (n1, n2) => n1 + n2;

            Console.WriteLine("n2c(5): {0}", n2c(1, 2).ToString());
        }

        private static void testLambda()
        {
            NumberChanger nc = (n) => { int num = n + 10; return num; };
            NumberChanger nc1 = n => { int num = n + 10; return num; };
            NumberChanger nc2 = n => { return n + 10; };
            NumberChanger nc3 = n => n + 10;
            
            Console.WriteLine("nc(5): {0}", nc(15).ToString());
            Console.WriteLine("nc1(5): {0}", nc1(15).ToString());
            Console.WriteLine("nc2(5): {0}", nc2(15).ToString());
            Console.WriteLine("nc3(5): {0}", nc3(15).ToString());
        }

        private static void testDelegate()
        {
            NumberChanger nc1 = new NumberChanger(AddNum);

            NumberChanger nc2 = new NumberChanger(MultNum);

            Console.WriteLine("0 Num: {0}", getNum());
            nc1(25);
            Console.WriteLine("1 Num: {0}", getNum());
            nc1(15);
            Console.WriteLine("1 Num: {0}", getNum());
            nc2(10);
            Console.WriteLine("2 Num: {0}", getNum());

            NumberChanger nc;
            nc = nc1;
            nc += nc2;
            nc(5);
            Console.WriteLine("---- Num: {0}", getNum());
        }
    }
}
