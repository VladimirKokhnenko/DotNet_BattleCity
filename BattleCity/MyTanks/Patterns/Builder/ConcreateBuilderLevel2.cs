namespace Tanks.Patterns
{
    public class BuilderLevel2 : BuilderLevel
    {
        public BuilderLevel2(ref StateKeeper stK) : base(ref stK) { }

        public override void BuildWorkSpace()
        {
            new ConcreteFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 1, GlobalParam.HeightWorkSpace / 2);

            new ConcreteFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 9, GlobalParam.HeightWorkSpace / 2);

            new BrickFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 1, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 9, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 10, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 18, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 26, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 34, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 26, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 18, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 36, GlobalParam.HeightWorkSpace / 2 - 6);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 44, GlobalParam.HeightWorkSpace / 2 - 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 52, GlobalParam.HeightWorkSpace / 2 - 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 60, GlobalParam.HeightWorkSpace / 2 - 6);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 52, GlobalParam.HeightWorkSpace / 2 - 6);
            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 44, GlobalParam.HeightWorkSpace / 2 - 6);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 25, GlobalParam.HeightWorkSpace / 2 + 2);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 21, GlobalParam.HeightWorkSpace / 2 + 2);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 25, GlobalParam.HeightWorkSpace / 2 + 2);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 21, GlobalParam.HeightWorkSpace / 2 + 2);

            new BrickFactory().CreateLineHorShort7(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 34, GlobalParam.HeightWorkSpace / 2 + 4);

            new BrickFactory().CreateLineHorShort7(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 34, GlobalParam.HeightWorkSpace / 2 + 6);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 40, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 44, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 56, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 60, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 36, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 40, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 52, GlobalParam.HeightWorkSpace / 2 + 3);
            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 56, GlobalParam.HeightWorkSpace / 2 + 3);

            new ConcreteFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 - 9, GlobalParam.HeightWorkSpace / 2 - 8);

            new ConcreteFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace / 2 + 1, GlobalParam.HeightWorkSpace / 2 - 8);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), 3, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), 7, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 8, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 12, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 28, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), GlobalParam.WidthWorkSpace - 32, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), 24, 1);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), 28, 1);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 32, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 40, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 48, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 56, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 62, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 70, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 78, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, 2);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 102, 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 32, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 40, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 48, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 56, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 62, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 70, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 78, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, 6);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 102, 6);

            new GrassFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 32, 10);

            new GrassFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 40, 10);

            new GrassFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 48, 10);

            new GrassFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 82, 10);

            new GrassFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 90, 10);

            new GrassFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 98, 10);
        }
    }
}