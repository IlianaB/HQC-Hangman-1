// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="DataFileManager.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;

using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Database
{
    /// <summary>
    /// DataFileManger is concrete implementation of DataManager class. 
    /// It is responsible for the communication with the database.
    /// Singleton with Lazy Initialization. It is initialized at its first usage.
    /// </summary>
    public sealed class DataFileManager : DataManager, IDataManager
    {
        private static readonly Lazy<DataFileManager> SingletonDataFileManager = 
            new Lazy<DataFileManager>(() => new DataFileManager());

        private DataFileManager()
        {
        }

        /// <summary>
        /// Property returning the Singleton DataFileManager instance.
        /// </summary>
        public static DataFileManager SingletonInstance
        {
            get
            {
                return SingletonDataFileManager.Value;
            }
        }
       
        /// <summary>
        /// Saves the received IPersonalScore in the database.
        /// </summary>
        /// <param name="score">
        /// The score of the current player.
        /// </param>
        /// <param name="filePath">
        /// The path to the file, which acts as a database.
        /// </param>
        public override void SaveResult(IPersonalScore score, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(score);
            }
        }

        /// <summary>
        /// Reads the result from the database and restores them as a C# objects.
        /// </summary>
        /// <param name="scoreBoardService">
        /// The current ScoreBoardService.
        /// </param>
        /// <param name="filePath">
        /// The path to the file, which acts as a database.
        /// </param>
        public override void RestoreResults(IScoreBoardService scoreBoardService, string filePath)
        {
            IList<string> allResults = this.ReadAllResults(filePath);
            IList<IPersonalScore> restoredResults = new List<IPersonalScore>();

            foreach (var result in allResults)
            {
                string[] record = result.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = record[0];
                int score = int.Parse(record[1]);

                IPersonalScore newRecord = new PersonalScore(name, score);
                restoredResults.Add(newRecord);
            }

            scoreBoardService.RestoreScores(restoredResults);
        }

        /// <summary>
        /// Reads all results from the database.
        /// </summary>
        /// <param name="filePath">
        /// The path to the database.
        /// </param>
        /// <returns>
        /// Collection with all results as strings.
        /// </returns>
        private List<string> ReadAllResults(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                List<string> results = new List<string>();

                while (line != null)
                {
                    results.Add(line);
                    line = reader.ReadLine();
                }

                return results;
            }
        }
    }
}
