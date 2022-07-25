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

        public override string ToString()
        {
            return Enum.GetName(typeof(Enumeration.CardSuitEnum), Suit) + " " + Value.ToString() + (IsSpecialCard() ? " (" + GetSpecialCardName() + ")" : "");
        }

        public bool IsSpecialCard()
        {
            List<int> specialValues = new List<int>(new int[] { 1, 3, 5, 7, 9, 11 });

            return specialValues.Contains(Value);
        }

        public string GetSpecialCardName()
        {
            switch (Value)
            {
                case 1: return "Swan";
                case 3: return "Fox";
                case 5: return "Woodcutter";
                case 7: return "Treasure";
                case 9: return "Witch";
                case 11: return "Monarch";
            }

            return null;
        }
    }
}
