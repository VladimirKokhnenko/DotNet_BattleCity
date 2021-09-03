namespace Tanks.Patterns
{
    public class BuilderLevel3 : BuilderLevel
    {
        public BuilderLevel3(ref StateKeeper stK) : base(ref stK) { }

        public override void BuildWorkSpace()
        {
            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 1, GlobalParam.HeightWorkSpace / 2 + 5);

            new BrickFactory().CreateLineVertShort5(
                _stK.GetMasterArr(), 9, GlobalParam.HeightWorkSpace / 2 + 3);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 9, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 17, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 25, GlobalParam.HeightWorkSpace / 2 - 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 33, GlobalParam.HeightWorkSpace / 2 - 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 41, GlobalParam.HeightWorkSpace / 2 - 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 41, GlobalParam.HeightWorkSpace / 2 + 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 41, GlobalParam.HeightWorkSpace / 2 + 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 49, GlobalParam.HeightWorkSpace / 2 - 2);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 57, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 65, GlobalParam.HeightWorkSpace / 2 - 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 73, GlobalParam.HeightWorkSpace / 2 - 6);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 57, GlobalParam.HeightWorkSpace / 2 - 10);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 49, GlobalParam.HeightWorkSpace / 2 - 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 49, GlobalParam.HeightWorkSpace / 2 + 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 49, GlobalParam.HeightWorkSpace / 2 + 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 49, GlobalParam.HeightWorkSpace / 2 + 10);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 57, GlobalParam.HeightWorkSpace / 2 + 10);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 65, GlobalParam.HeightWorkSpace / 2 + 10);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 65, GlobalParam.HeightWorkSpace / 2 + 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 65, GlobalParam.HeightWorkSpace / 2 + 2);

            new ConcreteFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 73, GlobalParam.HeightWorkSpace / 2 + 2);

            new ConcreteFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 73, GlobalParam.HeightWorkSpace / 2 + 6);

            new ConcreteFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 73, GlobalParam.HeightWorkSpace / 2 + 10);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 78, GlobalParam.HeightWorkSpace - 5);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 78, GlobalParam.HeightWorkSpace - 9);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 78, GlobalParam.HeightWorkSpace - 14);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, GlobalParam.HeightWorkSpace - 5);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, GlobalParam.HeightWorkSpace - 5);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, GlobalParam.HeightWorkSpace - 9);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, GlobalParam.HeightWorkSpace - 14);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, GlobalParam.HeightWorkSpace - 14);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, GlobalParam.HeightWorkSpace - 18);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, GlobalParam.HeightWorkSpace - 18);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 86, GlobalParam.HeightWorkSpace - 26);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 94, GlobalParam.HeightWorkSpace - 26);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 102, GlobalParam.HeightWorkSpace - 26);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 110, GlobalParam.HeightWorkSpace - 26);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 118, GlobalParam.HeightWorkSpace - 26);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 126, GlobalParam.HeightWorkSpace - 26);

            new ConcreteFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 133, GlobalParam.HeightWorkSpace - 26);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 102, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 110, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 118, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 126, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 133, GlobalParam.HeightWorkSpace - 22);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 102, GlobalParam.HeightWorkSpace - 18);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 110, GlobalParam.HeightWorkSpace - 18);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 118, GlobalParam.HeightWorkSpace - 18);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 126, GlobalParam.HeightWorkSpace - 18);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 133, GlobalParam.HeightWorkSpace - 18);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 102, GlobalParam.HeightWorkSpace - 14);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 110, GlobalParam.HeightWorkSpace - 14);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 118, GlobalParam.HeightWorkSpace - 14);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 126, GlobalParam.HeightWorkSpace - 14);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 133, GlobalParam.HeightWorkSpace - 14);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 102, GlobalParam.HeightWorkSpace - 10);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 110, GlobalParam.HeightWorkSpace - 10);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 118, GlobalParam.HeightWorkSpace - 10);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 126, GlobalParam.HeightWorkSpace - 10);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 133, GlobalParam.HeightWorkSpace - 10);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 102, GlobalParam.HeightWorkSpace - 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 110, GlobalParam.HeightWorkSpace - 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 118, GlobalParam.HeightWorkSpace - 6);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 126, GlobalParam.HeightWorkSpace - 6);

            new GrassFactory().CreateBlockBigShort3(
                _stK.GetMasterArr(), 133, GlobalParam.HeightWorkSpace - 6);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 33, GlobalParam.HeightWorkSpace / 2 + 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 33, GlobalParam.HeightWorkSpace / 2 + 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 33, GlobalParam.HeightWorkSpace / 2 + 10);

            new BrickFactory().CreateBlockSmallLong2(
                _stK.GetMasterArr(), 33, GlobalParam.HeightWorkSpace / 2 + 16);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 1, 5);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 1, 9);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 1, 13);

            new GrassFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 9, 13);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 18, 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 18, 6);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 18, 10);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 27, 5);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 36, 10);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 40, 2);

            new ConcreteFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 60, 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 80, 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 88, 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 96, 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 104, 2);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 104, 7);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 112, 7);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 120, 7);

            new BrickFactory().CreateBlockBigLong4(
                _stK.GetMasterArr(), 128, 7);
        }
    }
}