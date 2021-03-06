﻿using System;
using Hangman.Logic.Commands;
using Hangman.Logic.Contracts;
using Hangman.Logic.Factories;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Factories
{
    [TestFixture]
    public class CommandFactoryTest
    {
        private CommandFactory commandFactory;
        private ICommandExecutable engine;

        [SetUp]
        public void Init()
        {
            var mockedCommandFactory = new Mock<CommandFactory>();
            var mockedICommandExecutable = new Mock<ICommandExecutable>();

            this.commandFactory = mockedCommandFactory.Object;
            this.engine = mockedICommandExecutable.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.commandFactory = null;
            this.engine = null;
        }

        [TestCase("start", typeof(StartCommand), "StartCommand")]
        [TestCase("top", typeof(TopCommand), "TopCommand")]
        [TestCase("help", typeof(HelpCommand), "HelpCommand")]
        [TestCase("restart", typeof(RestartCommand), "RestartCommand")]
        [TestCase("exit", typeof(ExitCommand), "ExitCommand")]
        [TestCase("asdf", typeof(NullCommand), "NullCommand")]
        public void TestCommands(string command, Type type, string name)
        {
            var result = this.commandFactory.GetGommand(this.engine, command);
            Assert.IsInstanceOf(type, result, name + " created correctly");
        }
    }
}