using BlackJack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Croupier
    {
        private IInit _init;
        private IList<CardModel> _croupierCards;
        private IList<CardModel> _playerCards;

        private string _rules = "Blackjack hands are scored by their point total. " +
            "The hand with the highest total wins as long as it doesn't exceed 21; " +
            "a hand with a higher total than 21 is said to bust. Cards 2 through 10 " +
            "are worth their face value, and face cards (jack, queen, king) are also worth 10. " +
            "An ace's value is 11 unless this would cause the player to bust, in which case it is worth 1. " +
            " A hand in which an ace's value is counted as 11 is called a soft hand, " +
            "because it cannot be busted if the player draws another card.\r\n\r\nThe goal of each player is to beat " +
            "the dealer by having the higher, unbusted hand. Note that if the player busts he loses, even if the dealer also " +
            "busts (therefore Blackjack favors the dealer). If both the player and the dealer have the same point value, it is " +
            "called a \"push\", and neither player nor dealer wins the hand.";

        public Croupier(IInit init)
        {
            if (init == null) throw new ArgumentNullException(nameof(init), "Oi! Init is null!");
            _init = init;
            _playerCards= new List<CardModel>();
            _croupierCards= new List<CardModel>();
        }

        //TODO introduce the game rules -- done
        //TODO Deal Cards -- done
        //TODO reveal cards -- one per turn -- done
        //TODO count score
        //... what else? 
        public void IntroduceTheRules(string casinoName)
        {
            Console.WriteLine($"Welcome to the{casinoName}");
            Console.WriteLine("Press k to skip the talk: ");

            foreach (char c in _rules)
            {
                Console.Write(c);
                //Console.Beep((int)c*250, 25); This is evil... but fun...
                Thread.Sleep(15);
            }
            Console.Clear();
            Console.WriteLine(_rules);
        }

        public void DealCard(string name)
        {
            var hand = DetermineHand(name);
            var card = _init.Cards.ElementAt(CardShuffle());
            card.IsFaceUp = false;
            hand.Add(card);
            CardRevealer(hand);
            RemoveFromSet(card);
            ShowCard(hand, name);
        }

        private void CardRevealer(IList<CardModel> hand)
        {
            if (hand.Count >= 2)
            {
                hand[hand.Count - 2].IsFaceUp = true;
            }
            else return;
        }

        private void RemoveFromSet(CardModel card)
        {
            _init.Cards.Remove(card);
        }

        private int CardShuffle()
        {
            Random rand = new Random();
            int cardNo = rand.Next(_init.Cards.Count);
            return cardNo;
        }

        private IList<CardModel> DetermineHand(string name)
        {
            switch (name.ToLower())
            {
                case "player":
                    return _playerCards;
                case "croupier":
                    return _croupierCards;
            }
            return new List<CardModel>();
        }

        private void ShowCard(IList<CardModel> hand, string handOwner)
        {
            hand.Where(c => c.IsFaceUp == true).ToList().ForEach(c => Console.WriteLine($"{handOwner} Currently have: " +  c.Name));
        }
    }
}
