using System;
using System.Collections.Generic;

namespace Tasks
{
	public interface ITask
	{
		//IO File
		string ReadFromFile(string path);
		string WriteToFile(string path, string textToWrite);

		//Timers
		DateTime SetTime(); // => DateTime.Now
		TimeSpan GetDiff(DateTime start, DateTime stop); // => stop - start

		//Stats
		Dictionary<char, uint> GetStatsFromText(string text); // get count of each symbols

		void ShowStats(Dictionary<char, uint> dictionary);

	}
}
