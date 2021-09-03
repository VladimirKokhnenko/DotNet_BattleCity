using System;
using System.Drawing;

namespace Tanks.Patterns
{
    public abstract class ShotAbstract : IGeneralObj, IShot
    {
        public const Int64 TicksInMs = 10_000;

        private int _hP;
        private int _total;
        private Int64 _timerForMove;
        private bool _isEmpty;
        private bool _isEdible;
        private bool _isDisplayed;
        private bool _isAlive;
        private bool _isMyTank;
        private bool _isEnemyTank;
        protected ShotCharacteristics _sC;
        protected IGeneralObj _prevObj;
        protected StateKeeper _stK;

        public delegate void PathHendler(out int x, out int y);
        public event PathHendler ShotPath;
        public event Action DownCountShot;

        protected ShotAbstract(in ShotCharacteristics sC, in IGeneralObj prev, ref StateKeeper stK)
        {
            _sC = sC;
            _stK = stK;
            _prevObj = prev;

            HP = 0;
            IsAlive = true;

            TimerForMove = DateTime.Now.Ticks;
            Total = (int)EnumTotal.TotalNull;
            IsEmpty = false;
            IsEdible = false;
            IsDisplayed = true;
            IsMyTank = false;
            IsEnemyTank = false;
        }

        public IGeneralObj PrevObj { get => _prevObj; set => _prevObj = value; }
        public Point CurPos { get => _sC.CurPos; set => _sC.CurPos = value; }
        public char FieldChar { get => _sC.FieldChar; set => _sC.FieldChar = value; }
        public int Damage { get => _sC.Damage; set => _sC.Damage = value; }
        public int Defence { get => _sC.Defence; set => _sC.Defence = value; }
        public int Speed { get => _sC.Speed; set => _sC.Speed = value; }
        public int HP { get => _hP; set => _hP = value; }
        public int Total { get => _total; set => _total = value; }
        public Int64 TimerForMove { get => _timerForMove; set => _timerForMove = value; }

        public bool CanHeMove
        {
            get => (DateTime.Now.Ticks - TimerForMove) / TicksInMs > Speed;
        }
        public bool IsEmpty { get => _isEmpty; set => _isEmpty = value; }
        public bool IsEdible { get => _isEdible; set => _isEdible = value; }
        public bool IsDisplayed { get => _isDisplayed; set => _isDisplayed = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public bool IsMyTank { get => _isMyTank; set => _isMyTank = value; }
        public bool IsEnemyTank { get => _isEnemyTank; set => _isEnemyTank = value; }
        public ref IGeneralObj GetPrev() => ref _prevObj;
        public IGeneralObj GetCopyPrev() => _prevObj;

        public void Function(char ch)
        {
            SetHendlerForPath(ch);
        }

        protected void SetHendlerForPath(char ch)
        {
            if (ch == (char)EnumTankChar.TankFront)
                ShotPath = (out int x, out int y) => { x = _sC.CurPos.X; y = _sC.CurPos.Y - 1; };
            else if (ch == (char)EnumTankChar.TankBack)
                ShotPath = (out int x, out int y) => { x = _sC.CurPos.X; y = _sC.CurPos.Y + 1; };
            else if (ch == (char)EnumTankChar.TankLeft)
                ShotPath = (out int x, out int y) => { x = _sC.CurPos.X - 1; y = _sC.CurPos.Y; };
            else if (ch == (char)EnumTankChar.TankRight)
                ShotPath = (out int x, out int y) => { x = _sC.CurPos.X + 1; y = _sC.CurPos.Y; };
        }

        public void ShotMovement()
        {
            DrawObject();

            if (CanHeMove)
            {
                ShotPath(out int x, out int y);

                IGeneralObj genObj;

                if (_stK[x, y].CurPos.X == x && _stK[x, y].CurPos.Y == y)
                {
                    genObj = _stK[x, y];
                }
                else
                {
                    _stK[x, y].CurPos = new Point(x, y);
                    genObj = _stK[x, y];
                }

                if (genObj.IsEmpty)
                {
                    if (PrevObj.FieldChar == genObj.FieldChar)
                    {
                        _stK.SwapObjWhenCharEqual(CurPos, genObj.CurPos);
                        genObj.DrawObject();
                        this.DrawObject();
                    }
                    else
                    {
                        _stK.SwapObjWhewCharNotEqual(ref GetPrev(), CurPos, genObj.CurPos).DrawObject();
                        this.DrawObject();
                    }
                    TimerForMove = DateTime.Now.Ticks;
                }
                else if (!genObj.IsEmpty)
                {
                    if (Damage <= _stK[x, y].Defence)
                    {
                        IsAlive = false;
                        PrevObj.CurPos = new Point(CurPos.X, CurPos.Y);
                        _stK[CurPos.X, CurPos.Y] = PrevObj;
                        PrevObj.DrawObject();
                        KiLLYourself(ref _stK);
                    }
                    else if (Damage > _stK[x, y].Defence)
                    {
                        _stK[x, y].HP = _stK[x, y].HP - 1;

                        if (_stK[x, y].HP <= 0)
                        {
                            _stK[x, y].KiLLYourself(ref _stK);
                            _stK[x, y].DrawObject();
                        }

                        IsAlive = false;
                        KiLLYourself(ref _stK);
                        PrevObj.CurPos = new Point(CurPos.X, CurPos.Y);
                        _stK[CurPos.X, CurPos.Y] = PrevObj;
                        PrevObj.DrawObject();
                    }
                }
            }
        }

        public abstract void DrawObject();
        public void KiLLYourself(ref StateKeeper stK)
        {
            IsAlive = false;
            Point tmpP = new Point(CurPos.X, CurPos.Y);
            IGeneralObj prev = GetCopyPrev();
            prev.CurPos = new Point(tmpP.X, tmpP.Y);
            stK[tmpP] = prev;
            stK.RemoveShot(this);
            DownCountShot();
        }
    }
}