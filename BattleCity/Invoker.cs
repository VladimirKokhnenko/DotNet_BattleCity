using System;
using System.Collections.Generic;
using Tanks.Patterns;

namespace BattleCity
{
    public class Invoker
    {
        private readonly ReceiverGame _rec;
        private readonly List<IComand> _comand;
        private int _curComand;

        public Invoker()
        {
            _comand = new List<IComand>();
            _rec = new ReceiverGame();

            _curComand = 0;
            _comand.Add(new NewGame(ref _rec));
            _comand.Add(new ContinueGame(ref _rec));


            var resStat = new ReceiverStatistics(_rec.Stk);
            _comand.Add(new LoadStatistisc(resStat));
            _comand.Add(new ResetStatistics(resStat));
            _comand.Add(new Exit());
        }

        public int CurComand
        {
            get => _curComand;

            set
            {
                if (value == _comand.Count)
                    _curComand = 0;
                else if (value == -1)
                    _curComand = _comand.Count - 1;
                else
                    _curComand = value;
            }
        }

        public void Function()
        {
            GlobalParam.PrintMenu(_comand);
            _comand[CurComand].PrintCurYourself();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.DownArrow:
                            {
                                _comand[CurComand].PrintPrevYourself();
                                CurComand += 1;
                                _comand[CurComand].PrintCurYourself();
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            {
                                _comand[CurComand].PrintPrevYourself();
                                CurComand -= 1;
                                _comand[CurComand].PrintCurYourself();
                            }
                            break;
                        case ConsoleKey.Enter:
                            {
                                _comand[CurComand].Execute();
                                GlobalParam.PrintMenu(_comand);
                                _comand[CurComand].PrintCurYourself();
                            }
                            break;
                        case ConsoleKey.Escape:
                            {
                                _comand[_comand.Count - 1].Execute();
                                GlobalParam.PrintMenu(_comand);
                                _comand[CurComand].PrintCurYourself();
                            }
                            break;
                    }
                }
            }
        }
    }
}