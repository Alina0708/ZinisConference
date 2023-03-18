using System;
using VigenereCipher;

namespace Vigenere
{
	public class VigenereCipher : IVigenere
	{
		public string EnglishAlphabet { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		
		private string GetRepeatKey(string key, string text)
		{
			var KeyDuplication = key;
			do
			{
				KeyDuplication += KeyDuplication;
			}
			while (KeyDuplication.Length < text.Length);


			return KeyDuplication.Substring(0, text.Length);
		}

		private string Vigenere(string text, string key, bool encrypting = true)
		{
			var gamma = GetRepeatKey(key, text);
			var retValue = "";

			for (int i = 0; i < text.Length; i++)
			{
				var letterIndex = EnglishAlphabet.IndexOf(text[i]);
				var codeIndex = EnglishAlphabet.IndexOf(gamma[i]);

				retValue += letterIndex < 0 ? 
			    text[i].ToString(): 
				EnglishAlphabet[(EnglishAlphabet.Length + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % EnglishAlphabet.Length].ToString();
			}

			return retValue;
		}


		public string Encode(string textToEncode, string key)
		{
			return Vigenere(textToEncode, key);		
		}

		public string Decode(string textToDecode, string key)
		{
			return Vigenere(textToDecode, key, false);
		}
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
