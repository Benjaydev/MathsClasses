using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix4 test = new Matrix4(1);

            Console.WriteLine(test[1, 0]);
            test[1, 0] = 2;
            Console.WriteLine(test[1,0]);

            Console.ReadKey();
        }
    }
}
