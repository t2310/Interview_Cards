using System;

namespace TV.TripCards.Core.Model
{
    public class Card
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public Card(string from, string to)
        {
            From = from;
            To = to;
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $" {From} -> {To} ";
        }
    }
}
