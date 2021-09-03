using System.Drawing;

namespace Tanks.Patterns
{
    public abstract class CreateStatProd
    {
        protected abstract StaticAbstract FactoryMethod(int x, int y);

        public StaticAbstract CreateProduct(int x, int y) => FactoryMethod(x, y);
        public StaticAbstract CreateProduct(Point coordinate) => FactoryMethod(coordinate.X, coordinate.Y);
    }
}