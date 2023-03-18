using System;
using System.Collections.Generic;

namespace Tasks
{
	internal class Tasks : ITask
	{
		private readonly Dictionary<char, uint> alphabetEntities = new Dictionary<char, uint>();
		static void Main()
		{

		}

		public DateTime SetTime() => DateTime.Now;
		public TimeSpan GetDiff(DateTime start, DateTime stop) => stop - start;

		public Dictionary<char, uint> GetStatsFromText(string text)
		{
			foreach (var symbol in text.ToUpper())
			{
				if (alphabetEntities.TryGetValue(symbol, out _))
					alphabetEntities[symbol] += 1;

				else alphabetEntities.Add(symbol, 1);
			}
			return alphabetEntities;
		}

		public void ShowStats(Dictionary<char, uint> dictionary)
		{
			uint counter = 0;
			string statistics = "";
			var keys = dictionary.Keys;
			foreach (var key in keys)
			{
				statistics += $"{key}: {dictionary[key]}\n";
				counter++;
			}
			statistics += $"Всего символов: {counter}";
			Console.WriteLine(statistics);
		}
		public string ReadFromFile(string path)
		{
			throw new NotImplementedException();
		}

		public string WriteToFile(string path, string textToWrite)
		{
			throw new NotImplementedException();
		}
	}

}
