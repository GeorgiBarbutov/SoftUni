using P01_BillsPaymentSystem.Data;
using System;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Seeder seeder = new Seeder();
                seeder.Seed(context);

                Console.Write("Id : ");
                int id = int.Parse(Console.ReadLine());

                UserPrinter printer = new UserPrinter();
                printer.Print(id, context);

                //Console.WriteLine();
                //BillsPayer.PayBills(1, 800, context);
                //printer.Print(1, context);

                //Console.WriteLine();
                //BillsPayer.PayBills(1, 800, context);
            }
        }
    }
}
