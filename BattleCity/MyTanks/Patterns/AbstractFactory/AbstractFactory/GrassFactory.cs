namespace Tanks.Patterns
{
    public class GrassFactory : IAbstractFactory
    {
        public void CreateBlockSmallShort1(IGeneralObj[,] arr, int x, int y) =>
            BlockSmallShort1Grass3.CreateProduct(arr, x, y);

        public void CreateBlockSmallLong2(IGeneralObj[,] arr, int x, int y) =>
            BlockSmallLong2Grass3.CreateProduct(arr, x, y);

        public void CreateBlockBigShort3(IGeneralObj[,] arr, int x, int y) =>
            BlockBigShort3Grass3.CreateProduct(arr, x, y);

        public void CreateBlockBigLong4(IGeneralObj[,] arr, int x, int y) =>
            BlockBigLong4Grass3.CreateProduct(arr, x, y);

        public void CreateLineVertShort5(IGeneralObj[,] arr, int x, int y) =>
            LineVertShort5Grass3.CreateProduct(arr, x, y);

        public void CreateLineVertLong6(IGeneralObj[,] arr, int x, int y) =>
            LineVertLong6Grass3.CreateProduct(arr, x, y);

        public void CreateLineHorShort7(IGeneralObj[,] arr, int x, int y) =>
            LineHorShort7Grass3.CreateProduct(arr, x, y);

        public void CreateLineHorLong8(IGeneralObj[,] arr, int x, int y) =>
            LineHorLong8Grass3.CreateProduct(arr, x, y);

        public void CreateH9(IGeneralObj[,] arr, int x, int y) =>
            H9Grass3.CreateProduct(arr, x, y);

        public void CreateP10(IGeneralObj[,] arr, int x, int y) =>
            P10Grass3.CreateProduct(arr, x, y);

        public void CreateU11(IGeneralObj[,] arr, int x, int y) =>
            U11Grass3.CreateProduct(arr, x, y);
    }
}
