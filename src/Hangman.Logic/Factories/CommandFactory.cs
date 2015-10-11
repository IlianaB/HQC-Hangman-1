// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="CommandFactory.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Commands;
using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Factories
{
    /// <summary>
    /// Simple Factory.
    /// Creates a concrete implementation of ICommand depending on the received string.
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        /// <summary>
        /// Creates a concrete implementation of ICommand depending on the received string.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        /// <param name="command">
        /// The command as a string.
        /// </param>
        /// <returns>
        /// The concrete command.
        /// </returns>
        public ICommand GetGommand(ICommandExecutable engine, string command)
        {
            switch (command)
            {
                case "start": 
                    return new StartCommand(engine);
                case "top": 
                    return new TopCommand(engine);
                case "help": 
                    return new HelpCommand(engine);
                case "restart": 
                    return new RestartCommand(engine);
                case "exit": 
                    return new ExitCommand(engine);
                default: 
                    return new NullCommand(engine);
            }
        }
    }
}
