using System;
using System.Drawing;

namespace Tanks.Patterns
{
    public class MyTank : MyTankAbstract
    {
        public MyTank(in TankCharacteristics d, in IGeneralObj obj, ref StateKeeper stK)
            : base(d, obj, ref stK)
        {
            RateOfFire = (int)EnumMyRateOfFire.Slowly;
            TimerForShot = DateTime.Now.Ticks;
        }

        public override ShotAbstract GiveAShot(int x, int y)
        {
            ShotAbstract shot = new ConcreateMyShot().CreateProduct(
              ref _stK, _stK[x, y], (char)EnumFieldChar.Shot, x, y);
            if (shot.Speed - SpeedShot > 0)
                shot.Speed -= SpeedShot;
            return shot;
        }

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            IsAlive = false;
            Point tmpP = new Point(CurPos.X, CurPos.Y);
            IGeneralObj prev = GetCopyPrev();
            prev.CurPos = new Point(tmpP.X, tmpP.Y);
            stK[tmpP] = prev;

            int tmpLives = stK.CountMyLives - 1;
            stK.SetMyTank(new ConcreateMyTank().CreateProduct(ref stK,
                new ConcreateClearField().CreateProduct(GlobalParam.StartCoorMyTank),
                (char)EnumTankChar.TankFront,
                GlobalParam.StartCoorMyTank));
            stK.CountMyLives = tmpLives;
            GlobalParam.DrawCountOfLives(stK);
        }
    }

    public class EnemyTankType1 : TankEnemyAbstract
    {
        public EnemyTankType1(in TankCharacteristics d, in IGeneralObj obj, ref StateKeeper stK)
            : base(d, obj, ref stK)
        {
            RateOfFire = (int)EnumEnemyRateOfFire.Slowly;
            TimerForShot = DateTime.Now.Ticks;
        }

        public override ShotAbstract GiveAShot(int x, int y) => new ConcreateEnemyShotType1().CreateProduct(
            ref _stK, _stK[x, y], (char)EnumFieldChar.Shot, x, y);

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            IsAlive = false;
            Point tmpP = new Point(CurPos.X, CurPos.Y);
            IGeneralObj prev = GetCopyPrev();
            prev.CurPos = new Point(tmpP.X, tmpP.Y);
            stK[tmpP] = prev;
            stK.RemoveTank(this);
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;

            GlobalParam.DrawCountOfEnemy(stK.GetTankArrGenl().Count);
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);

            GlobalParam.DrawGeneralScores(stK.GeneralScores);
        }
    }

    public class EnemyTankType2 : TankEnemyAbstract
    {
        public EnemyTankType2(in TankCharacteristics d, in IGeneralObj obj, ref StateKeeper stK)
            : base(d, obj, ref stK)
        {
            RateOfFire = (int)EnumEnemyRateOfFire.Slowly;
            TimerForShot = DateTime.Now.Ticks;
        }

        public override ShotAbstract GiveAShot(int x, int y) => new ConcreateEnemyShotType1().CreateProduct(
            ref _stK, _stK[x, y], (char)EnumFieldChar.Shot, x, y);

        public override void DrawObject()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            IsAlive = false;
            Point tmpP = new Point(CurPos.X, CurPos.Y);
            IGeneralObj prev = GetCopyPrev();
            prev.CurPos = new Point(tmpP.X, tmpP.Y);
            stK[tmpP] = prev;
            stK.RemoveTank(this);
            CreateBonus();
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;

            GlobalParam.DrawCountOfEnemy(stK.GetTankArrGenl().Count);
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
        }
    }

    public class EnemyTankType3 : TankEnemyAbstract
    {
        public EnemyTankType3(in TankCharacteristics d, in IGeneralObj obj, ref StateKeeper stK)
            : base(d, obj, ref stK)
        {
            RateOfFire = (int)EnumEnemyRateOfFire.Fast;
            TimerForShot = DateTime.Now.Ticks;
        }

        public override ShotAbstract GiveAShot(int x, int y) => new ConcreateEnemyShotType2().CreateProduct(
            ref _stK, _stK[x, y], (char)EnumFieldChar.Shot, x, y);

        public override void DrawObject()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(CurPos.X, CurPos.Y);
            Console.Write(FieldChar);
        }

        public override void KiLLYourself(ref StateKeeper stK)
        {
            IsAlive = false;
            Point tmpP = new Point(CurPos.X, CurPos.Y);
            IGeneralObj prev = GetCopyPrev();
            prev.CurPos = new Point(tmpP.X, tmpP.Y);
            stK[tmpP] = prev;
            stK.RemoveTank(this);
            CreateBonus();
            stK.GeneralScores += Total;
            stK.ScoresForLevel += Total;

            GlobalParam.DrawCountOfEnemy(stK.GetTankArrGenl().Count);
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);

            GlobalParam.DrawGeneralScores(stK.GeneralScores);
        }
    }
}