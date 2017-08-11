using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Core
{
    public interface ITestRepository : ICardRepository
    {
        List<Card> GetExpectedResult();
    }
}
