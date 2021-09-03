using System.Drawing;

namespace Tanks.Patterns
{
    public abstract class CreateMyTank
    {
        protected abstract MyTankAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y);

        public MyTankAbstract CreateProduct(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y)
        {
            return FactoryMethod(ref stK, in obj, ch, x, y);
        }

        public MyTankAbstract CreateProduct(
            ref StateKeeper stK, in IGeneralObj obj, char ch, Point coordinate)
        {
            return FactoryMethod(ref stK, in obj, ch, coordinate.X, coordinate.Y);
        }
    }

    public abstract class CreateEnemyTank
    {
        protected abstract TankEnemyAbstract FactoryMethod(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y);

        public TankEnemyAbstract CreateProduct(
            ref StateKeeper stK, in IGeneralObj obj, char ch, int x, int y)
        {
            return FactoryMethod(ref stK, in obj, ch, x, y);
        }
    }
}