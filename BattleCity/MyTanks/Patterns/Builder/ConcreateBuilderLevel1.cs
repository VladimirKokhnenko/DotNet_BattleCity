namespace Tanks.Patterns
{
    public class BuilderLevel1 : BuilderLevel
    {
        public BuilderLevel1(ref StateKeeper stK) : base(ref stK) { }

        public override void BuildWorkSpace()
        {
            new ConcreteFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(),
                1,
                GlobalParam.HeightWorkSpace / 2);

            new ConcreteFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(),
                GlobalParam.WidthWorkSpace - 9,
                GlobalParam.HeightWorkSpace / 2);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), 3, 3);

            new BrickFactory().CreateLineVertLong6(
                _stK.GetMasterArr(), 11, 3);

            new BrickFactory().CreateH9(
                _stK.GetMasterArr(), 17, 3);

            new BrickFactory().CreateU11(
                _stK.GetMasterArr(), 17, 19);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 5, 5);

            new BrickFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 15, 33);

            new BrickFactory().CreateP10(
                _stK.GetMasterArr(), 33, 3);

            new BrickFactory().CreateU11(
                _stK.GetMasterArr(), 33, 19);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 49, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 58, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 67, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 76, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 85, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateLineHorShort7(
                _stK.GetMasterArr(), 69, 10);

            new BrickFactory().CreateLineVertLong6(
                _stK.GetMasterArr(), 96, 3);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 105, 21);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 113, 21);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 121, 21);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 129, 21);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 105, 25);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 113, 25);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 121, 25);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 129, 25);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 105, 29);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 113, 29);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 121, 29);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 129, 29);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 105, 33);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 113, 33);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 121, 33);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 129, 33);

            new BrickFactory().CreateLineHorShort7(
                _stK.GetMasterArr(), 48, 22);

            new BrickFactory().CreateLineHorShort7(
                _stK.GetMasterArr(), 48, 26);

            new BrickFactory().CreateLineHorShort7(
                _stK.GetMasterArr(), 48, 30);
        }
    }
}