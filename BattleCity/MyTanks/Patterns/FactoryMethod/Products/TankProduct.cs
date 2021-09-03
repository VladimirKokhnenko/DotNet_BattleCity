using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks.Patterns
{
    abstract public class MyTankAbstract : IGeneralObj
    {
        public const Int64 TicksInMs = 10_000;
        protected const int _maxSpeedTank = 1000;
        protected const int _maxRateOfFire = 1000;

        protected TankCharacteristics _dC;
        protected StateKeeper _stK;
        private IGeneralObj _prevObj;

        private int _countMyLives;
        private int _maxCountShots = 5;
        private Int64 _timerForShot;
        private Int64 _timerForMove;
        private int _rateOfFire;
        private int _countShots;
        private int _speedShot;
        private bool _isAlive;
        private bool _isEmpty;
        private bool _isEdible;
        private bool _isDisplayed;

        protected MyTankAbstract(in TankCharacteristics d, in IGeneralObj obj, ref StateKeeper stK)
        {
            _dC = d;
            _stK = stK;
            _prevObj = obj;
            TimerForShot = DateTime.Now.Ticks;
            TimerForMove = DateTime.Now.Ticks;
            IsAlive = true;
            CountShots = 0;
            CountMyLives = 1;
            IsEmpty = false;
            IsEdible = false;
            IsDisplayed = true;
        }

        protected MyTankAbstract(in TankCharacteristics d, in IGeneralObj obj, StateKeeper stK) :
            this(in d, in obj, ref stK)
        { }

        public IGeneralObj PrevObj { get => _prevObj; set => _prevObj = value; }
        public Point CurPos { get => _dC.CurPos; set => _dC.CurPos = value; }
        public Int64 TimerForShot { get => _timerForShot; set => _timerForShot = value; }
        public Int64 TimerForMove { get => _timerForMove; set => _timerForMove = value; }
        public char FieldChar { get => _dC.FieldChar; set => _dC.FieldChar = value; }
        public int Defence { get => _dC.Defence; private set => _dC.Defence = value; }
        public int Total { get => _dC.Total; private set => _dC.Total = value; }
        public int HP { get => _dC.HP; set => _dC.HP = value; }
        public int Damage { get => _dC.Damage; private set => _dC.Damage = value; }
        public int Speed { get => _dC.Speed; set => _dC.Speed = value; }
        public int RateOfFire { get => _rateOfFire; set => _rateOfFire = value; }
        public int CountShots { get => _countShots; set => _countShots = value; }
        public int MaxCountShots { get => _maxCountShots; set => _maxCountShots = value; }
        public int CountMyLives { get => _countMyLives; set => _countMyLives = value; }

        public bool IsEmpty { get => _isEmpty; set => _isEmpty = value; }
        public bool IsEdible { get => _isEdible; set => _isEdible = value; }
        public bool IsDisplayed { get => _isDisplayed; set => _isDisplayed = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public bool IsMyTank => true;
        public bool IsEnemyTank => false;
        public bool CanHeMove
        {
            get => (DateTime.Now.Ticks - TimerForMove) / TicksInMs > Speed;
        }
        public bool CanHeShoot
        {
            get => (DateTime.Now.Ticks - TimerForShot) / TicksInMs > RateOfFire;
        }
        public int SpeedShot { get => _speedShot; set => _speedShot = value; }

        public ref IGeneralObj GetPrev() => ref _prevObj;
        public IGeneralObj GetCopyPrev() => _prevObj;
        public abstract void DrawObject();
        public abstract void KiLLYourself(ref StateKeeper stK);
        public abstract ShotAbstract GiveAShot(int x, int y);

        public void GenerateShot()
        {
            if (CanHeShoot)
            {
                GenerateCoordinateForShot(out int coorShotX, out int coorShotY);

                if (CountShots < _maxCountShots)
                {
                    if (_stK[coorShotX, coorShotY].Defence < Damage && !_stK[coorShotX, coorShotY].IsEmpty)
                    {
                        _stK[coorShotX, coorShotY].KiLLYourself(ref _stK);
                        _stK[coorShotX, coorShotY].DrawObject();
                    }
                    else if (_stK[coorShotX, coorShotY].IsEmpty)
                    {
                        ShotAbstract shot = GiveAShot(coorShotX, coorShotY);
                        _stK[coorShotX, coorShotY] = shot;
                        _stK.SetShot(shot);
                        CountShots++;
                        shot.DownCountShot += () => CountShots--;

                        GlobalParam.DrawCountOfShots(_maxCountShots, CountShots);
                        shot.Function(FieldChar);
                    }
                }
                TimerForShot = DateTime.Now.Ticks;
            }
        }

        public void GenerateCoordinateForShot(out int x, out int y)
        {
            if (FieldChar == (char)EnumTankChar.TankFront)
            {
                x = CurPos.X;
                y = CurPos.Y - 1;
            }
            else if (FieldChar == (char)EnumTankChar.TankBack)
            {
                x = CurPos.X;
                y = CurPos.Y + 1;
            }
            else if (FieldChar == (char)EnumTankChar.TankLeft)
            {
                x = CurPos.X - 1;
                y = CurPos.Y;
            }
            else
            {
                x = CurPos.X + 1;
                y = CurPos.Y;
            }
        }

        public void TankMovement(int x, int y, char ch)
        {
            IGeneralObj genObj = _stK[x, y];

            if (FieldChar != ch) // Поворот танка на месте
            {
                FieldChar = ch;
                DrawObject();
            }
            else if (genObj.IsEmpty && !genObj.IsEdible)
            {
                if (PrevObj.FieldChar == genObj.FieldChar)
                {
                    _stK.SwapObjWhenCharEqual(CurPos, genObj.CurPos);
                    genObj.DrawObject();
                    DrawObject();
                }
                else
                {
                    _stK.SwapObjWhewCharNotEqual(ref GetPrev(), CurPos, genObj.CurPos).DrawObject();
                    DrawObject();
                }
            }
            else if (genObj.IsEmpty && genObj.IsEdible)
            {
                genObj.KiLLYourself(ref _stK);
                genObj = _stK[x, y];
                if (PrevObj.FieldChar == genObj.FieldChar)
                {
                    _stK.SwapObjWhenCharEqual(CurPos, genObj.CurPos);
                    genObj.DrawObject();
                    DrawObject();
                }
            }
        }
    }

    abstract public class TankEnemyAbstract : MyTankAbstract, ITank
    {
        protected const int maxCountShots = 1;

        private bool _isMyTank;
        private bool _isEnemyTank;
        private bool _isHeInTheArrWorking;
        private bool _isHeInTheMap;
        private readonly List<IGeneralObj> _bonus;

        protected TankEnemyAbstract(in TankCharacteristics d, in IGeneralObj obj, ref StateKeeper stK) :
            base(in d, in obj, ref stK)
        {
            IsHeInTheArrWorking = false;
            IsHeInTheMap = false;
            IsMyTank = false;
            IsEnemyTank = true;

            _bonus = new List<IGeneralObj>
            {
                new ConcreateBonusDefendedTheBase().CreateProduct(0, 0),
                new ConcreateBonusLifeUp().CreateProduct(0, 0),
                new ConcreateBonusTankSpeedUp().CreateProduct(0, 0),
                new ConcreateBonusUpCountShots().CreateProduct(0, 0),
                new ConcreateBonusUpSpeedShot().CreateProduct(0, 0)
            };
        }

        new public bool IsMyTank { get => _isMyTank; set => _isMyTank = value; }
        new public bool IsEnemyTank { get => _isEnemyTank; set => _isEnemyTank = value; }
        public bool IsHeInTheArrWorking { get => _isHeInTheArrWorking; set => _isHeInTheArrWorking = value; }
        public bool IsHeInTheMap { get => _isHeInTheMap; set => _isHeInTheMap = value; }

        new public void GenerateShot()
        {
            if (CanHeShoot)
            {
                GenerateCoordinateForShot(out int coorShotX, out int coorShotY);

                if (CountShots < maxCountShots)
                {
                    if (_stK[coorShotX, coorShotY].IsMyTank)
                    {
                        _stK[coorShotX, coorShotY].KiLLYourself(ref _stK);
                        _stK[coorShotX, coorShotY].DrawObject();
                    }
                    else if (_stK[coorShotX, coorShotY].Defence <= Damage && !_stK[coorShotX, coorShotY].IsEmpty && !_stK[coorShotX, coorShotY].IsEnemyTank)
                    {
                        _stK[coorShotX, coorShotY].KiLLYourself(ref _stK);
                        _stK[coorShotX, coorShotY].DrawObject();
                    }
                    else if (_stK[coorShotX, coorShotY].IsEmpty)
                    {
                        ShotAbstract shot = GiveAShot(coorShotX, coorShotY);
                        _stK[coorShotX, coorShotY] = shot;
                        _stK.SetShot(shot);
                        CountShots++;
                        shot.DownCountShot += () => CountShots--;

                        shot.Function(FieldChar);
                    }
                }
                TimerForShot = DateTime.Now.Ticks;
            }
        }

        public void TankMovement()
        {
            if (CanHeMove)
            {
                GenerateCoorForMove(out int x, out int y, out char ch);

                IGeneralObj genObj = _stK[x, y];

                if (FieldChar != ch)
                {
                    FieldChar = ch;
                    DrawObject();
                }
                else if (genObj.IsEmpty)
                {
                    if (PrevObj.FieldChar == genObj.FieldChar)
                    {
                        _stK.SwapObjWhenCharEqual(CurPos, genObj.CurPos);
                        genObj.DrawObject();
                        DrawObject();
                    }
                    else
                    {
                        _stK.SwapObjWhewCharNotEqual(ref GetPrev(), CurPos, genObj.CurPos).DrawObject();
                        DrawObject();
                    }
                }
                TimerForMove = DateTime.Now.Ticks;
            }
            GenerateShot();
        }

        protected void CreateBonus()
        {
            Random rand = new Random();

            int x;
            int y;

            while (true)
            {
                x = rand.Next(1, GlobalParam.WidthWorkSpace - 1);
                y = rand.Next(1, GlobalParam.HeightWorkSpace - 1);

                if (_stK[x, y].FieldChar == (char)EnumFieldChar.CanInstall)
                    break;
            }

            int num = rand.Next(0, _bonus.Count);
            if (num == 0)
            {
                _bonus[0].CurPos = new Point(x, y);
                _stK[x, y] = _bonus[0];
                _stK[x, y].DrawObject();
            }
            else if (num == 1)
            {
                _bonus[1].CurPos = new Point(x, y);
                _stK[x, y] = _bonus[1];
                _stK[x, y].DrawObject();
            }
            else if (num == 2)
            {
                _bonus[2].CurPos = new Point(x, y);
                _stK[x, y] = _bonus[2];
                _stK[x, y].DrawObject();
            }
            else if (num == 3)
            {
                _bonus[3].CurPos = new Point(x, y);
                _stK[x, y] = _bonus[3];
                _stK[x, y].DrawObject();
            }
            else if (num == 4)
            {
                _bonus[4].CurPos = new Point(x, y);
                _stK[x, y] = _bonus[4];
                _stK[x, y].DrawObject();
            }
        }

        private void GenerateCoorForMove(out int x, out int y, out char ch)
        {
            var rand = new Random();

            if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankBack &&
                _stK[CurPos.X, CurPos.Y + 1].IsEmpty)
            {
                x = CurPos.X;
                y = CurPos.Y + 1;
                ch = (char)EnumTankChar.TankBack;
            }
            else if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankFront &&
                _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
            {
                x = CurPos.X;
                y = CurPos.Y - 1;
                ch = (char)EnumTankChar.TankFront;
            }
            else if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankRight
                && _stK[CurPos.X + 1, CurPos.Y].IsEmpty)
            {
                x = CurPos.X + 1;
                y = CurPos.Y;
                ch = (char)EnumTankChar.TankRight;
            }
            else if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankLeft &&
                _stK[CurPos.X - 1, CurPos.Y].IsEmpty)
            {
                x = CurPos.X - 1;
                y = CurPos.Y;
                ch = (char)EnumTankChar.TankLeft;
            }
            else
            {
                if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankBack)
                {
                    if (_stK[CurPos.X + 1, CurPos.Y].IsEmpty && _stK[CurPos.X - 1, CurPos.Y].IsEmpty
                        && _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        int num = rand.Next(3);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                        else if (num == 1)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                    }
                    else if (_stK[CurPos.X + 1, CurPos.Y].IsEmpty && _stK[CurPos.X - 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                    }
                    else if (_stK[CurPos.X + 1, CurPos.Y].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                    }
                    else if (_stK[CurPos.X - 1, CurPos.Y].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                    }
                    else if (_stK[CurPos.X + 1, CurPos.Y].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankRight;
                    }
                    else if (_stK[CurPos.X - 1, CurPos.Y].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankLeft;
                    }
                    else
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankFront;
                    }
                }
                else if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankRight)
                {
                    if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty &&
                        _stK[CurPos.X - 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(3);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else if (num == 1)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }

                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                    }
                    else if (_stK[CurPos.X - 1, CurPos.Y].IsEmpty && _stK[CurPos.X, CurPos.Y + 1].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                    }
                    else if (_stK[CurPos.X - 1, CurPos.Y].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankBack;
                    }
                    else if (_stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankFront;
                    }
                    else
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankLeft;
                    }
                }
                else if (_stK[CurPos.X, CurPos.Y].FieldChar == (char)EnumTankChar.TankLeft)
                {
                    if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty &&
                        _stK[CurPos.X + 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(3);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else if (num == 1)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X + 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y - 1].IsEmpty && _stK[CurPos.X + 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankFront;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankBack;
                    }
                    else if (_stK[CurPos.X, CurPos.Y - 1].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankFront;
                    }
                    else
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankRight;
                    }
                }
                else
                {
                    if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X + 1, CurPos.Y].IsEmpty &&
                        _stK[CurPos.X - 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(3);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else if (num == 1)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X - 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty && _stK[CurPos.X + 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankBack;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                    }
                    else if (_stK[CurPos.X + 1, CurPos.Y].IsEmpty && _stK[CurPos.X - 1, CurPos.Y].IsEmpty)
                    {
                        int num = rand.Next(2);

                        if (num == 0)
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankLeft;
                        }
                        else
                        {
                            x = CurPos.X;
                            y = CurPos.Y;
                            ch = (char)EnumTankChar.TankRight;
                        }
                    }
                    else if (_stK[CurPos.X, CurPos.Y + 1].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankBack;
                    }
                    else if (_stK[CurPos.X + 1, CurPos.Y].IsEmpty)
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankRight;
                    }
                    else
                    {
                        x = CurPos.X;
                        y = CurPos.Y;
                        ch = (char)EnumTankChar.TankLeft;
                    }
                }
            }
        }
    }
}