using System;
using System.Drawing;

namespace Tanks.Patterns
{
    public interface IAbstractFactory
    {
        void CreateBlockSmallShort1(IGeneralObj[,] arr, int x, int y);
        void CreateBlockSmallLong2(IGeneralObj[,] arr, int x, int y);
        void CreateBlockBigShort3(IGeneralObj[,] arr, int x, int y);
        void CreateBlockBigLong4(IGeneralObj[,] arr, int x, int y);
        void CreateLineVertShort5(IGeneralObj[,] arr, int x, int y);
        void CreateLineVertLong6(IGeneralObj[,] arr, int x, int y);
        void CreateLineHorShort7(IGeneralObj[,] arr, int x, int y);
        void CreateLineHorLong8(IGeneralObj[,] arr, int x, int y);
        void CreateH9(IGeneralObj[,] arr, int x, int y);
        void CreateP10(IGeneralObj[,] arr, int x, int y);
        void CreateU11(IGeneralObj[,] arr, int x, int y);
    }

    public interface IBuilder
    {
        void BuildClearFon();
        void BuildBorder();
        void BuildBase();
        void BuildShell();
    }

    public interface IComand
    {
        void Execute();
        void PrintCurYourself();
        void PrintPrevYourself();
    }

    public interface ILevel
    {
        void CreateLevel();
        void CreateMyTank();
    }

    public interface IGeneralObj
    {
        Point CurPos { get; set; }
        char FieldChar { get; }
        int Defence { get; }
        int Total { get; }
        int HP { get; set; }
        bool IsEmpty { get; }
        bool IsEdible { get; }
        bool IsDisplayed { get; }
        bool IsAlive { get; set; }
        bool IsMyTank { get; }
        bool IsEnemyTank { get; }
        void DrawObject();
        void KiLLYourself(ref StateKeeper stK);
    }

    public interface IDynamicObj
    {
        IGeneralObj PrevObj { get; set; }
        int Damage { get; }
        int Speed { get; }
        bool CanHeMove { get; }
        ref IGeneralObj GetPrev();
    }

    public interface ITank : IGeneralObj, IDynamicObj
    {
        bool CanHeShoot { get; }
        bool IsHeInTheArrWorking { get; set; }
        bool IsHeInTheMap { get; set; }
        void TankMovement();
    }

    public interface IShot : IGeneralObj, IDynamicObj
    {
        void Function(char ch);
        void ShotMovement();
    }
}