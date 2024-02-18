

public class Reference
{
    private string book;
    private string chapter;


    public Reference(string book, string chapter)
    {
        this.book = book;
        this.chapter = chapter;
    }

    public string makeReference()
    {
        return $"{this.book} {this.chapter}";
    }

}