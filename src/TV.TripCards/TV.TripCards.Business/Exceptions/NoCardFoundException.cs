using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV.TripCards.Business.Exceptions
{
    public class NoCardFoundException : Exception
    {
        public NoCardFoundException(string cardFromName) : base($"Карточка не найдена, пункт отправки: {cardFromName}")
        { }
    }
}
