namespace Tanks.Patterns
{
    public static class BlockSmallShort1Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class BlockSmallLong2Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 8;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class BlockBigShort3Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + 4;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class BlockBigLong4Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 8;
            int uY = y;
            int dY = y + 4;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class LineVertShort5Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + (GlobalParam.HeightWorkSpace - 7) / 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class LineVertLong6Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + GlobalParam.HeightWorkSpace - 7;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class LineHorShort7Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + (GlobalParam.WidthWorkSpace - 2) / 2;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class LineHorLong8Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + GlobalParam.WidthWorkSpace - 2;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateGrassWall().CreateProduct(j, i);
        }
    }

    public static class H9Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Grass3.CreateProduct(arr, x, y);
            BlockSmallLong2Grass3.CreateProduct(arr, x + 4, y + 6);
            LineVertShort5Grass3.CreateProduct(arr, x + 12, y);
        }
    }

    public static class P10Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Grass3.CreateProduct(arr, x, y);
            BlockSmallLong2Grass3.CreateProduct(arr, x + 4, y);
            LineVertShort5Grass3.CreateProduct(arr, x + 12, y);
        }
    }

    public static class U11Grass3
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Grass3.CreateProduct(arr, x, y);
            BlockSmallLong2Grass3.CreateProduct(arr, x + 4, y + 13);
            LineVertShort5Grass3.CreateProduct(arr, x + 12, y);
        }
    }
}