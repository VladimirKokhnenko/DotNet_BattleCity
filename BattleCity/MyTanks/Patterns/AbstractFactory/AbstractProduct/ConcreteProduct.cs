namespace Tanks.Patterns
{
    public static class BlockSmallShort1Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class BlockSmallLong2Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 8;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class BlockBigShort3Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + 4;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class BlockBigLong4Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 8;
            int uY = y;
            int dY = y + 4;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class LineVertShort5Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + (GlobalParam.HeightWorkSpace - 7) / 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class LineVertLong6Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + GlobalParam.HeightWorkSpace - 7;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class LineHorShort7Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + (GlobalParam.WidthWorkSpace - 2) / 2;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class LineHorLong8Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + GlobalParam.WidthWorkSpace - 2;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateConcreteWall().CreateProduct(j, i);
        }
    }

    public static class H9Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Concrete2.CreateProduct(arr, x, y);
            BlockSmallLong2Concrete2.CreateProduct(arr, x + 4, y + 6);
            LineVertShort5Concrete2.CreateProduct(arr, x + 12, y);
        }
    }

    public static class P10Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Concrete2.CreateProduct(arr, x, y);
            BlockSmallLong2Concrete2.CreateProduct(arr, x + 4, y);
            LineVertShort5Concrete2.CreateProduct(arr, x + 12, y);
        }
    }

    public static class U11Concrete2
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Concrete2.CreateProduct(arr, x, y);
            BlockSmallLong2Concrete2.CreateProduct(arr, x + 4, y + 13);
            LineVertShort5Concrete2.CreateProduct(arr, x + 12, y);
        }
    }
}