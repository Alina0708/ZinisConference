namespace VigenereCipher
{
	public interface IVigenere
	{
		string EnglishAlphabet { get; }
		string Encode(string textToEncode, string key);
		string Encode(string textToEncode, string key, string key2);
		string Decode(string textToDecode, string key);
		string Decode(string textToDecode, string key, string key2);
	}
}
