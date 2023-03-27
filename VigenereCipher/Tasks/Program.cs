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
			VigenereCipher.VigenereCipher cipher = new VigenereCipher.VigenereCipher();
			Tasks tasks = new Tasks();
			try
			{
				Console.WriteLine("Шифр Виженера с 1 ключом");
				var plainText = tasks.ReadFromFile("File.txt").ToUpper();

				Console.Write("Введите ключ: ");
				var key = Console.ReadLine().ToUpper();

				var encodeStartTime = tasks.SetTime();
				var encodedText = cipher.Encode(plainText, key);
				var totalEncodeTime = tasks.GetDiff(encodeStartTime, tasks.SetTime());

				var decodeStartTime = tasks.SetTime();
				var decodedText = cipher.Decode(encodedText, key);
				var totalDecodeTime = tasks.GetDiff(decodeStartTime, tasks.SetTime());

				var plainTextStats = tasks.GetStatsFromText(plainText);
				var encodedTextStats = tasks.GetStatsFromText(encodedText);

				Console.WriteLine($"Зашифрованное сообщение: {encodedText}");
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine($"Расшифрованное сообщение: {decodedText}\n");
				Console.WriteLine($"Время затраченное на зашифровку : {totalEncodeTime}");
				Console.WriteLine($"Время затраченное на расшифровку: {totalDecodeTime}");
				Console.WriteLine("Статистика зашифрованного сообщения:");
				tasks.ShowStats(encodedTextStats);
				Console.WriteLine("Статистика расшифрованного сообщения:");
				tasks.ShowStats(plainTextStats);
				Console.WriteLine();
				tasks.WriteToFile("vigenereCipher.txt", encodedText);
				//
				Console.WriteLine("Шифр Виженера с 2-мя ключами");

				Console.Write("Введите ключ: ");
				key = Console.ReadLine().ToUpper();
				Console.Write("Введите ключ 2: ");
				var key2 = Console.ReadLine().ToUpper();

				encodeStartTime = tasks.SetTime();
				encodedText = cipher.Encode(plainText, key, key2);
				totalEncodeTime = tasks.GetDiff(encodeStartTime, tasks.SetTime());

				decodeStartTime = tasks.SetTime();
				decodedText = cipher.Decode(encodedText, key, key2);
				totalDecodeTime = tasks.GetDiff(decodeStartTime, tasks.SetTime());

				plainTextStats = tasks.GetStatsFromText(decodedText);
				encodedTextStats = tasks.GetStatsFromText(encodedText);

				Console.WriteLine($"Зашифрованное сообщение: {encodedText}"); ;
				Console.WriteLine("----------------------------------------------");
				Console.WriteLine($"Расшифрованное сообщение: {decodedText}\n");
				Console.WriteLine($"Время затраченное на зашифровку : {totalEncodeTime}");
				Console.WriteLine($"Время затраченное на расшифровку: {totalDecodeTime}");

				Console.WriteLine("Статистика зашифрованного сообщения:");
				tasks.ShowStats(encodedTextStats);
				Console.WriteLine("Статистика расшифрованного сообщения:");
				tasks.ShowStats(plainTextStats);
				tasks.WriteToFile("vigenereCipherWith2Keys.txt", encodedText);
				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка чтения файла: " + ex.Message);
			}

		}

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
			statistics += $"Число использованных символов: {counter}";
			Console.WriteLine(statistics);
		}


		public string ReadFromFile(string path)
		{
			using (StreamReader sr = new StreamReader(path))
			{
				return sr.ReadToEnd();
			}
		}
		public string WriteToFile(string path, string textToWrite)
		{
			using (StreamWriter writer = new StreamWriter(path, false))
			{
				writer.Write(textToWrite);
			}
			return "Запись в файл успешно завершена";
		}
		public DateTime SetTime() => DateTime.Now;
		public TimeSpan GetDiff(DateTime start, DateTime stop) => stop - start;
	}

}
