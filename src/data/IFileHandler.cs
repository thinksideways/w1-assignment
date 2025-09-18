public interface IFileHandler
{
    List<Character> ReadCharacters(string filePath);
    void WriteCharacters(string filePath, List<Character> characters);
}