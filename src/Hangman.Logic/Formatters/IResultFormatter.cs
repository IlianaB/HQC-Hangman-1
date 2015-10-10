﻿// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IResultFormatter.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Formatters
{
    /// <summary>
    /// Declares all methods that its implementation must have.
    /// </summary>
    public interface IResultFormatter
    {
        string Format(IPersonalScore record);
    }
}
