class Editor
{
    public List<string> GoalsFormat(List<string> goalsList)
    {
        List<string> goalsFormatted = new List<string>();
        int listingNumbers = 1;
        foreach(string goal in goalsList)
        {
            string[] parts = goal.Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            goalsFormatted.Add($"{listingNumbers}. {data[0]}");
            listingNumbers += 1;

        }
        return goalsFormatted;
    }
}
