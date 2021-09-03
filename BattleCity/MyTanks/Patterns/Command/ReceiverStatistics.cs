using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace Tanks.Patterns
{
    [Serializable]
    public class Statistics
    {
        public const int CountItems = 10;

        private readonly KeyValuePair<int, string>[] _stat;

        public Statistics()
        {
            _stat = new KeyValuePair<int, string>[CountItems];
        }

        public static Statistics Reset()
        {
            return new Statistics();
        }

        public KeyValuePair<int, string> this[int i]
        {
            get => _stat[i];
            set => _stat[i] = value;
        }

        public void AddItem(KeyValuePair<int, string> pair)
        {
            bool full = true;

            for (int i = 0; i < CountItems; i++)
            {
                if (_stat[i].Value == null)
                {
                    _stat[i] = pair;
                    full = !full;
                    break;
                }
            }

            if (full && pair.Key >= _stat[CountItems - 1].Key)
                _stat[CountItems - 1] = pair;
            SortDescending();
        }

        public void SortDescending()
        {
            for (int i = 0; i < CountItems; i++)
            {
                for (int j = i + 1; j < CountItems; j++)
                {
                    if (_stat[i].Key < _stat[j].Key &&
                        _stat[i].Value != null && _stat[j].Value != null)
                    {
                        var t = _stat[i];
                        _stat[i] = _stat[j];
                        _stat[j] = t;
                    }
                }
            }
        }
    }

    public class ReceiverStatistics
    {
        private StateKeeper _stK;
        private Statistics _statistics;
        private BinaryFormatter _formatter;

        private string _nameLoad;
        private Point _coorLoad;
        private string _nameFile;
        private string _nameResetFile;
        private Point _coorResetFile;

        public ReceiverStatistics(StateKeeper stK)
        {
            StK = stK;
            Statistics = new Statistics();
            NameFile = "Records.mrcd";
            Formatter = new BinaryFormatter();
            NameLoad = "Statistics";
            NameResetFile = "Reset Statistics";
            CoorLoad = new Point(
                GlobalParam.WidthConsole / 2 - (NameLoad.Length / 2), GlobalParam.IndexYStatistics);
            CoorResetFile = new Point(
                GlobalParam.WidthConsole / 2 - (NameResetFile.Length / 2), GlobalParam.IndexYResetStatistics);
        }

        public StateKeeper StK { get => _stK; set => _stK = value; }
        public Statistics Statistics { get => _statistics; set => _statistics = value; }
        public BinaryFormatter Formatter { get => _formatter; set => _formatter = value; }
        public Point CoorLoad { get => _coorLoad; set => _coorLoad = value; }
        public string NameLoad { get => _nameLoad; set => _nameLoad = value; }
        public string NameFile { get => _nameFile; set => _nameFile = value; }
        public string NameResetFile { get => _nameResetFile; set => _nameResetFile = value; }
        public Point CoorResetFile { get => _coorResetFile; set => _coorResetFile = value; }

        public void SaveStatistics(string name)
        {
            LoadStatistics();
            Statistics.AddItem(new KeyValuePair<int, string>(_stK.GeneralScores, name));

            using (var fileStream = new FileStream(
                NameFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Formatter.Serialize(fileStream, Statistics);
            }
        }

        public void LoadStatistics()
        {
            using (var fileStream = new FileStream(NameFile, FileMode.OpenOrCreate))
            {
                if (fileStream.Length != 0)
                    Statistics = (Statistics)Formatter.Deserialize(fileStream);
            }
        }

        public void ResetStatistics()
        {
            if (GlobalParam.AreYouSure())
            {
                _statistics = Statistics.Reset();
                if (File.Exists(NameFile)) File.Delete(NameFile);
                GlobalParam.PrintStatisticsHaveBeenReset();
                Console.ReadKey();
            }
        }

        public void PrintPrevLoadStatistics()
        {
            GlobalParam.PrintMenuPrevItems(CoorLoad, NameLoad);
        }
        public void PrintCurLoadStatistics()
        {
            GlobalParam.PrintMenuCurItems(CoorLoad, NameLoad);
        }

        public void PrintPrevResetStatistics()
        {
            GlobalParam.PrintMenuPrevItems(CoorResetFile, NameResetFile);
        }
        public void PrintCurResetStatistics()
        {
            GlobalParam.PrintMenuCurItems(CoorResetFile, NameResetFile);
        }
    }
}