using System;
using System.Collections.Generic;
using System.IO;

using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Database
{
    public sealed class DataFileManager : DataManager, IDataManager
    {

        private static readonly Lazy<DataFileManager> singletonInstance = 
            new Lazy<DataFileManager>(() => new DataFileManager());

        public static DataFileManager SingletonInstance
        {
            get
            {
                return singletonInstance.Value;
            }
        }

        private DataFileManager()
        {
        }
        
        public override void SaveResult(IPersonalScore score, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(score);
            }
        }

        public override void RestoreResults(ScoreBoardService scoreBoardService, string filePath)
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

            scoreBoardService.RestoreRecords(restoredResults);
        }

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
