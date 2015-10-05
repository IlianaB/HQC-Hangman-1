using System;
using System.Collections.Generic;
using System.IO;

using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Database
{
    public class DataFileManager : DataManager, IDataManager
    {
        private readonly string uri = @"../../../src/HangmanGame/Database/Results.txt";

        public override void SaveResult(IPersonalScore score)
        {
            using (StreamWriter writer = new StreamWriter(this.uri, true))
            {
                writer.WriteLine(score);
            }
        }

        public override void RestoreResults(ScoreBoardService scoreBoardService)
        {
            IList<string> allResults = this.ReadAllResults();

            foreach (var result in allResults)
            {
                string[] record = result.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = record[0];
                int score = int.Parse(record[1]);

                IPersonalScore newRecord = new PersonalScore(name, score);
                scoreBoardService.AddNewScore(newRecord);
            }
        }

        private List<string> ReadAllResults()
        {
            using (StreamReader reader = new StreamReader(this.uri))
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
