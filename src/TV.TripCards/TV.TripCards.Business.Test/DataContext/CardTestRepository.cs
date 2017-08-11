using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV.TripCards.Core;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Business.Test.DataContext
{
    public class CardTestRepository : ITestRepository
    {
        public List<Card> GetAll()
        {
            return new List<Card>
            {
                new Card("Москва", "Пекин"),
                new Card("Пекин", "Самара"),
                new Card("Калининград", "Каир"),
                new Card("Самара", "Калининград")
            };
        }

        public List<Card> GetExpectedResult()
        {
            return new List<Card>
            {
                new Card("Москва", "Пекин"),
                new Card("Пекин", "Самара"),
                new Card("Самара", "Калининград"),
                new Card("Калининград", "Каир"),
            };
        }
    }
}
