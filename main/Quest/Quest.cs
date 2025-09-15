public class Quest
{
    public string QuestTitle;
    public string Description;
    public bool IsCompleted;

    public Quest(string questTitle, string description)
    {
        QuestTitle = questTitle;
        Description = description;
        IsCompleted = false;
    }
    
    public void QuestStarted()
    {
        Console.WriteLine($"Quest gestart: {QuestTitle}");
        Console.WriteLine(Description);
    }

    public void QuestCompleted()
    {
        IsCompleted = true;
        Console.WriteLine($"Quest voltooid: {QuestTitle}");

    }
}