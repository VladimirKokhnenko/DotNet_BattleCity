using System;

namespace Tanks.Patterns
{
    public abstract class BuilderLevel : ILevel
    {
        private delegate void ChangeSpeedAndRate(ref TankEnemyAbstract tank);

        protected StateKeeper _stK;
        private readonly ChangeSpeedAndRate _delegateChangeT1;
        private readonly ChangeSpeedAndRate _delegateChangeT2;
        private readonly ChangeSpeedAndRate _delegateChangeT3;
        private readonly Func<int, int, TankEnemyAbstract> _returnTankType1;
        private readonly Func<int, int, TankEnemyAbstract> _returnTankType2;
        private readonly Func<int, int, TankEnemyAbstract> _returnTankType3;

        protected BuilderLevel(ref StateKeeper stK)
        {
            _delegateChangeT1 = ChangeSpeedAndRateOfFireTankType1;
            _delegateChangeT2 = ChangeSpeedAndRateOfFireTankType2;
            _delegateChangeT3 = ChangeSpeedAndRateOfFireTankType3;

            _returnTankType1 = (int x, int y) =>
            new ConcreateEnemyTankType1().CreateProduct(
                ref _stK,
                new ConcreateClearField().CreateProduct(x, y),
                (char)EnumTankChar.TankBack,
                x, y);

            _returnTankType2 = (int x, int y) =>
            new ConcreateEnemyTankType2().CreateProduct(
                ref _stK,
                new ConcreateClearField().CreateProduct(x, y),
                (char)EnumTankChar.TankBack,
                x, y);

            _returnTankType3 = (int x, int y) =>
            new ConcreateEnemyTankType3().CreateProduct(
                ref _stK,
                new ConcreateClearField().CreateProduct(x, y),
                (char)EnumTankChar.TankBack,
                x, y);

            _stK = stK;
        }

        public abstract void BuildWorkSpace();

        public void CreateMyTank()
        {
            int x = GlobalParam.StartCoorMyTank.X;
            int y = GlobalParam.StartCoorMyTank.Y;
            MyTankAbstract tmpMy = new ConcreateMyTank().CreateProduct(
                ref _stK,
                new ConcreateClearField().CreateProduct(x, y),
                (char)EnumTankChar.TankFront,
                x, y);

            _stK[x, y] = tmpMy;
            _stK.SetMyTank(tmpMy);
        }

        public void BuilderTanks()
        {
            int x = GlobalParam.StartCoorMyTank.X;
            int y = GlobalParam.StartCoorMyTank.Y;
            MyTankAbstract tmpMy = new ConcreateMyTank().CreateProduct(
                ref _stK,
                new ConcreateClearField().CreateProduct(x, y),
                (char)EnumTankChar.TankFront,
                x, y);

            _stK[x, y] = tmpMy;
            _stK.SetMyTank(tmpMy);

            _stK.CountTanksInTheGenArr = StateKeeper.MinCountTanksInGen + _stK.CountLevel;

            if (_stK.CountTanksInTheGenArr > StateKeeper.MaxCountTanksInGen)
                _stK.CountTanksInTheGenArr = StateKeeper.MaxCountTanksInGen;

            _stK.CountTanksInTheWorkingArr = StateKeeper.MinCountTanksInWorkingArr + _stK.CountLevel;

            if (_stK.CountTanksInTheWorkingArr > StateKeeper.MaxCountTanksInWorkingArr)
                _stK.CountTanksInTheWorkingArr = StateKeeper.MaxCountTanksInWorkingArr;

            int t1 = _stK.CountTanksInTheGenArr / 2;
            int t2 = _stK.CountTanksInTheGenArr / 4;
            int t3 = _stK.CountTanksInTheGenArr - t1 - t2;

            SetEnemyTank(_delegateChangeT1, _returnTankType1, t1);
            SetEnemyTank(_delegateChangeT2, _returnTankType2, t2);
            SetEnemyTank(_delegateChangeT3, _returnTankType3, t3);
            _stK.MixEnemyTanks();
            _stK.FillWorkingTankArr();
        }

        public void CreateLevel()
        {
            IBuilder b = new ConcreateBuilderElementsForMap(_stK.GetMasterArr());

            b.BuildShell();
            BuildWorkSpace();
            BuilderTanks();
        }

        private void SetEnemyTank(
            ChangeSpeedAndRate ChangeSpeedAndRateOfFireTankType,
            Func<int, int, TankEnemyAbstract> returnTankType,
            int range)
        {
            TankEnemyAbstract tmp;
            int x;
            int y;

            for (int i = 0; i < range; i++)
            {
                if (i % 4 == 0)
                {
                    x = GlobalParam.StartCoorEnemyFirst.X;
                    y = GlobalParam.StartCoorEnemyFirst.Y;
                    tmp = returnTankType(x, y);
                    ChangeSpeedAndRateOfFireTankType(ref tmp);
                }
                else if (i % 4 == 1)
                {
                    x = GlobalParam.StartCoorEnemySecond.X;
                    y = GlobalParam.StartCoorEnemySecond.Y;
                    tmp = returnTankType(x, y);
                    ChangeSpeedAndRateOfFireTankType(ref tmp);
                }
                else if (i % 4 == 2)
                {
                    x = GlobalParam.StartCoorEnemyThird.X;
                    y = GlobalParam.StartCoorEnemyThird.Y;
                    tmp = returnTankType(x, y);
                    ChangeSpeedAndRateOfFireTankType(ref tmp);
                }
                else
                {
                    x = GlobalParam.StartCoorEnemyFourth.X;
                    y = GlobalParam.StartCoorEnemyFourth.Y;
                    tmp = returnTankType(x, y);
                    ChangeSpeedAndRateOfFireTankType(ref tmp);
                }
                _stK.SetTankGenl(tmp);
            }
        }

        private void ChangeSpeedAndRateOfFireTankType1(ref TankEnemyAbstract tank)
        {
            tank.Speed -= _stK.CountLevel;

            if (tank.Speed < (int)EnumEnemyTankSpeed.MinRangeSlowly)
                tank.Speed = (int)EnumEnemyTankSpeed.MinRangeSlowly;

            tank.RateOfFire -= _stK.CountLevel;

            if (tank.RateOfFire < (int)EnumEnemyRateOfFire.MinRangeSlowly)
                tank.RateOfFire = (int)EnumEnemyRateOfFire.MinRangeSlowly;
        }

        private void ChangeSpeedAndRateOfFireTankType2(ref TankEnemyAbstract tank)
        {
            tank.Speed -= _stK.CountLevel;

            if (tank.Speed < (int)EnumEnemyTankSpeed.MinRangeFast)
                tank.Speed = (int)EnumEnemyTankSpeed.MinRangeFast;

            tank.RateOfFire -= _stK.CountLevel;

            if (tank.RateOfFire < (int)EnumEnemyRateOfFire.MinRangeSlowly)
                tank.RateOfFire = (int)EnumEnemyRateOfFire.MinRangeSlowly;
        }

        private void ChangeSpeedAndRateOfFireTankType3(ref TankEnemyAbstract tank)
        {
            tank.Speed -= _stK.CountLevel;

            if (tank.Speed < (int)EnumEnemyTankSpeed.MinRangeFast)
                tank.Speed = (int)EnumEnemyTankSpeed.MinRangeFast;

            tank.RateOfFire -= _stK.CountLevel;

            if (tank.RateOfFire < (int)EnumEnemyRateOfFire.MinRangeFast)
                tank.RateOfFire = (int)EnumEnemyRateOfFire.MinRangeFast;
        }
    }
}