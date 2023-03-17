namespace VigenereCipher
{
	public interface IVigenere
	{
		string EnglishAlphabet { get; set; }
		string Encode(string textToEncode, string key);
		string Decode(string textToDecode, string key);
	}
}
