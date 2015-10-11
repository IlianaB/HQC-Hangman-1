using System;
using Hangman.Logic.Formatters;
using Hangman.Logic.ScoreBoardServices;
using NUnit.Framework;

namespace HagmanGameTests.Formatters
{
    [TestFixture]
    public class FormatterTest
    {
        [Test]
        public void TestFormat()
        {
            var player = new PersonalScore("pLaYer", 1);

            var formatter = new AllCapsFormatter();
            var result = formatter.Format(player);
            var expect = "PLAYER ---> 1 MISTAKE(S)!";

            Assert.IsTrue(expect == result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIncorrectPlayerInformationToThrowException()
        {
            var formatter = new AllCapsFormatter();
            var result = formatter.Format(null);
            var expect = "PLAYER ---> 1 MISTAKE(S)!";

            Assert.IsTrue(expect == result);
        }

        [Test]
        public void TestCapitalizeFormatter()
        {
            var player = new PersonalScore("pLaYer", 1);

            var formatter = new CapitalizeFormatter();
            var result = formatter.Format(player);
            var expect = "Player ---> 1 mistake(s)!";

            Assert.IsTrue(expect == result);
        }
    }
}
