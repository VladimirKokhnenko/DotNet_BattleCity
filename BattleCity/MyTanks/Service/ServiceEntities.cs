using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks.Patterns
{
    public static class GlobalParam
    {
        private delegate void PrintButton();

        public static int WidthConsole = 158;
        public static int HeightConsole = 38;
        public static int CenterConsoleX = WidthConsole / 2;

        public static int WidthWorkSpace = 158 - 20;
        public static int HeightWorkSpace = HeightConsole;
        public static int CenterWorkSpaceX = WidthWorkSpace / 2;

        public static int BeginRightFon = WidthWorkSpace;
        public static int EndRightFon = WidthConsole;
        public static int HeightRightFon = HeightConsole;

        public static int LeftXBase = CenterWorkSpaceX - 1;
        public static int RightXBase = CenterWorkSpaceX + 2;
        public static int UpYBase = HeightWorkSpace - 2;
        public static int DownYBase = HeightWorkSpace - 1;

        public static int LeftXOutPer = LeftXBase - 2;
        public static int RightXOutPer = RightXBase + 2;
        public static int UpYOutPer = UpYBase - 1;
        public static int DownYOutPer = HeightWorkSpace - 1;

        public static int IndexYNewGame = GlobalParam.HeightWorkSpace / 2 - 1;
        public static int IndexYContinueGame = GlobalParam.HeightWorkSpace / 2;
        public static int IndexYStatistics = GlobalParam.HeightWorkSpace / 2 + 1;
        public static int IndexYResetStatistics = GlobalParam.HeightWorkSpace / 2 + 2;
        public static int IndexYExit = GlobalParam.HeightWorkSpace / 2 + 3;

        public static Point StartCoorMyTank = new Point(LeftXOutPer - 2, DownYOutPer - 1);
        public static Point StartCoorEnemyFirst = new Point(2, 1);
        public static Point StartCoorEnemySecond = new Point(CenterWorkSpaceX / 3 * 2, 1);
        public static Point StartCoorEnemyThird = new Point(CenterWorkSpaceX / 3 * 4, 1);
        public static Point StartCoorEnemyFourth = new Point(WidthWorkSpace - 3, 1);

        public static bool AreYouSure()
        {
            PrintEmptyCenter();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            string question = "Are you sure?";

            Console.SetCursorPosition(
                GlobalParam.WidthConsole / 2 - question.Length / 2, GlobalParam.HeightConsole / 2);

            Console.Write(question);


            string yes = "Yes";
            string no = "No";

            int xForYes = GlobalParam.WidthConsole / 2 - question.Length / 2;
            int xForNo = GlobalParam.WidthConsole / 2 + question.Length / 2 - no.Length;
            int y = GlobalParam.HeightConsole / 2 + 1;

            List<PrintButton> printButtons = new List<PrintButton>
            {
                () =>
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xForYes, y);
                        Console.Write(yes);
                    },
                () =>
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(xForNo, y);
                        Console.Write(no);
                    },
                () =>
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xForNo, y);
                        Console.Write(no);
                    },
                () =>
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xForYes, y);
                        Console.Write(yes);
                    }
            };

            return AnswerUser(printButtons);
        }

        private static bool AnswerUser(List<PrintButton> printButtons)
        {
            Action doIt;
            int curSel = 0;

            doIt = () =>
            {
                if (curSel == 0)
                    curSel = 1;
                else
                    curSel = 0;

                printButtons[curSel]();
                printButtons[curSel + 2]();
            };


            printButtons[0]();
            printButtons[2]();

            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        doIt();
                        break;
                    case ConsoleKey.RightArrow:
                        doIt();
                        break;
                    case ConsoleKey.UpArrow:
                        doIt();
                        break;
                    case ConsoleKey.DownArrow:
                        doIt();
                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, 0);
                        return curSel == 0;
                    case ConsoleKey.Spacebar:
                        Console.SetCursorPosition(0, 0);
                        return curSel == 0;
                    case ConsoleKey.Escape:
                        Console.SetCursorPosition(0, 0);
                        return false;
                }
            }
        }

        public static void PrintStatisticsHaveBeenReset()
        {
            GlobalParam.PrintEmptyCenter();

            string str = "Statistics have beeb reset";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(
                GlobalParam.WidthConsole / 2 - str.Length / 2, GlobalParam.HeightConsole / 2);
            Console.Write(str);
            Console.SetCursorPosition(0, 0);
        }

        public static void DrawGeneralScores(int generalScores)
        {
            string str = "General Scores";
            int x = str.Length / 2;

            Console.SetCursorPosition(GlobalParam.BeginRightFon +
                (GlobalParam.EndRightFon - GlobalParam.BeginRightFon) / 2 - x, 2);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(str);

            x = generalScores.ToString().Length / 2;
            Console.SetCursorPosition(GlobalParam.BeginRightFon +
                (GlobalParam.EndRightFon - GlobalParam.BeginRightFon) / 2 - x, 3);
            Console.Write(generalScores);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintSorryButCurrentSessionDoesNotExist()
        {
            GlobalParam.PrintEmptyCenter();

            string str = "Sorry, but the current session does not exist";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(
                GlobalParam.WidthConsole / 2 - str.Length / 2, GlobalParam.HeightConsole / 2);

            Console.Write(str);
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }

        public static void DrawScoresForLevel(int scoresForLevel)
        {
            string str = "Scores For Level";
            int x = str.Length / 2;
            int curCorForPrintScore = 6;

            Console.SetCursorPosition(
                GlobalParam.BeginRightFon + (GlobalParam.EndRightFon - GlobalParam.BeginRightFon) / 2 - x, 5);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(str);

            for (int i = GlobalParam.BeginRightFon + 1; i < GlobalParam.EndRightFon - 1; i++)
            {
                Console.SetCursorPosition(i, curCorForPrintScore);
                Console.Write(" ");
            }

            x = scoresForLevel.ToString().Length / 2;
            Console.SetCursorPosition(
                GlobalParam.BeginRightFon +
                (GlobalParam.EndRightFon - GlobalParam.BeginRightFon) / 2 - x,
                curCorForPrintScore);

            Console.Write(scoresForLevel);
        }

        public static void DrawLevel(int level)
        {
            string str = "Level";
            int x = str.Length + 6;

            Console.SetCursorPosition(GlobalParam.BeginRightFon + 2, 9);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(str);

            Console.SetCursorPosition(GlobalParam.BeginRightFon + x, 9);
            Console.Write(level + 1);
            Console.SetCursorPosition(0, 0);
        }

        public static void DrawCountOfEnemy(int num)
        {
            string str = "Enemies";
            int x = str.Length + 4;

            Console.SetCursorPosition(GlobalParam.BeginRightFon + 2, 11);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(str);

            Console.SetCursorPosition(GlobalParam.BeginRightFon + x, 11);
            Console.Write(num + " ");
            Console.SetCursorPosition(0, 0);
        }

        public static void DrawCountOfShots(int max, int fact)
        {
            string str = "Shots";
            int x = str.Length + 6;
            int result = max - fact;

            Console.SetCursorPosition(GlobalParam.BeginRightFon + 2, 13);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(str);

            Console.SetCursorPosition(GlobalParam.BeginRightFon + x, 13);
            Console.Write(result);
            Console.SetCursorPosition(0, 0);
        }

        public static void DrawCountOfLives(StateKeeper stK)
        {
            string str = "Lives";
            int x = str.Length + 6;

            Console.SetCursorPosition(GlobalParam.BeginRightFon + 2, 15);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(str);

            Console.SetCursorPosition(GlobalParam.BeginRightFon + x, 15);
            Console.Write(stK.CountMyLives);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintSrartMap(ref StateKeeper stK)
        {
            foreach (var item in stK.GetMasterArr())
                item.DrawObject();
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintNextMap(StateKeeper stK)
        {
            int startX = 1;
            int endX = GlobalParam.WidthWorkSpace - 1;
            int startY = 1;
            int endY = GlobalParam.HeightWorkSpace - 1;

            Console.BackgroundColor = ConsoleColor.Yellow;

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {
                    stK[j, i].DrawObject();
                }
            }

            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawCountOfEnemy(stK.CountTanksInTheGenArr);
            GlobalParam.DrawLevel(stK.CountLevel);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintRightFon(ref StateKeeper stK)
        {
            Console.BackgroundColor = ConsoleColor.Gray;

            int stX = GlobalParam.BeginRightFon + 1;
            int endX = GlobalParam.EndRightFon - 1;
            int stY = 1;
            int endY = GlobalParam.HeightRightFon - 1;

            for (int i = stY; i < endY; i++)
            {
                for (int j = stX; j < endX; j++)
                {
                    if (j != GlobalParam.BeginRightFon || j != GlobalParam.EndRightFon - 1 ||
                        i != 0 || i != GlobalParam.HeightRightFon - 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                }
            }

            PrintCurrentInformation(stK);
        }

        public static void PrintCurrentInformation(StateKeeper stK)
        {
            GlobalParam.DrawLevel(stK.CountLevel);
            GlobalParam.DrawGeneralScores(stK.GeneralScores);
            GlobalParam.DrawScoresForLevel(stK.ScoresForLevel);
            GlobalParam.DrawCountOfEnemy(stK.CountTanksInTheGenArr);
            GlobalParam.DrawCountOfShots(stK.MyTank.MaxCountShots, stK.MyTank.CountShots);
            GlobalParam.DrawCountOfLives(stK);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintWinFon()
        {
            PrintEmptyCenter();

            Console.ForegroundColor = ConsoleColor.Red;

            string str = "You Won!!!";

            Console.SetCursorPosition(
                GlobalParam.WidthWorkSpace / 2 - str.Length / 2, GlobalParam.HeightWorkSpace / 2);
            Console.Write(str);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintLoseFon()
        {
            PrintEmptyCenter();

            Console.ForegroundColor = ConsoleColor.Red;

            string str = "You Lose!!!";

            Console.SetCursorPosition(
                GlobalParam.WidthWorkSpace / 2 - str.Length / 2, GlobalParam.HeightWorkSpace / 2);
            Console.Write(str);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintInputName()
        {
            PrintEmptyCenter();

            Console.ForegroundColor = ConsoleColor.Red;

            string str = "Please enter the your name: ";

            Console.SetCursorPosition(
                GlobalParam.WidthWorkSpace / 2 - str.Length / 3 * 2, GlobalParam.HeightWorkSpace / 2);
            Console.Write(str);
        }

        public static void PrintLoadStatistisc(ReceiverStatistics stat)
        {
            PrintEmptyCenter();

            const int hight = 10;
            const int length = 20;

            int x = GlobalParam.WidthConsole / 2 - length / 2;
            int y = GlobalParam.HeightConsole / 2 - hight / 2;


            for (int i = 0; i < hight; i++)
            {
                if (i % 2 == 0)
                    Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + i);

                for (int j = 0; j < length; j++)
                    Console.Write(" ");
                Console.SetCursorPosition(x, y + i);
                Console.Write(stat.Statistics[i].Value);
                Console.SetCursorPosition(x + length - stat.Statistics[i].Key.ToString().Length, y + i);
                Console.Write(stat.Statistics[i].Key);
            }
        }

        public static void PrintMenu(List<IComand> comand)
        {
            int startX = 0;
            int endX = GlobalParam.WidthConsole;
            int startY = 0;
            int endY = GlobalParam.HeightConsole;

            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }

            for (int i = 0; i < comand.Count; i++)
            {
                comand[i].PrintPrevYourself();
            }
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintMenuCurItems(Point pos, string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(name);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintMenuPrevItems(Point pos, string name)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(name);
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintEmptyCenter()
        {
            int startX = 1;
            int endX = GlobalParam.WidthWorkSpace - 1;
            int startY = 1;
            int endY = GlobalParam.HeightWorkSpace - 1;

            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintEmptyFon()
        {
            Console.SetCursorPosition(0, 0);

            int startX = 0;
            int endX = GlobalParam.WidthConsole;
            int startY = 0;
            int endY = GlobalParam.HeightConsole;

            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = startY; i < endY; i++)
            {
                for (int j = startX; j < endX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }

    public enum EnumFieldChar
    {
        Border = '█',
        CanInstall = ' ',
        FonRight = '█',
        CharBase = '◘',
        Brick = '▒',
        Concrete = '▓',
        Grass = '░',
        Shot = '▪',
        LifeUp = 'L',
        DefendedTheBase = 'D',
        TankSpeedUp = 'T',
        UpCountShots = 'C',
        UpSpeedShot = 'S'
    }

    public enum EnumTankChar
    {
        TankFront = '▲',
        TankLeft = '◄',
        TankRight = '►',
        TankBack = '▼'
    }

    public enum EnumHP
    {
        OrdinaryTank = 1,
        ImprovedTank = 2,
    }

    public enum EnumDamageMyTank
    {
        Easy = 3,
        Heavy = 5
    }

    public enum EnumDamageEnemyTank
    {
        Easy = 2,
    }

    public enum EnumDefenceEnemyTank
    {
        Easy = 2,
    }

    public enum EnumDefenceObj
    {
        Defenseless = 0,
        Easy = 1,
        Heavy = 4,
        WellKilled = 100
    }

#if DEBUG
    public enum EnumDefenceMyTank
    {
        Defenseless = 0,
        WellKilled = 100
    }

    public enum EnumMyTankSpeed
    {
        Slowly = 10,
        MinRange = 1
    }

    public enum EnumMyShotSpeed
    {
        Slowly = 1,
        Fast = 50,
        //VeryFast = 25,
        MinRange = 1
    }

    public enum EnumMyRateOfFire
    {
        Slowly = 1,
        Fast = 75,
        MinRange = 1
    }

    public enum EnumEnemyTankSpeed
    {
        Slowly = 300,
        Fast = 150,
        MinRangeSlowly = 250,
        MinRangeFast = 100
    }

    public enum EnumEnemyShotSpeed
    {
        Slowly = 140,
        Fast = 125,
        MinRangeSlowly = 90,
        MinRangeFast = 75
    }

    public enum EnumEnemyRateOfFire
    {
        Slowly = 1000,
        Fast = 500,
        MinRangeSlowly = 175,
        MinRangeFast = 125
    }

#else

    public enum EnumDefenceMyTank
    {
        Defenseless = 0,
        WellKilled = 100
    }

    public enum EnumMyTankSpeed
    {
        Slowly = 156,
        MinRange = 1
    }

    public enum EnumMyShotSpeed
    {
        Slowly = 101,
        Fast = 50,
        MinRange = 1
    }

    public enum EnumMyRateOfFire
    {
        Slowly = 150,
        Fast = 75,
        MinRange = 1
    }

    public enum EnumEnemyTankSpeed
    {
        Slowly = 300,
        Fast = 150,
        MinRangeSlowly = 250,
        MinRangeFast = 100
    }

    public enum EnumEnemyShotSpeed
    {
        Slowly = 200,
        Fast = 150,
        MinRangeSlowly = 175,
        MinRangeFast = 125
    }

    public enum EnumEnemyRateOfFire
    {
        Slowly = 1000,
        Fast = 500,
        MinRangeSlowly = 175,
        MinRangeFast = 125
    }

#endif

    public enum EnumTotal
    {
        TotalNull = 0,
        TotalTank1 = 100,
        TotalTank2 = 200,
        TotalTank3 = 300,
        TotalBonus = 500
    }

    public struct StaticObjectCharacteristics
    {
        public Point CurPos;
        public char FieldChar;
        public int Defence;
        public int Total;
        public bool IsEmpty;
        public bool IsEdible;
        public bool IsDisplayed;

        public StaticObjectCharacteristics(Point curPos, char fieldChar, int defence, bool isEmpty,
            bool isDisplayed = true, int total = 0, bool isEdible = false)
        {
            CurPos = new Point(curPos.X, curPos.Y);
            FieldChar = fieldChar;
            Defence = defence;
            IsEmpty = isEmpty;
            IsEdible = isEdible;
            IsDisplayed = isDisplayed;
            Total = total;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(StaticObjectCharacteristics left, StaticObjectCharacteristics right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StaticObjectCharacteristics left, StaticObjectCharacteristics right)
        {
            return !(left == right);
        }
    }

    public struct TankCharacteristics
    {
        public Point CurPos;
        public char FieldChar;
        public int HP;
        public int Damage;
        public int Defence;
        public int Speed;
        public int Total;

        public TankCharacteristics(Point curPos, char fieldChar, int hP, int damage, int defence, int speed, int total)
        {
            CurPos = new Point(curPos.X, curPos.Y);
            FieldChar = fieldChar;
            HP = hP;
            Damage = damage;
            Defence = defence;
            Speed = speed;
            Total = total;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(TankCharacteristics left, TankCharacteristics right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TankCharacteristics left, TankCharacteristics right)
        {
            return !(left == right);
        }
    }

    public struct ShotCharacteristics
    {

        public Point CurPos;
        public char FieldChar;
        public int Damage;
        public int Defence;
        public int Speed;

        public ShotCharacteristics(Point curPos, char fieldChar, int damage, int defence, int speed)
        {
            CurPos = new Point(curPos.X, curPos.Y);
            FieldChar = fieldChar;
            Damage = damage;
            Defence = defence;
            Speed = speed;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(ShotCharacteristics left, ShotCharacteristics right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ShotCharacteristics left, ShotCharacteristics right)
        {
            return !(left == right);
        }
    }
}