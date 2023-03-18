using System;
using VigenereCipher;

namespace Vigenere
{
	public class VigenereCipher : IVigenere
	{
		public string EnglishAlphabet { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		private string ReplicateKey(string key, int DesiredLength)
		{
			var replicatedKey = key;
			do
			{
				replicatedKey += key;
			}
			while (replicatedKey.Length <= DesiredLength);

			return replicatedKey.Substring(0, DesiredLength);
		}

		private string Vigenere(string text, string key, bool encrypting = true)
		{
			var gamma = ReplicateKey(key, text.Length);
			var retValue = "";
			int alpabetLen = EnglishAlphabet.Length;
			int offset = encrypting ? 1 : -1;
			for (int i = 0; i < text.Length; i++)
			{
				var letterIndex = EnglishAlphabet.IndexOf(text[i]);
				var codeIndex = EnglishAlphabet.IndexOf(gamma[i]);

				retValue += letterIndex < 0 ?
				text[i].ToString() :
				EnglishAlphabet[(alpabetLen + letterIndex + offset * codeIndex) % alpabetLen].ToString();
			}

			return retValue;
		}


		public string Encode(string textToEncode, string key) => Vigenere(textToEncode, key);


		public string Decode(string textToDecode, string key) => Vigenere(textToDecode, key, false);
	}
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine("Шифр Виженера с 1 ключом");
			var cipher = new VigenereCipher();
			Console.Write("Введите текст: ");
			var inputText = Console.ReadLine().ToUpper();
			Console.Write("Введите ключ: ");
			var key = Console.ReadLine().ToUpper();
			var encryptedText = cipher.Encode(inputText, key);
			var decodeText = cipher.Decode(encryptedText, key);
			Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
			Console.WriteLine("Расшифрованное сообщение: {0}", decodeText);
			Console.ReadLine();
		}
	}
}
