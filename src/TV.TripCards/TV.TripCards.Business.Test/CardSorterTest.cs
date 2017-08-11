
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV.TripCards.Business.Exceptions;
using TV.TripCards.Business.Test.DataContext;
using TV.TripCards.Core;
using Xunit;

namespace TV.TripCards.Business.Test
{
    public class CardSorterTest
    {
        /// <summary>
        /// Тест на случай зацикленных карточек
        /// </summary>
        [Fact]
        public void CardSorter_Throws_CardsCycledException()
        {
            var sorter = CreateSorter<CycledCardTestRepository>();

            Assert.Throws<CardsCycledException>(() => sorter.GetSortedCards());
        }
                
        /// <summary>
        /// Основной тест на работу алгоритма
        /// </summary>
        [Fact]
        public void CardSorter_Success()
        {
            ITestRepository rep = new CardTestRepository();
            var sorter = new CardModule(rep);

            var result = sorter.GetSortedCards();
            var expectedResult = rep.GetExpectedResult();
            
            for (int i = 0; i < result.Count; i++)
            {
                Assert.True(result[i].ToString() == expectedResult[i].ToString());
            }
        }

        /// <summary>
        /// Тест на пропущенную карточку
        /// </summary>
        [Fact]
        public void CardSorter_Throws_NoCardFound()
        {
            var sorter = CreateSorter<MissedCardTestRepository>();

            Assert.Throws<NoCardFoundException>(() => sorter.GetSortedCards());
        }

        private ICardSorter CreateSorter<T>() where T : class, ITestRepository, new()
        {
            ITestRepository rep = new T();
            var sorter = new CardModule(rep);

            return sorter;
        }
    }
}
