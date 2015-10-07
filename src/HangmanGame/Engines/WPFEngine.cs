﻿using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Engines
{
    public class WPFEngine : GameEngine
    {
        public WPFEngine(IScoreBoard scoreBoard, ScoreBoardService scoreBoardService, IRenderer renderer,
                        IPlayer player, WordGenerator wordGenerator, ICommandFactory commandFactory)
            : base(scoreBoard, scoreBoardService, renderer, player, wordGenerator, commandFactory)
        {
        }

        protected override void SaveResult(IPersonalScore newRecord)
        {
            DataFileManager.SingletonInstance.SaveResult(newRecord, Constants.FilePathWPFGame);
        }
    }
}
