using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTutorial.App
{
    class Program
    {

        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {

            // Create your builder.
            var builder = new ContainerBuilder();

            //register interfaces and their concrete types to inject
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();

            // The WriteDate method is where we'll make use
            // of our dependency injection. We'll define that
            // in a bit.
            WriteDate();

            Console.WriteLine("Terminating...");
            Console.ReadLine();
        }

        private static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }

    }
}
