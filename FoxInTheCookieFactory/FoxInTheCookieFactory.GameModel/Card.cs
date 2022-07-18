﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoxInTheCookieFactory.GameModel
{
    public class Card
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= 12 || value <= 0)
                    throw new Exceptions.CardInvalidValueException(value);

                _value = value;
            }
        }

        public Enumeration.CardSuitEnum Suit { get; set; }

        public Card(int value, Enumeration.CardSuitEnum suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
