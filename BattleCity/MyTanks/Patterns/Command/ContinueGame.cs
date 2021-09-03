namespace Tanks.Patterns
{
    public class ContinueGame : IComand
    {
        private readonly ReceiverGame _rec;

        public ContinueGame(ref ReceiverGame rec) => _rec = rec;

        public void Execute() => _rec.ActionContinueGame();

        public void PrintCurYourself() => _rec.PrintCurNameContinueGame();

        public void PrintPrevYourself() => _rec.PrintPrevNameContinueGame();
    }
}