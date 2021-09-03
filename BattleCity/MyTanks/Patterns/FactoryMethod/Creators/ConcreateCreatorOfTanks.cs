using System.Drawing;

namespace Tanks.Patterns
{
    public class ConcreateMyTank : CreateMyTank
    {
        protected override MyTankAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y)
        {
            TankCharacteristics d = new TankCharacteristics(
                new Point(x, y), ch,
                (int)EnumHP.OrdinaryTank,
                (int)EnumDamageMyTank.Easy,
                (int)EnumDefenceMyTank.Defenseless,
                (int)EnumMyTankSpeed.Slowly,
                (int)EnumTotal.TotalNull);
            return new MyTank(in d, in obj, ref stK);
        }
    }

    public class ConcreateEnemyTankType1 : CreateEnemyTank
    {
        protected override TankEnemyAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y)
        {
            TankCharacteristics d = new TankCharacteristics(
                new Point(x, y), ch,
                (int)EnumHP.OrdinaryTank,
                (int)EnumDamageEnemyTank.Easy,
                (int)EnumDefenceEnemyTank.Easy,
                (int)EnumEnemyTankSpeed.Slowly,
                (int)EnumTotal.TotalTank1);
            return new EnemyTankType1(in d, in obj, ref stK);
        }
    }

    public class ConcreateEnemyTankType2 : CreateEnemyTank
    {
        protected override TankEnemyAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y)
        {
            TankCharacteristics d = new TankCharacteristics(
                new Point(x, y), ch,
                (int)EnumHP.OrdinaryTank,
                (int)EnumDamageEnemyTank.Easy,
                (int)EnumDefenceEnemyTank.Easy,
                (int)EnumEnemyTankSpeed.Fast,
                (int)EnumTotal.TotalTank2);
            return new EnemyTankType2(in d, in obj, ref stK);
        }
    }

    public class ConcreateEnemyTankType3 : CreateEnemyTank
    {
        protected override TankEnemyAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y)
        {
            TankCharacteristics d = new TankCharacteristics(
                new Point(x, y), ch,
                (int)EnumHP.ImprovedTank,
                (int)EnumDamageEnemyTank.Easy,
                (int)EnumDefenceEnemyTank.Easy,
                (int)EnumEnemyTankSpeed.Fast,
                (int)EnumTotal.TotalTank3);
            return new EnemyTankType3(in d, in obj, ref stK);
        }
    }
}