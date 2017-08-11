using System.Collections.Generic;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Core
{
    /// <summary>
    /// Интерфейс сортировщика карточек
    /// </summary>
    public interface ICardSorter
    {
        List<Card> GetSortedCards();
    }
}
