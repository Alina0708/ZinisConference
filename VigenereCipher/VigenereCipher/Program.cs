using System;

namespace VigenereCipher
{
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

			Console.WriteLine("Шифр Виженера с 2-мя ключами");
			Console.Write("Введите текст: ");
			inputText = Console.ReadLine().ToUpper();
			Console.Write("Введите ключ: ");
			key = Console.ReadLine().ToUpper();
			Console.Write("Введите ключ 2: ");
			var key2 = Console.ReadLine().ToUpper();
			encryptedText = cipher.Encode(inputText, key, key2);
			decodeText = cipher.Decode(encryptedText, key, key2);
			Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
			Console.WriteLine("Расшифрованное сообщение: {0}", decodeText);
			Console.ReadLine();
		}
	}
}
