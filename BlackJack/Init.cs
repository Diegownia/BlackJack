using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Interfaces;

namespace BlackJack
{
    public class Init : IInit
    {
        private IList<CardModel>? _cards;

        public Init()
        {
            try
            {
                _cards = new List<CardModel>();
                GenerateSimpleCards();
                GenerateNamedCards();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IList<CardModel> Cards
        {
            get => _cards;
        }

        public void DisplayCards()
        {
            _cards?.ToList().ForEach(card => Console.WriteLine("Name: " + card.Name + " Suit: " + card.Suit));
        }

        private IList<CardModel> BetterSeed(string name, string suit, int value)
        {
            _cards.Add(new CardModel { Name = name, Value = value, Suit = suit });
            return _cards;
        }

        private void GenerateSimpleCards()
        {
            for (var s = 0; s <= 3; s++)
            {
                for (var n = 2; n <= 10; n++)
                {
                    BetterSeed(n.ToString(), AssignSuit(s), n);
                }
            }
        }

        private string AssignSuit(int suitID)
        {
            switch (suitID)
            {
                case 0:
                    return "Hearts";
                case 1:
                    return "Diamonds";
                case 2:
                    return "Clubs";
                case 3:
                    return "Spades";
                default:
                    return "Invalid";
            }
        }

        private void GenerateNamedCards()
        {
            for (var nc = 0; nc <= 3; nc++)
            {
                BetterSeed("Ace", AssignSuit(nc), 1);
                BetterSeed("Jack", AssignSuit(nc), 10);
                BetterSeed("Queen", AssignSuit(nc), 10);
                BetterSeed("King", AssignSuit(nc), 10);
            }
        }
    }
}
