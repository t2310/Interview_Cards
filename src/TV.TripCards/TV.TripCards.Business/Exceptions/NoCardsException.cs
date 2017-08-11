using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV.TripCards.Business.Exceptions
{
    public class NoCardsException : Exception
    {
        public NoCardsException() : base("Нет ни одной карточки")
        { }
    }
}
