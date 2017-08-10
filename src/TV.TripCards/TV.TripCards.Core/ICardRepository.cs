using System.Collections.Generic;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Core
{
    public interface ICardRepository
    {
        List<Card> GetAll();
    }
}
