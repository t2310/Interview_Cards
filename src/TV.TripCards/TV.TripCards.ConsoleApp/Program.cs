using Autofac;
using System;
using TV.TripCards.Business;
using TV.TripCards.Business.Exceptions;
using TV.TripCards.Core;
using TV.TripCards.Data.Mock;

namespace TV.TripCards.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CardSorter>().As<ICardSorter>();
            builder.RegisterType<CardRepository>().As<ICardRepository>();

            var container = builder.Build();

            var sorter = container.Resolve<ICardSorter>();

            Console.WriteLine($"{Environment.NewLine} **************** {Environment.NewLine}");

            try
            {
                var result = sorter.GetSortedCards();
                foreach (var r in sorter.GetSortedCards())
                {
                    Console.Write($"{r.ToString()}");
                }
                Console.WriteLine();
            }
            catch (CardsCycledException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
