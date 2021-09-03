using System;

namespace Tanks.Patterns
{
    public class LoadStatistisc : IComand
    {
        private readonly ReceiverStatistics _stat;

        public LoadStatistisc(ReceiverStatistics stat) => _stat = stat;

        public void Execute()
        {
            _stat.LoadStatistics();
            GlobalParam.PrintLoadStatistisc(_stat);
            Console.ReadKey(true);
        }

        public void PrintCurYourself() => _stat.PrintCurLoadStatistics();

        public void PrintPrevYourself() => _stat.PrintPrevLoadStatistics();
    }
}