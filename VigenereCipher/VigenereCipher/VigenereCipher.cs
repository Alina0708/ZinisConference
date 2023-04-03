namespace VigenereCipher
{
	public class VigenereCipher : IVigenere
	{
		public static string EnglishAlphabet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ,;:' !*.?";
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
			var result = "";
			int alpabetLen = EnglishAlphabet.Length;
			int offset = encrypting ? 1 : -1;
			for (int i = 0; i < text.Length; i++)
			{
				var letterIndex = EnglishAlphabet.IndexOf(text[i]);
				var codeIndex = EnglishAlphabet.IndexOf(gamma[i]);

				result += letterIndex < 0 ?
				text[i].ToString() :
				EnglishAlphabet[(alpabetLen + letterIndex + offset * codeIndex) % alpabetLen].ToString();
			}
			return result;
		}


		public string Decode(string textToDecode, string key) => Vigenere(textToDecode, key, false);
		public string Encode(string textToEncode, string key) => Vigenere(textToEncode, key);
		public string Decode(string textToDecode, string key, string key2) =>
			Decode(Decode(textToDecode, key), key2);
		public string Encode(string textToEncode, string key, string key2) =>
			Encode(Encode(textToEncode, key), key2);
	}
}
