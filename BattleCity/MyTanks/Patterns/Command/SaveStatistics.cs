using System;

namespace Tanks.Patterns
{
    public class SaveStatistics
    {
        private readonly ReceiverStatistics _stat;

        public SaveStatistics(ReceiverStatistics stat) => _stat = stat;

        public string UserName { get; set; }

        public void PrintInputSaveStatistics()
        {
            GlobalParam.PrintInputName();
            UserName = Console.ReadLine();

            _stat.SaveStatistics(UserName);
        }
    }
}