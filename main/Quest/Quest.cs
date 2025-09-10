public class Quest
{
    public int ID; // Unieke quest ID
    public string QuestTitle;
    public string Description;
    public int RewardGold;
    public bool IsCompleted;

    public Quest(int id, string questTitle, string description, int rewardGold = 0)
    {
        ID = id;
        QuestTitle = questTitle;
        Description = description;
        RewardGold = rewardGold;
        IsCompleted = false;
    }

    public void Complete()
    {
        IsCompleted = true;
        
    }
}