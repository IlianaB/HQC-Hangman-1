﻿using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Database;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.Formatters;
using Hangman.Logic.Games;
using Hangman.Logic.Players;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words;
using Hangman.Logic.Words.Contracts;

namespace Hangman.WPF.UI
{
    public class WpfGame : Game
    {
        public override void Initialize()
        {
            base.Initialize();

            IScoreBoard scoreBoard = new ScoreBoard();
            IScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new WpfRenderer(new AllCapsFormatter(), new WpfWriter());
            IPlayer player = new Player();
            IWordProvider wordProvider = new WordProvider();
            IWordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            ICommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new WpfEngine(scoreBoardService, renderer, player, randomWordGenerator, commandFactory);

            this.Engine = gameEngine;
        }
    }
}
