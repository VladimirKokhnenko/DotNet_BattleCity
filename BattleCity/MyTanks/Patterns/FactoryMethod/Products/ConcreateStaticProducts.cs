using System;

namespace Tanks.Patterns
{
    public class Border : StaticAbstract
    {
        public Border(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            throw new NotImplementedException();
        }
    }

    public class ClearField : StaticAbstract
    {
        public ClearField(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
        }
    }

    public class FonRight : StaticAbstract
    {
        public FonRight(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            throw new NotImplementedException();
        }
    }

    public class MyBase : StaticAbstract
    {
        public MyBase(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
            stK.BaseIsKill = true;
        }
    }

    public class BrickWall : StaticAbstract
    {
        public BrickWall(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
        }
    }

    public class ConcreteWall : StaticAbstract
    {
        public ConcreteWall(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
        }
    }

    public class GrassWall : StaticAbstract
    {
        public GrassWall(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK[CurPos.X, CurPos.Y] = new ConcreateGrassWall().CreateProduct(CurPos.X, CurPos.Y);
        }
    }

    public class BonusLifeUp : StaticAbstract
    {
        public BonusLifeUp(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
            stK.CountMyLives += 1;
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
            GlobalParam.DrawCountOfLives(stK);
        }
    }

    public class BonusDefendedTheBase : StaticAbstract
    {
        public BonusDefendedTheBase(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;

            for (int i = GlobalParam.LeftXOutPer; i < GlobalParam.RightXOutPer; i++)
            {
                stK[i, GlobalParam.UpYOutPer] = new ConcreateConcreteWall().CreateProduct(
                    i, GlobalParam.UpYOutPer);
                stK[i, GlobalParam.UpYOutPer].DrawObject();
            }

            for (int i = GlobalParam.UpYOutPer + 1; i < GlobalParam.DownYOutPer; i++)
            {
                for (int j = GlobalParam.LeftXOutPer; j < GlobalParam.LeftXOutPer + 2; j++)
                {
                    stK[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
                    stK[j, i].DrawObject();
                    stK[j + 5, i] = new ConcreateConcreteWall().CreateProduct(j + 5, i);
                    stK[j + 5, i].DrawObject();
                }
            }

            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
        }
    }

    public class BonusTankSpeedUp : StaticAbstract
    {
        public BonusTankSpeedUp(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;

            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);

            if (stK.MyTank.Speed - 5 > 0)
                stK.MyTank.Speed -= 5;
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
        }
    }

    public class BonusUpCountShots : StaticAbstract
    {
        public BonusUpCountShots(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;
            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);
            stK.MyTank.MaxCountShots += 1;
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
            GlobalParam.DrawCountOfShots(stK.MyTank.MaxCountShots, stK.MyTank.CountShots);
        }
    }

    public class BonusUpSpeedShot : StaticAbstract
    {
        public BonusUpSpeedShot(in StaticObjectCharacteristics o)
            : base(in o) { }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;

            stK[CurPos.X, CurPos.Y] = new ConcreateClearField().CreateProduct(CurPos.X, CurPos.Y);

            if (stK.MyTank.SpeedShot + 5 < (int)EnumMyShotSpeed.Slowly)
                stK.MyTank.SpeedShot += 5;
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
        }
    }
}