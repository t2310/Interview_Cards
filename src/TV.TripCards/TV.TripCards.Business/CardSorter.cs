using System.Collections.Generic;
using System.Linq;
using TV.TripCards.Business.Exceptions;
using TV.TripCards.Core;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Business
{
    public class CardSorter : ICardSorter
    {
        private readonly List<Card> _cards;
        public CardSorter(ICardRepository cardRepository)
        {
            _cards = cardRepository.GetAll();
        }

        public List<Card> GetSortedCards()
        {
            var result = new List<Card>();
            var cardDictionary = new Dictionary<string, Card>();

            // Сложность O(n)
            //
            foreach (var c in _cards)
            {
                cardDictionary.Add(c.From, c);
            }

            var firstCity = _cards.Select(x => x.From).Except(_cards.Select(x => x.To)).FirstOrDefault();
            if (firstCity == null)
                throw new CardsCycledException();

            var firstCard = cardDictionary[firstCity];
            result.Add(firstCard);

            var nextCity = firstCard.To;
            foreach (var t in _cards.Where(x => x.From != firstCity))
            {
                var nextCard = cardDictionary[nextCity];
                result.Add(nextCard);
                nextCity = nextCard.To;
            }

            return result;
        }

        private CardSorter()
        { }
    }
}
