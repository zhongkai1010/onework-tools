usingystem;
usingystem.Reflection;

namespace net_module
{
    class Program
    {
       tatic void Main(string[]rgs)
        {
           ssemblyssembly =ssembly.GetAssembly(typeof(Program));
           oreachType type inssembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
            }

            Console.Read();
        }
    }
}
