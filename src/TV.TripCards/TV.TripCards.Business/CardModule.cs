using System;
using System.Collections.Generic;
using System.Linq;
using TV.TripCards.Business.Exceptions;
using TV.TripCards.Core;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Business
{
    /// <summary>
    /// Класс для работы с карточками
    /// </summary>
    public class CardModule : ICardSorter
    {
        private readonly List<Card> _cards;

        public CardModule(ICardRepository cardRepository)
        {
            _cards = cardRepository.GetAll();
        }

        public List<Card> GetSortedCards()
        {
            if (!_cards.Any())
                throw new NoCardsException();
            var result = new List<Card>();
            var cardDictionary = new Dictionary<string, Card>();

            // Формируем словарь из карточкек
            foreach (var c in _cards)
                cardDictionary.Add(c.From, c);

            // Берем карточку, на которую никто не ссылается и если такой нет выдаем ошибку
            var firstCity = _cards.Select(x => x.From).Except(_cards.Select(x => x.To)).FirstOrDefault();
            if (firstCity == null)
                throw new CardsCycledException();

            // Берем из словаря первую карточку и добавляем ее в результрующий список
            //
            if (!cardDictionary.TryGetValue(firstCity, out Card firstCard))
                throw new NoCardFoundException(firstCity);

            result.Add(firstCard);

            // Идем по цепочке карточек и добавляем их в резльтирующий список
            // 
            var nextCity = firstCard.To;
            foreach (var t in _cards.Where(x => x.From != firstCity))
            {
                if (!cardDictionary.TryGetValue(nextCity, out Card nextCard))
                    throw new NoCardFoundException(nextCity);

                result.Add(nextCard);
                nextCity = nextCard.To;
            }

            return result;
        }

        private CardModule()
        { }
    }
}
