namespace Tanks.Patterns
{
    public class ResetStatistics : IComand
    {
        private readonly ReceiverStatistics _stat;

        public ResetStatistics(ReceiverStatistics stat) => _stat = stat;

        public void Execute() => _stat.ResetStatistics();

        public void PrintCurYourself() => _stat.PrintCurResetStatistics();

        public void PrintPrevYourself() => _stat.PrintPrevResetStatistics();
    }
}