using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class CardModel
    {
        public string? Name { get; set; }

        public string? Suit { get; set; }

        public int Value { get; set; }

        public bool IsFaceUp { get; set; }


    }
}
