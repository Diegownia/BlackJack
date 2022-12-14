namespace BlackJack.Interfaces
{
    public interface IInit
    {
        IList<CardModel> Cards { get; }

        void DisplayCards();
    }
}