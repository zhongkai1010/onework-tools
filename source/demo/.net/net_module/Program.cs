using System;
using System.Reflection;

namespace net_module
{
    class Program
    {
        static void Main(string[] rgs)
        {
            Assembly assembly  = Assembly.GetAssembly(typeof(Program));


            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }

          

            Console.Read();
        }
    }
}
