namespace Tanks.Patterns
{
    public static class BlockSmallShort1Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class BlockSmallLong2Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 8;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class BlockBigShort3Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + 4;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class BlockBigLong4Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 8;
            int uY = y;
            int dY = y + 4;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class LineVertShort5Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + (GlobalParam.HeightWorkSpace - 7) / 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class LineVertLong6Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + 4;
            int uY = y;
            int dY = y + GlobalParam.HeightWorkSpace - 7;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class LineHorShort7Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + (GlobalParam.WidthWorkSpace - 2) / 2;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class LineHorLong8Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            int lX = x;
            int rX = x + GlobalParam.WidthWorkSpace - 2;
            int uY = y;
            int dY = y + 2;

            for (int i = uY; i < dY; i++)
                for (int j = lX; j < rX; j++)
                    arr[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
        }
    }

    public static class H9Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Brick1.CreateProduct(arr, x, y);
            BlockSmallLong2Brick1.CreateProduct(arr, x + 4, y + 6);
            LineVertShort5Brick1.CreateProduct(arr, x + 12, y);
        }
    }

    public static class P10Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Brick1.CreateProduct(arr, x, y);
            BlockSmallLong2Brick1.CreateProduct(arr, x + 4, y);
            LineVertShort5Brick1.CreateProduct(arr, x + 12, y);
        }
    }

    public static class U11Brick1
    {
        public static void CreateProduct(IGeneralObj[,] arr, int x, int y)
        {
            LineVertShort5Brick1.CreateProduct(arr, x, y);
            BlockSmallLong2Brick1.CreateProduct(arr, x + 4, y + 13);
            LineVertShort5Brick1.CreateProduct(arr, x + 12, y);
        }
    }
}
