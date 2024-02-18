
public class Scripture
{
    private List<string> _references = new List<string>();
    private List<string> _verses = new List<string>();
    private List<Word> _wordObjects = new List<Word>();
    private Random _random = new Random();

    public void AddReference(string referencer)
    {
        _references.Add(referencer);
    }

    public void AddVerses(string verses)
    {
        _verses.Add(verses);
        var wordList = verses.Split(' ').Select(word => new Word(word)).ToList();
        _wordObjects.AddRange(wordList);
    }

    private int GetRandom()
    {
        return _random.Next(_verses.Count);
    }

    private string ChooseScripture()
    {
        int num = GetRandom();
        return _references[num];
    }

    public bool AllWordsHidden => _wordObjects.All(word => word.IsHidden);

    public void HideWord(int index)
    {
        if (index >= 0 && index < _wordObjects.Count)
            _wordObjects[index].Hide();
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = _wordObjects.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            int index = _random.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public void Display()
    {
        string display = ChooseScripture();
        Console.WriteLine($"\n{display}");
    }
}