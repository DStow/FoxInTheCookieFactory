using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel.Exceptions
{
    public class CardInvalidValueException : ApplicationException
    {
        public CardInvalidValueException(int cardValue) : base(cardValue + " is not a valid card value!")
        {

        }
    }
}
