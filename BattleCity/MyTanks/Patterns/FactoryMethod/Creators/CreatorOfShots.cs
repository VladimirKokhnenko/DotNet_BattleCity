namespace Tanks.Patterns
{
    public abstract class CreateShot
    {
        protected abstract ShotAbstract FactoryMethod(ref StateKeeper stK, in IGeneralObj prev, char ch, int x, int y);

        public ShotAbstract CreateProduct(ref StateKeeper stK, in IGeneralObj prev, char ch, int x, int y)
        {
            return FactoryMethod(ref stK, in prev, ch, x, y);
        }
    }
}