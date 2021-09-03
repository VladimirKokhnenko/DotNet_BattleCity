namespace Tanks.Patterns
{
    public class ConcreteFactory : IAbstractFactory
    {
        public void CreateBlockSmallShort1(IGeneralObj[,] arr, int x, int y) =>
            BlockSmallShort1Concrete2.CreateProduct(arr, x, y);

        public void CreateBlockSmallLong2(IGeneralObj[,] arr, int x, int y) =>
            BlockSmallLong2Concrete2.CreateProduct(arr, x, y);

        public void CreateBlockBigShort3(IGeneralObj[,] arr, int x, int y) =>
            BlockBigShort3Concrete2.CreateProduct(arr, x, y);

        public void CreateBlockBigLong4(IGeneralObj[,] arr, int x, int y) =>
            BlockBigLong4Concrete2.CreateProduct(arr, x, y);

        public void CreateLineVertShort5(IGeneralObj[,] arr, int x, int y) =>
            LineVertShort5Concrete2.CreateProduct(arr, x, y);

        public void CreateLineVertLong6(IGeneralObj[,] arr, int x, int y) =>
            LineVertLong6Concrete2.CreateProduct(arr, x, y);

        public void CreateLineHorShort7(IGeneralObj[,] arr, int x, int y) =>
            LineHorShort7Concrete2.CreateProduct(arr, x, y);

        public void CreateLineHorLong8(IGeneralObj[,] arr, int x, int y) =>
            LineHorLong8Concrete2.CreateProduct(arr, x, y);

        public void CreateH9(IGeneralObj[,] arr, int x, int y) =>
            H9Concrete2.CreateProduct(arr, x, y);

        public void CreateP10(IGeneralObj[,] arr, int x, int y) =>
            P10Concrete2.CreateProduct(arr, x, y);

        public void CreateU11(IGeneralObj[,] arr, int x, int y) =>
            U11Concrete2.CreateProduct(arr, x, y);
    }
}
