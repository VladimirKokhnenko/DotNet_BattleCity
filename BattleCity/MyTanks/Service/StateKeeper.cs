using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks.Patterns
{
    public class StateKeeper
    {
        private IGeneralObj[,] _masterArr;
        private readonly List<ITank> _tankArrGenl;
        private readonly List<ITank> _tankArrWorking;
        private readonly List<IShot> _shotArr;
        private MyTankAbstract _myTank;
        private int _countLevel;
        private int _curLevel;
        private int _generalScores;
        private int _scoresForLevel;
        private int _countTanksInTheWorkingArr;
        private int _countTanksInTheGenArr;
        private int _countMyLives;
        private bool _isNewGame;
        private bool _baseIsKill;

#if DEBUG
        public const int MaxCountTanksInWorkingArr = 12;
        public const int MinCountTanksInWorkingArr = 3;
        public const int MaxCountTanksInGen = 30;
        public const int MinCountTanksInGen = 10;
#else
        public const int MaxCountTanksInWorkingArr = 12;
        public const int MinCountTanksInWorkingArr = 4;
        public const int MaxCountTanksInGen = 30;
        public const int MinCountTanksInGen = 10;
#endif
        public StateKeeper()
        {
            _masterArr = new IGeneralObj[GlobalParam.WidthConsole, GlobalParam.HeightConsole];
            _tankArrGenl = new List<ITank>();
            _tankArrWorking = new List<ITank>();
            _shotArr = new List<IShot>();
            CountLevel = 0;
            CurLevel = 0;
            GeneralScores = 0;
            ScoresForLevel = 0;
            BaseIsKill = false;
            IsNewGame = false;
            CountMyLives = 3;
        }

        public int CountLevel { get => _countLevel; set => _countLevel = value; }
        public int CurLevel { get => _curLevel; set => _curLevel = value; }
        public int GeneralScores { get => _generalScores; set => _generalScores = value; }
        public int ScoresForLevel { get => _scoresForLevel; set => _scoresForLevel = value; }
        public int CountTanksInTheWorkingArr

        {
            get => _countTanksInTheWorkingArr; set => _countTanksInTheWorkingArr = value;
        }

        public int CountMyLives { get => _countMyLives; set => _countMyLives = value; }

        public int CountTanksInTheGenArr
        {
            get => _countTanksInTheGenArr; set => _countTanksInTheGenArr = value;
        }

        public MyTankAbstract MyTank { get => _myTank; set => _myTank = value; }
        public bool BaseIsKill { get => _baseIsKill; set => _baseIsKill = value; }
        public bool IsNewGame { get => _isNewGame; set => _isNewGame = value; }

        public IGeneralObj[,] GetMasterArr() => _masterArr;
        public List<ITank> GetTankArrGenl() => _tankArrGenl;
        public List<ITank> GetTankArrWorking() => _tankArrWorking;
        public List<IShot> GetShotArr() => _shotArr;
        public IShot GetShot(int index) => _shotArr[index];

        public void SetMyTank(MyTankAbstract tank)
        {
            MyTank = tank;
            MyTank.DrawObject();
            _masterArr[tank.CurPos.X, tank.CurPos.Y] = tank;
        }

        public void SetTankGenl(ITank tank) => _tankArrGenl.Add(tank);
        public void SetTankWorking(ITank tank)
        {
            if (_tankArrWorking.Count < MaxCountTanksInWorkingArr)
                _tankArrWorking.Add(tank);
        }
        public void SetShot(IShot shot) => _shotArr.Add(shot);

        public IGeneralObj this[int x, int y]
        {
            get => _masterArr[x, y];
            set => _masterArr[x, y] = value;
        }

        public IGeneralObj this[Point p]
        {
            get => _masterArr[p.X, p.Y];
            set => _masterArr[p.X, p.Y] = value;
        }

        public void RemoveTank(ITank tank)
        {
            _tankArrGenl.Remove(tank);
            _tankArrWorking.Remove(tank);
        }

        public void RemoveTankInGenl(ITank tank) => _tankArrGenl?.Remove(tank);
        public void RemoveTankInWorking(ITank tank) => _tankArrWorking?.Remove(tank);
        public void RemoveShot(IShot shot) => _shotArr?.Remove(shot);

        public void MixEnemyTanks()
        {
            Random rand = new Random();

            for (int i = 0; i < _tankArrGenl.Count; i++)
            {
                int target = rand.Next(_tankArrGenl.Count);
                ITank tmp = _tankArrGenl[i];
                _tankArrGenl[i] = _tankArrGenl[target];
                _tankArrGenl[target] = tmp;
            }
        }

        public void FillWorkingTankArr()
        {
            for (int i = _tankArrGenl.Count - 1; i >= 0; i--)
            {
                if (_tankArrWorking.Count < CountTanksInTheWorkingArr && !_tankArrGenl[i].IsHeInTheArrWorking)
                {
                    _tankArrWorking.Add(_tankArrGenl[i]);
                    _tankArrGenl[i].IsHeInTheArrWorking = true;
                }
                else if (_tankArrWorking.Count == CountTanksInTheWorkingArr)
                    break;
            }
        }

        public void SetStartFourTanks()
        {
            const int startCount = 4;
            int count = 0;

            for (int i = 0; i < _tankArrWorking.Count; i++)
            {
                if (!_tankArrWorking[i].IsHeInTheMap &&
                    _masterArr[_tankArrWorking[i].CurPos.X, _tankArrWorking[i].CurPos.Y].FieldChar ==
                    (char)EnumFieldChar.CanInstall)
                {
                    _masterArr[_tankArrWorking[i].CurPos.X, _tankArrWorking[i].CurPos.Y] = _tankArrWorking[i];
                    _tankArrWorking[i].IsHeInTheMap = true;
                    count++;
                }
                else if (count == startCount)
                {
                    break;
                }
            }
        }

        public void SetInMapEnemyTanks()
        {
            for (int i = 0; i < _tankArrWorking.Count; i++)
            {
                if (!_tankArrWorking[i].IsHeInTheMap &&
                      _masterArr[_tankArrWorking[i].CurPos.X, _tankArrWorking[i].CurPos.Y].FieldChar ==
                      (char)EnumFieldChar.CanInstall)
                {
                    _masterArr[_tankArrWorking[i].CurPos.X, _tankArrWorking[i].CurPos.Y] = _tankArrWorking[i];

                    _tankArrWorking[i].IsHeInTheMap = true;
                    _tankArrWorking[i].DrawObject();
                    break;
                }
            }
        }

        public void SwapObjWhenCharEqual(Point pDyn, Point pStat)
        {
            IGeneralObj tmpArr = _masterArr[pDyn.X, pDyn.Y];
            _masterArr[pDyn.X, pDyn.Y] = _masterArr[pStat.X, pStat.Y];
            _masterArr[pStat.X, pStat.Y] = tmpArr;
            _masterArr[pDyn.X, pDyn.Y].CurPos = pDyn;
            _masterArr[pStat.X, pStat.Y].CurPos = pStat;
        }

        public IGeneralObj SwapObjWhewCharNotEqual(ref IGeneralObj prev, Point pDyn, Point pStat)
        {
            IGeneralObj tmpPrev = prev;
            tmpPrev.CurPos = _masterArr[pDyn.X, pDyn.Y].CurPos;

            IGeneralObj tmpDynObj = _masterArr[pDyn.X, pDyn.Y];
            tmpDynObj.CurPos = new Point(pStat.X, pStat.Y);

            prev = _masterArr[pStat.X, pStat.Y];

            _masterArr[tmpPrev.CurPos.X, tmpPrev.CurPos.Y] = tmpPrev;
            _masterArr[pStat.X, pStat.Y] = tmpDynObj;
            return tmpPrev;
        }

        public void ResetGame()
        {
            _masterArr = new IGeneralObj[GlobalParam.WidthConsole, GlobalParam.HeightConsole];
            _tankArrGenl.Clear();
            _tankArrWorking.Clear();
            _shotArr.Clear();

            CountLevel = 0;
            CurLevel = 0;
            GeneralScores = 0;
            ScoresForLevel = 0;
        }
    }
}