using BlackJack;

internal class Program
{
    private static void Main(string[] args)
    {
        Init initGame = new Init();
        Random ran = new Random();
        //test
        Croupier croupier = new Croupier(initGame);

        //initGame.DisplayCards();

        //while (true)
        //{
        //    var ranCard = ran.Next(initGame.Cards.Count);
        //    Console.WriteLine(initGame.Cards[ranCard].Name);
        //    Thread.Sleep(200);
        //}

        //croupier.IntroduceTheRules("Casion Royale");
        croupier.DealCard("Player");
        croupier.DealCard("Player");
        croupier.DealCard("Croupier");
        croupier.DealCard("Croupier");
        croupier.DealCard("Player");
        croupier.DealCard("Player");
        croupier.DealCard("Croupier");
        croupier.DealCard("Croupier");

    }
}