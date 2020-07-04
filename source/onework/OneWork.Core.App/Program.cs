using System;
using Autofac;

namespace OneWork.Core.App
{
    public interface IRepository
    {
        void Insert();
    }

    public class UserRepository: IRepository
    {
        public void Insert()
        {
            Console.WriteLine("Insert User");
        }
    }

    public class RoleRepository : IRepository
    {
        public void Insert()
        {
            Console.WriteLine("Insert Role");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RoleRepository>().As<IRepository>();
            builder.RegisterType<UserRepository>().As<IRepository>();
            IContainer container = builder.Build();
            IRepository repository  = container.Resolve<IRepository>();
            repository.Insert();

        }
    }
}
