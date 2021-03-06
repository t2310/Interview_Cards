﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV.TripCards.Core;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Business.Test.DataContext
{
    public class CycledCardTestRepository : ITestRepository
    {
        public List<Card> GetAll()
        {
            return new List<Card>
            {
                new Card("Москва", "Пекин"),
                new Card("Пекин", "Самара"),
                new Card("Калининград", "Москва"),
                new Card("Самара", "Калининград")
            };
        }

        public List<Card> GetExpectedResult()
        {
            throw new NotImplementedException();
        }
    }
}
