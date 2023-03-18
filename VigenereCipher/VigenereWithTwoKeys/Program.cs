using VigenereCipher;
using System;

namespace Vigenere
{
	public class VigenereWithTwoKeys : VigenereCipher
	{
		public string Decode(string textToDecode, string key, string key2) =>
			Decode(Decode(textToDecode, key), key2);

		public string Encode(string textToEncode, string key, string key2) =>
            Encode(Encode(textToEncode, key), key2);

		static void Main()
		{
			Console.WriteLine("Шифр Виженера с 2-мя ключами");
			VigenereWithTwoKeys vigenereWithTwoKeys = new VigenereWithTwoKeys();
			Console.Write("Введите текст: ");
			var inputText = Console.ReadLine().ToUpper();
			Console.Write("Введите ключ: ");
			var key = Console.ReadLine().ToUpper();
			Console.Write("Введите ключ 2: ");
			var key2 = Console.ReadLine().ToUpper();
			var encryptedText = vigenereWithTwoKeys.Encode(inputText, key, key2);
			var decodeText = vigenereWithTwoKeys.Decode(encryptedText, key, key2);
			Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
			Console.WriteLine("Расшифрованное сообщение: {0}", decodeText);
			Console.ReadLine();

		}

	}
}
