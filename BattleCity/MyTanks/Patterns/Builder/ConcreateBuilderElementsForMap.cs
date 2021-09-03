namespace Tanks.Patterns
{
    public class ConcreateBuilderElementsForMap : IBuilder
    {
        private readonly IGeneralObj[,] _map;

        public ConcreateBuilderElementsForMap(IGeneralObj[,] map)
        {
            _map = map;
        }

        private void BuildInnerPerimeter()
        {
            for (int i = GlobalParam.UpYBase; i < GlobalParam.DownYBase; i++)
                for (int j = GlobalParam.LeftXBase; j < GlobalParam.RightXBase; j++)
                    _map[j, i] = new ConcreateMyBase().CreateProduct(j, i);
        }

        private void BuildOuterPerimeter()
        {
            for (int i = GlobalParam.LeftXOutPer; i < GlobalParam.RightXOutPer; i++)
            {
                _map[i, GlobalParam.UpYOutPer] =
                      new ConcreateBrickWall().CreateProduct(i, GlobalParam.UpYOutPer);
            }

            for (int i = GlobalParam.UpYOutPer + 1; i < GlobalParam.DownYOutPer; i++)
            {
                for (int j = GlobalParam.LeftXOutPer; j < GlobalParam.LeftXOutPer + 2; j++)
                {
                    _map[j, i] = new ConcreateBrickWall().CreateProduct(j, i);
                    _map[j + 5, i] = new ConcreateBrickWall().CreateProduct(j + 5, i);
                }
            }
        }

        public void BuildBase()
        {
            BuildInnerPerimeter();
            BuildOuterPerimeter();
        }

        public void BuildClearFon()
        {
            for (int i = 0; i < GlobalParam.HeightConsole; i++)
                for (int j = 0; j < GlobalParam.WidthConsole; j++)
                    _map[j, i] = new ConcreateClearField().CreateProduct(j, i);
        }

        public void BuildClearFonForYouWon()
        {
            for (int i = 0; i < GlobalParam.HeightConsole; i++)
                for (int j = 0; j < GlobalParam.WidthConsole; j++)
                    _map[j, i] = new ConcreateClearField().CreateProduct(j, i);
        }

        public void BuildBorder()
        {
            for (int i = 0; i < GlobalParam.WidthWorkSpace; i++)
            {
                _map[i, 0] = new ConcreateBorder().CreateProduct(i, 0);
                _map[i, GlobalParam.HeightWorkSpace - 1] =
                    new ConcreateBorder().CreateProduct(i, GlobalParam.HeightWorkSpace - 1);
            }

            for (int i = 0; i < GlobalParam.HeightWorkSpace; i++)
            {
                _map[0, i] = new ConcreateBorder().CreateProduct(0, i);
                _map[GlobalParam.WidthWorkSpace - 1, i] =
                    new ConcreateBorder().CreateProduct(GlobalParam.WidthWorkSpace - 1, i);
            }

            for (int i = 0; i < GlobalParam.HeightRightFon; i++)
            {
                for (int j = GlobalParam.BeginRightFon; j < GlobalParam.EndRightFon; j++)
                {
                    if (j == GlobalParam.BeginRightFon || j == GlobalParam.EndRightFon - 1 ||
                        i == 0 || i == GlobalParam.HeightRightFon - 1)
                    {
                        _map[j, i] = new ConcreateFonRight().CreateProduct(j, i);
                    }
                }
            }
        }

        public void BuildShell()
        {
            BuildClearFon();
            BuildBorder();
            BuildBase();
        }
    }
}