using System.Drawing;

namespace Tanks.Patterns
{
    public class ConcreateClearField : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.CanInstall,
                (int)EnumDefenceObj.Defenseless,
                true,
                false);
            return new ClearField(in o);
        }
    }

    public class ConcreateFonRight : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.FonRight,
                (char)EnumDefenceObj.WellKilled,
                false);
            return new FonRight(in o);
        }
    }

    public class ConcreateBorder : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Border,
                (int)EnumDefenceObj.WellKilled,
                false);
            return new Border(in o);
        }
    }

    public class ConcreateMyBase : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.CharBase,
                (int)EnumDefenceObj.Easy,
                false);
            return new MyBase(in o);
        }
    }

    public class ConcreateBrickWall : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Brick,
                (int)EnumDefenceObj.Easy,
                false);
            return new BrickWall(in o);
        }
    }

    public class ConcreateConcreteWall : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Concrete,
                (int)EnumDefenceObj.Heavy,
                false);
            return new ConcreteWall(in o);
        }
    }

    public class ConcreateGrassWall : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Concrete,
                (int)EnumDefenceObj.Defenseless,
                true);
            return new GrassWall(in o);
        }
    }

    public class ConcreateBonusLifeUp : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.LifeUp,
                (int)EnumDefenceObj.Defenseless,
                true,
                true,
                500,
                true);
            return new BonusLifeUp(in o);
        }
    }

    public class ConcreateBonusDefendedTheBase : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.DefendedTheBase,
                (int)EnumDefenceObj.Defenseless,
                true,
                true,
                500,
                true);
            return new BonusDefendedTheBase(in o);
        }
    }

    public class ConcreateBonusTankSpeedUp : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.TankSpeedUp,
                (int)EnumDefenceObj.Defenseless,
                true,
                true,
                500,
                true);
            return new BonusTankSpeedUp(in o);
        }
    }

    public class ConcreateBonusUpCountShots : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.UpCountShots,
                (int)EnumDefenceObj.Defenseless,
                true,
                true,
                500,
                true);
            return new BonusTankSpeedUp(in o);
        }
    }

    public class ConcreateBonusUpSpeedShot : CreateStatProd
    {
        protected override StaticAbstract FactoryMethod(int x, int y)
        {
            StaticObjectCharacteristics o = new StaticObjectCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.UpSpeedShot,
                (int)EnumDefenceObj.Defenseless,
                true,
                true,
                500,
                true);
            return new BonusUpSpeedShot(in o);
        }
    }
}