using System.Drawing;

namespace Tanks.Patterns
{
    public class ConcreateMyShot : CreateShot
    {
        protected override ShotAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj prev, char ch, int x, int y)
        {
            ShotCharacteristics sC = new ShotCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Shot,
                (int)EnumDamageMyTank.Easy,
                (int)EnumDefenceObj.Defenseless,
                (int)EnumMyShotSpeed.Slowly);

            return new MyShot(in sC, in prev, ref stK);
        }
    }

    public class ConcreateEnemyShotType1 : CreateShot
    {
        protected override ShotAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj prev, char ch, int x, int y)
        {
            ShotCharacteristics sC = new ShotCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Shot,
                (int)EnumDamageEnemyTank.Easy,
                (int)EnumDefenceObj.Defenseless,
                (int)EnumEnemyShotSpeed.Slowly);

            return new Shot(in sC, in prev, ref stK);
        }
    }

    public class ConcreateEnemyShotType2 : CreateShot
    {
        protected override ShotAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj prev, char ch, int x, int y)
        {
            ShotCharacteristics sC = new ShotCharacteristics(
                new Point(x, y),
                (char)EnumFieldChar.Shot,
                (int)EnumDamageEnemyTank.Easy,
                (int)EnumDefenceObj.Defenseless,
                (int)EnumEnemyShotSpeed.Fast);

            return new Shot(in sC, in prev, ref stK);
        }
    }
}