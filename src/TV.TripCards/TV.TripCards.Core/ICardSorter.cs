using System.Collections.Generic;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Core
{
    public interface ICardSorter
    {
        List<Card> GetSortedCards();
    }
}
