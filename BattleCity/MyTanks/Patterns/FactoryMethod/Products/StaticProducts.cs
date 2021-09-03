using System.Drawing;

namespace Tanks.Patterns
{
    abstract public class StaticAbstract : IGeneralObj
    {
        private StaticObjectCharacteristics _oC;

        private int _hP;
        private bool _isAlive;
        private bool _isMyTank;
        private bool _isEnemyTank;

        protected StaticAbstract(in StaticObjectCharacteristics o)
        {
            _oC = o;
            IsAlive = true;
            HP = 0;
            IsMyTank = false;
            IsEnemyTank = false;
        }

        public Point CurPos { get => _oC.CurPos; set => _oC.CurPos = value; }
        public char FieldChar { get => _oC.FieldChar; set => _oC.FieldChar = value; }
        public int Defence { get => _oC.Defence; set => _oC.Defence = value; }
        public int Total { get => _oC.Total; set => _oC.Total = value; }
        public int HP { get => _hP; set => _hP = value; }
        public bool IsEmpty { get => _oC.IsEmpty; set => _oC.IsEmpty = value; }
        public bool IsEdible { get => _oC.IsEdible; set => _oC.IsEdible = value; }
        public bool IsDisplayed { get => _oC.IsDisplayed; set => _oC.IsDisplayed = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public bool IsMyTank { get => _isMyTank; set => _isMyTank = value; }
        public bool IsEnemyTank { get => _isEnemyTank; set => _isEnemyTank = value; }
        public abstract void DrawObject();
        public abstract void KiLLYourself(ref StateKeeper stK);
    }
}