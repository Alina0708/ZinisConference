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
			try
			{
			Console.WriteLine("Шифр Виженера с 1 ключом");

			VigenereCipher.VigenereCipher cipher = new VigenereCipher.VigenereCipher();
			var tasks = new Tasks();
			var inputText = tasks.ReadFromFile("File.txt").ToUpper();

			Console.Write("Введите ключ: ");
			var key = Console.ReadLine().ToUpper();

			var startEncode = tasks.SetTime();
			var encryptedText = cipher.Encode(inputText, key);
            var stopEncode = tasks.SetTime();

			var startDecode = tasks.SetTime();
			var decodeText = cipher.Decode(encryptedText, key);
			var stopDecode = tasks.SetTime();

			var timeEncode = tasks.GetDiff(startEncode, stopEncode);
			var timeDecode = tasks.GetDiff(startDecode, stopDecode);

			var statsInput = tasks.GetStatsFromText(decodeText);
			var statsEncode = tasks.GetStatsFromText(encryptedText);

			Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("Расшифрованное сообщение: {0}", decodeText);

			Console.WriteLine();
			tasks.WriteToFile("vigenereCipher.txt", encryptedText);
			Console.WriteLine("Время затраченное на зашифровку : {0}", timeEncode);
			Console.WriteLine("Время затраченное на расшифровку: {0}", timeDecode);

			Console.WriteLine("Статистика зашифрованного сообщения:");
			tasks.ShowStats(statsEncode);
			Console.WriteLine("Статистика расшифрованного сообщения:");
			tasks.ShowStats(statsInput);
			Console.WriteLine();




			Console.WriteLine("Шифр Виженера с 2-мя ключами");

			Console.Write("Введите ключ: ");
			key = Console.ReadLine().ToUpper();
			Console.Write("Введите ключ 2: ");
			var key2 = Console.ReadLine().ToUpper();

			startEncode = tasks.SetTime();
			encryptedText = cipher.Encode(inputText, key, key2);
			stopEncode = tasks.SetTime();

			startDecode = tasks.SetTime();
			decodeText = cipher.Decode(encryptedText, key, key2);
			stopDecode = tasks.SetTime();

			statsInput = tasks.GetStatsFromText(decodeText);
			statsEncode = tasks.GetStatsFromText(encryptedText);

			Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine("Расшифрованное сообщение: {0}", decodeText);
			Console.WriteLine();

			tasks.WriteToFile("vigenereCipherWith2Keys.txt", encryptedText);
			Console.WriteLine("Время затраченное на зашифровку : {0}", tasks.GetDiff(startEncode, stopEncode));
			Console.WriteLine("Время затраченное на расшифровку: {0}", tasks.GetDiff(startDecode, stopDecode));

			Console.WriteLine("Статистика зашифрованного сообщения:");
			tasks.ShowStats(statsEncode);
			Console.WriteLine("Статистика расшифрованного сообщения:");
			tasks.ShowStats(statsInput);

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
			statistics += $"Всего символов: {counter}";
			Console.WriteLine(statistics);
		}
		

		public string ReadFromFile(string path) {

				using (StreamReader sr = new StreamReader(path))
				{
					string fileContent = sr.ReadToEnd();

					return fileContent;
				}
		}
		public string WriteToFile(string path, string textToWrite) {

				using (StreamWriter writer = new StreamWriter(path, false))
				{
					writer.Write(textToWrite);
				}
				Console.WriteLine("Запись в файл успешно завершена");
				return "Запись в файл успешно завершена";
		}
		public DateTime SetTime() => DateTime.Now;
		public TimeSpan GetDiff(DateTime start, DateTime stop) => stop - start;
	}

}
