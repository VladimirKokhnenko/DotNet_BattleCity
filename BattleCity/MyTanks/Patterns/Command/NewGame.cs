namespace Tanks.Patterns
{
    public class NewGame : IComand
    {
        private readonly ReceiverGame _rec;

        public NewGame(ref ReceiverGame rec) => _rec = rec;

        public void Execute()
        {
            if (GlobalParam.AreYouSure())
                _rec.ActionNewGame();
        }

        public void PrintCurYourself() => _rec.PrintCurNameNewGame();

        public void PrintPrevYourself() => _rec.PrintPrevNameNewGame();
    }
}