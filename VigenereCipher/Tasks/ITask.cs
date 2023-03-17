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
		DateTime GetDiff(DateTime start, DateTime stop); // => stop - start

		//Stats
		Dictionary<string, uint> GetStatsFromText(string text); // get count of each symbols

		void ShowStats(Dictionary<string, uint> dictionary);

	}
}
