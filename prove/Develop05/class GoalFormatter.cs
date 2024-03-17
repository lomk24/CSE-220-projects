class GoalFormatter
{
    public List<string> FormatGoals(List<string> goalsList)
    {
        List<string> formattedGoals = new List<string>();

        foreach(string goal in goalsList)
        {
            string[] parts = goal.Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");


        switch(type)
            {
                case "SimpleGoal":
                    if(data[3] == "true")
                    {formattedGoals.Add($"[X] {data[0]} ({data[1]})");}
                    else
                    {formattedGoals.Add($"[ ] {data[0]} ({data[1]})");}
                    break;
                case "EternalGoal":
                    formattedGoals.Add($"[ ] {data[0]} ({data[1]})");
                    break;
                case "ChecklistGoal":
                    if(data[4] == data[5])
                        {formattedGoals.Add($"[X] {data[0]} ({data[1]}) --- Currently completed: {data[5]}/{data[4]}");}
                    else
                        {formattedGoals.Add($"[ ] {data[0]} ({data[1]}) --- Currently completed: {data[5]}/{data[4]}");}
                    break;
            }
            
        }
        return formattedGoals;
    }
}