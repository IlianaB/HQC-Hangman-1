namespace Hangman.Logic.Words.Contracts
{
    public interface IGuessWord
    {
        string Content { get; set; }

        char[] Mask { get; set; }

        char RevealLetter();

        int GetNumberOfOccurences(char letter);
    }
}
