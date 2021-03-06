﻿// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IScoreBoard.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IScoreBoard
    {
        /// <summary>
        /// Gets or sets the collection with personal records
        /// </summary>
        IList<IPersonalScore> Records { get; set; }
    }
}
