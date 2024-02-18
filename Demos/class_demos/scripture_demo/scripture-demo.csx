using Internal;

// The ScriptureReference class encapsulates the details of a scripture reference
// and provides methods to interact with it. This abstraction hides implementation details
// from external users.
public class ScriptureReference {

  // Private members encapsulate the state of a scripture reference.
  private string book;
  private int chapter;
  private string verse;

  // The actual Scripture text is encapsulated in a separate class.
  // This abstraction separates concerns into different classes.
  private Scripture text;

  // Constructor encapsulates creation of a Scripture instance.
  public ScriptureReference(string book, int chapter, string verse, string text) {
    this.book = book;
    this.chapter = chapter;
    this.verse = verse;
    this.text = new Scripture(text);
  }

  // Method encapsulates logic to hide words in scripture text.
  public void HideWords(int numToHide = 3) {
    this.text.HideWords(numToHide);
  }

  // Abstraction of details into string representation.
  public override string ToString() {
    return $"{this.book} {this.chapter}:{this.verse}\n{this.text}";
  }

  // Encapsulates printing the full scripture reference.
  public void ViewScriptue() {
    Console.WriteLine($"{this.ToString()}");
  }

  // Encapsulates printing just the scripture text words.
  public void ViewScriptueParts() {
    this.text.ViewWords();
  }
}

// The Scripture class encapsulates words in scripture text.
// It abstracts scripture into a collection of Word objects.
public class Scripture {
  
  // Encapsulates words as private member.
  private List<Word> words;

  // Constructor encapsulates splitting text into Word objects.
  public Scripture(string text) {
    this.words = text.Split(' ').Select((w, i) => new Word(w, i)).ToList();
  }

  // Method encapsulates logic to hide random words.
  public void HideWords(int numToHide = 3) {

    Random rnd = new Random();

    int availableWordCount = this.words.Count(w => !w.IsHidden());
    numToHide = Math.Min(numToHide, availableWordCount);

    for (int i = 0; i < numToHide; i++) {

      int index = rnd.Next(0, this.words.Count);
      while (this.words[index].IsHidden()) {
        index = rnd.Next(0, this.words.Count);
      }

      this.words[index].Hide();
    }
  }

  // Abstraction of words into string representation.
  public override string ToString() {
    
    string scriptureText = "";

    foreach (Word word in this.words) {
      scriptureText += word.ToString() + " ";
    }

    return scriptureText.Trim();

    // This whole method could be simplified to: 
    // return String.Join(" ", this.words.Select(w => w.ToString()));
  }

  // Encapsulates logic to print words.
  public void ViewWords() {
    foreach (Word word in this.words) {
      Console.WriteLine($"{word.GetIndex().ToString().PadRight(3)} {word.IsHidden().ToString().PadRight(6)} {word}");
    }
  }
}

// Word class encapsulates data and behavior of a single word.
public class Word {

  // Private members encapsulate state.
  private string text;
  private bool hidden;
  private int index;

  // Constructors to initialize.
  public Word(string text) {
    this.text = text; 
  }

  public Word(string text, int index) {
    this.text = text;
    this.index = index;
  }

  // Getters encapsulate access to private state.
  public int GetIndex() {
    return this.index;
  }

  // Methods to modify state.
  public void Hide() {
    this.hidden = true;
  }

  public bool IsHidden() {
    return this.hidden; 
  }

  // Abstraction method.
  public override string ToString() {
    if (!this.hidden) {
      return this.text;
    }

    int len = this.text.Length;
    string output = "";
    
    while (len > 0) {
      output += "_";
      len -= 1;
    }

    return output;
  }
}

// Client code using the ScriptureReference abstraction.

ScriptureReference scriptRef = new ScriptureReference(
  "Alma",
  37,
  "7",
  "And the Lord God doth work by means to bring about his great and eternal purposes; and by very small means the Lord doth confound the wise and bringeth about the salvation of many souls."
);

Console.WriteLine("\n[ VIEW SCRIPTUTRE ]\n");
scriptRef.ViewScriptue();

Console.WriteLine("\n[ VIEW SCRIPTUTRE IN PARTS ]\n");  
scriptRef.ViewScriptueParts();

Console.WriteLine("\n[ VIEW SCRIPTUTRE IN HIDDEN PARTS ]\n");
scriptRef.HideWords(11);
scriptRef.ViewScriptueParts();