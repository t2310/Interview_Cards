﻿using System.Collections.Generic;
using TV.TripCards.Core;
using TV.TripCards.Core.Model;

namespace TV.TripCards.Data.Mock
{
    /// <summary>
    /// Мок репозиторий для получения перепутнных карточек
    /// </summary>
    public class CardRepository : ICardRepository
    {
        public List<Card> GetAll()
        {
            return new List<Card>
            {
                new Card("Москва", "Пекин"),
                new Card("Пекин", "Самара"),
                new Card("Калининград", "Каир"),
                new Card("Самара", "Калининград"),
                new Card("Каир", "Сочи")
            };
        }
    }
}
