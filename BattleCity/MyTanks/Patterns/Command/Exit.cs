using System;
using System.Drawing;

namespace Tanks.Patterns
{
    [Serializable]
    public class ExceptionExit : Exception
    {
        public ExceptionExit(string message)
            : base(message) { }

        public ExceptionExit() { }

        public ExceptionExit(string message, Exception innerException)
            : base(message, innerException) { }

        protected ExceptionExit(
            System.Runtime.Serialization.SerializationInfo serializationInfo,
            System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }

    public class Exit : IComand
    {
        private readonly string _name;
        private readonly Point _coor;

        public Exit()
        {
            _name = "Exit";
            _coor = new Point(
                GlobalParam.WidthConsole / 2 - (_name.Length / 2), GlobalParam.IndexYExit);
        }

        public Point Coor => _coor;

        public void Execute()
        {
            if (GlobalParam.AreYouSure())
                throw new ExceptionExit("Bye Bye!!!");
        }

        public void PrintCurYourself() => GlobalParam.PrintMenuCurItems(Coor, _name);

        public void PrintPrevYourself() => GlobalParam.PrintMenuPrevItems(Coor, _name);
    }
}