using System;
using System.Linq;
using RandomGen;

namespace net_core_ef
{
    class Program
    {
        static void Main(string[] args)
        {
            OneWorkDbContext dbContext = new OneWorkDbContext();

            //for (int i = 0; i < 10; i++)
            //{

            //    dbContext.Users.Add(new User
            //    {
            //        Name = Gen.Random.Names.Full()(),
            //        TenantId =  CurrentTenant.TenantId

            //    });
            //}
            

            //dbContext.SaveChanges();


            Console.WriteLine(dbContext.Users.Count());   
        }
    }
}
