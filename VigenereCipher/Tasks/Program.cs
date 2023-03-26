using System;
using System.Collections.Generic;
using System.IO;

namespace Tasks
{
	internal class Tasks : ITask
	{
		private readonly Dictionary<char, uint> alphabetEntities = new Dictionary<char, uint>();
		static void Main()
		{
			var tasks = new Tasks();
			var inputText = tasks.ReadFromFile("D:/conference/file.txt");
			Console.WriteLine(inputText);
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
		public string ReadFromFiles(string path)
		{
			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					string fileContent = sr.ReadToEnd();

					return fileContent;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка чтения файла: " + ex.Message);
				return null;
			}
		}

		public string WriteToFile(string path, string textToWrite)
		{
			throw new NotImplementedException();
		}

		public string ReadFromFile(string path) => ReadFromFiles(path);
	}

}
