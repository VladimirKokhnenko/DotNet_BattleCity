using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

namespace Tanks.Patterns
{
    public class ReceiverGame
    {

#if DEBUG
        private const int TimeCreateEnemy = 2000;
#else
        private const int TimeCreateEnemy = 10000;
#endif

        private const Int64 TicksInMs = 10_000;

        private StateKeeper _stK;
        private List<ILevel> _level;
        private readonly string _nameNewGame;
        private Point _coorNameNewGame;
        private readonly string _nameContinueGame;
        private Point _coorNameContinueGame;
        private readonly ReceiverStatistics _saveStatistics;

        public ReceiverGame()
        {
            _stK = new StateKeeper();
            _saveStatistics = new ReceiverStatistics(_stK);

            _level = new List<ILevel>
            {
                new BuilderLevel1(ref _stK),
                new BuilderLevel2(ref _stK),
                new BuilderLevel3(ref _stK)
            };

            _nameNewGame = "New Game";
            _coorNameNewGame = new Point(
                GlobalParam.WidthConsole / 2 - (_nameNewGame.Length / 2), GlobalParam.IndexYNewGame);
            _nameContinueGame = "Continue Game";
            _coorNameContinueGame = new Point(
                GlobalParam.WidthConsole / 2 - (_nameContinueGame.Length / 2), GlobalParam.IndexYContinueGame);
        }

        private Int64 TimerForCreateEnemyTanks { get; set; }
        private bool IsHeCanCreateEnemyTanks
        {
            get => (DateTime.Now.Ticks - TimerForCreateEnemyTanks) / TicksInMs > TimeCreateEnemy;
        }

        public List<ILevel> Level { get => _level; set => _level = value; }
        public string NameNewGame { get => _nameNewGame; }
        public Point CoorNameNewGame { get => _coorNameNewGame; }
        public string NameContinueGame { get => _nameContinueGame; }
        public Point CoorNameContinueGame { get => _coorNameContinueGame; }
        public StateKeeper Stk { get => _stK; set => _stK = value; }

        public void ActionNewGame()
        {
            CreateLevel(ref _stK);
            ActionContinueGame();
        }

        public void ActionContinueGame()
        {
            if (_stK.IsNewGame)
            {
                GlobalParam.PrintSrartMap(ref _stK);
                GlobalParam.PrintRightFon(ref _stK);

                bool exit = false;

                while (!exit)
                {
                    if (_stK.GetTankArrGenl().Count != 0)
                    {
                        if (Console.KeyAvailable)
                            if (_stK.MyTank.CanHeMove)
                                MyMove(_stK.MyTank, ref exit);
                            else
                                Console.ReadKey(true);

                        GlobalParam.DrawCountOfShots(
                            _stK.MyTank.MaxCountShots, _stK.MyTank.CountShots);

                        for (int i = 0; i < _stK.GetShotArr().Count; i++)
                        {
                            if (_stK.GetShot(i).IsAlive)
                                _stK.GetShot(i)?.ShotMovement();
                            else
                                _stK.GetShot(i)?.KiLLYourself(ref _stK);
                        }

                        for (int i = 0; i < _stK.GetTankArrWorking().Count; i++)
                        {
                            if (_stK.GetTankArrWorking()[i].IsAlive &&
                                _stK.GetTankArrWorking()[i].IsHeInTheMap)
                            {
                                _stK.GetTankArrWorking()[i].TankMovement();
                            }
                        }

                        if (IsHeCanCreateEnemyTanks)
                        {
                            _stK.FillWorkingTankArr();
                            _stK.SetInMapEnemyTanks();
                            TimerForCreateEnemyTanks = DateTime.Now.Ticks;
                        }
                    }
                    else if (_stK.GetTankArrGenl().Count == 0 && _stK.CountMyLives > 0)
                    {
                        GlobalParam.PrintWinFon();
                        Thread.Sleep(1000);
                        _stK.GetShotArr().Clear();

                        if (_stK.CurLevel == Level.Count - 1)
                            _stK.CurLevel = 0;
                        else
                            _stK.CurLevel += 1;

                        Level[_stK.CurLevel].CreateLevel();
                        _stK.CountLevel += 1;
                        _stK.ScoresForLevel = 0;
                        GlobalParam.PrintNextMap(_stK);
                    }

                    if (_stK.CountMyLives == 0 || _stK.BaseIsKill)
                    {
                        GlobalParam.PrintLoseFon();
                        Thread.Sleep(1000);
                        GlobalParam.PrintInputName();

                        _stK.IsNewGame = false;
                        string str = Console.ReadLine();
                        _saveStatistics.SaveStatistics(str);
                        break;
                    }
                }
            }
            else
            {
                GlobalParam.PrintSorryButCurrentSessionDoesNotExist();
            }
        }

        private void CreateLevel(ref StateKeeper _stK)
        {
            _stK.ResetGame();
            Level[_stK.CurLevel].CreateLevel();
            _stK.SetStartFourTanks();
            _stK.IsNewGame = true;
            _stK.CountMyLives = 3;
            _stK.BaseIsKill = false;
            TimerForCreateEnemyTanks = DateTime.Now.Ticks;
        }

        public static void MyMove(MyTankAbstract tank, ref bool exit)
        {
            var keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    tank.TankMovement(
                        tank.CurPos.X - 1, tank.CurPos.Y, (char)EnumTankChar.TankLeft);
                    tank.TimerForMove = DateTime.Now.Ticks;
                    break;
                case ConsoleKey.RightArrow:
                    tank.TankMovement(
                        tank.CurPos.X + 1, tank.CurPos.Y, (char)EnumTankChar.TankRight);
                    tank.TimerForMove = DateTime.Now.Ticks;
                    break;
                case ConsoleKey.UpArrow:
                    tank.TankMovement(
                        tank.CurPos.X, tank.CurPos.Y - 1, (char)EnumTankChar.TankFront);
                    tank.TimerForMove = DateTime.Now.Ticks;
                    break;
                case ConsoleKey.DownArrow:
                    tank.TankMovement(
                        tank.CurPos.X, tank.CurPos.Y + 1, (char)EnumTankChar.TankBack);
                    tank.TimerForMove = DateTime.Now.Ticks;
                    break;
                case ConsoleKey.Spacebar:
                    tank.GenerateShot();
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }

        public void PrintPrevNameNewGame()
        {
            GlobalParam.PrintMenuPrevItems(CoorNameNewGame, NameNewGame);
        }

        public void PrintCurNameNewGame()
        {
            GlobalParam.PrintMenuCurItems(CoorNameNewGame, NameNewGame);
        }

        public void PrintPrevNameContinueGame()
        {
            GlobalParam.PrintMenuPrevItems(CoorNameContinueGame, NameContinueGame);
        }

        public void PrintCurNameContinueGame()
        {
            GlobalParam.PrintMenuCurItems(CoorNameContinueGame, NameContinueGame);
        }
    }
}