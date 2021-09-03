using System;

namespace Tanks.Patterns
{
    public class Shot : ShotAbstract
    {
        public Shot(
            in ShotCharacteristics sC, in IGeneralObj prev, ref StateKeeper stK)
            : base(sC, prev, ref stK) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }
    }

    public class MyShot : ShotAbstract
    {
        public MyShot(
            in ShotCharacteristics sC, in IGeneralObj prev, ref StateKeeper stK)
            : base(sC, prev, ref stK) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }
    }
}