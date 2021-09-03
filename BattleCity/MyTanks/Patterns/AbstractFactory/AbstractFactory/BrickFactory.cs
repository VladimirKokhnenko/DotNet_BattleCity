
namespace Tanks.Patterns
{
    public class BrickFactory : IAbstractFactory
    {
        public void CreateBlockSmallShort1(IGeneralObj[,] arr, int x, int y) =>
            BlockSmallShort1Brick1.CreateProduct(arr, x, y);

        public void CreateBlockSmallLong2(IGeneralObj[,] arr, int x, int y) =>
            BlockSmallLong2Brick1.CreateProduct(arr, x, y);

        public void CreateBlockBigShort3(IGeneralObj[,] arr, int x, int y) =>
            BlockBigShort3Brick1.CreateProduct(arr, x, y);

        public void CreateBlockBigLong4(IGeneralObj[,] arr, int x, int y) =>
            BlockBigLong4Brick1.CreateProduct(arr, x, y);

        public void CreateLineVertShort5(IGeneralObj[,] arr, int x, int y) =>
            LineVertShort5Brick1.CreateProduct(arr, x, y);

        public void CreateLineVertLong6(IGeneralObj[,] arr, int x, int y) =>
            LineVertLong6Brick1.CreateProduct(arr, x, y);

        public void CreateLineHorShort7(IGeneralObj[,] arr, int x, int y) =>
            LineHorShort7Brick1.CreateProduct(arr, x, y);

        public void CreateLineHorLong8(IGeneralObj[,] arr, int x, int y) =>
            LineHorLong8Brick1.CreateProduct(arr, x, y);

        public void CreateH9(IGeneralObj[,] arr, int x, int y) =>
            H9Brick1.CreateProduct(arr, x, y);

        public void CreateP10(IGeneralObj[,] arr, int x, int y) =>
            P10Brick1.CreateProduct(arr, x, y);

        public void CreateU11(IGeneralObj[,] arr, int x, int y) =>
            U11Brick1.CreateProduct(arr, x, y);
    }
}