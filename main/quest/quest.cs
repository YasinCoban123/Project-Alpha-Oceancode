using System;

public class Quest
{
    public int ID;
    public string QuestTitle;
    public string Description;
    public bool IsCompleted;

    public Quest(int id, string questTitle, string description)
    {
        ID = id;
        QuestTitle = questTitle;
        Description = description;
        IsCompleted = false;
    }

    public void QuestStarted()
    {
        Console.WriteLine($"Quest started: {QuestTitle}");
        Console.WriteLine(Description);
    }

    public void TriggerQuest(Player player)
    {
        if (IsCompleted)
        {
            if (ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN)
                Console.WriteLine("Alchemist: My thanks again. The rats are gone and my garden is safe.");
            else if (ID == World.QUEST_ID_CLEAR_FARMERS_FIELD)
                Console.WriteLine("Farmer: You’ve already helped me. I owe you much, boy.");
            else if (ID == World.QUEST_ID_COLLECT_SPIDER_SILK)
                Console.WriteLine("Guard: You’ve proven yourself already. The gate is open to you.");
            return;
        }

        if (ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN)
            AlchemistGardenQuest();
        else if (ID == World.QUEST_ID_CLEAR_FARMERS_FIELD)
            FarmersFieldQuest();
        else if (ID == World.QUEST_ID_COLLECT_SPIDER_SILK)
            GuardSpiderQuest();
    }

    public void FarmersFieldQuest()
    {
        if (IsCompleted)
        {
            Console.WriteLine("Farmer: You’ve already helped me. I owe you much, boy.");
            return;
        }

        bool questAccepted = false;
        bool firstAttempt = true;

        while (!questAccepted)
        {
            if (firstAttempt)
            {
                Console.WriteLine("Farmer: Boy! I knew I'd find you snooping around here.");
                Console.WriteLine("Farmer: Word travels fast 'round these parts... I heard about your poor mother.");
                Console.WriteLine("Farmer: You’re looking for that healing herb, aren’t ya? Well, I might just have what you need.");
                Console.WriteLine("Farmer: But nothing comes for free, even in times like these.");
                Console.WriteLine("Farmer: My field’s crawling with damn snakes. Three of the reptiles are running wild in my crops.");
                Console.WriteLine("Farmer: Help me take care of them, and I’ll give you the ingredient for your ma.");
            }
            else
            {
                Console.WriteLine("Farmer: Back again, boy?");
                Console.WriteLine("Farmer: My offer still stands — you help me with those snakes, and I’ll help you help your mother.");
            }

            Console.WriteLine("Do you want to accept the quest? (yes/no)");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                questAccepted = true;
                QuestStarted();
            }
            else if (response == "no")
            {
                Console.WriteLine("Farmer: I see. Well, if you change your mind, come back anytime.");
                firstAttempt = false;
            }
            else
            {
                Console.WriteLine("Please answer with 'yes' or 'no'.");
            }
        }
    }

    public void AlchemistGardenQuest()
    {
        if (IsCompleted)
        {
            Console.WriteLine("Alchemist: My thanks again, young one. The rats are gone and my garden is safe.");
            return;
        }

        bool questAccepted = false;
        bool firstAttempt = true;

        while (!questAccepted)
        {
            if (firstAttempt)
            {
                Console.WriteLine("Alchemist: Ah, young one. I’ve heard of your search... your mother’s illness weighs heavy, I’m sure.");
                Console.WriteLine("Alchemist: You're after a rare herb, yes? One I happen to grow right here in my garden.");
                Console.WriteLine("Alchemist: However... my garden has become dangerous. Three rabies-infected rats have forced their way in.");
                Console.WriteLine("Alchemist: I can’t harvest anything while they’re lurking about.");
                Console.WriteLine("Alchemist: Rid me of those rats, and the herb is yours.");
            }
            else
            {
                Console.WriteLine("Alchemist: Still seeking the herb? The rats remain, and so does my offer.");
                Console.WriteLine("Alchemist: Three of them. Silent, deadly, and nibbling on my roses.");
            }

            Console.WriteLine("Do you want to accept the quest? (yes/no)");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                questAccepted = true;
                QuestStarted();
            }
            else if (response == "no")
            {
                Console.WriteLine("Alchemist: I understand. Bravery takes time. Return when your heart is ready.");
                firstAttempt = false;
            }
            else
            {
                Console.WriteLine("Alchemist: A simple 'yes' or 'no' will suffice.");
            }
        }
    }

    public void GuardSpiderQuest()
    {
        if (IsCompleted)
        {
            Console.WriteLine("Guard: You’ve proven yourself already. The gate is open to you.");
            return;
        }

        bool questAccepted = false;
        bool firstAttempt = true;

        while (!questAccepted)
        {
            if (firstAttempt)
            {
                Console.WriteLine("Guard: Hold on, boy.");
                Console.WriteLine("Guard: That forest beyond this gate is crawling with giant spiders.");
                Console.WriteLine("Guard: I know you’re looking for a rare ingredient to save your mother — elixir potion.");
                Console.WriteLine("Guard: But you can’t just wander in unprepared.");
                Console.WriteLine("Guard: Accept this task: collect three strands of spider silk from those monsters.");
                Console.WriteLine("Guard: Only then will I let you pass through this gate.");
            }
            else
            {
                Console.WriteLine("Guard: Waiting on those spider silks, boy.");
                Console.WriteLine("Guard: Prove yourself capable — bring me three strands, and the gate will open.");
            }

            Console.WriteLine("Do you want to accept the quest? (yes/no)");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                questAccepted = true;
                QuestStarted();
                Console.WriteLine("Guard: Good. Now get going, and don’t come back empty-handed.");
            }
            else if (response == "no")
            {
                Console.WriteLine("Guard: Then step aside. This gate isn’t for the faint-hearted.");
                firstAttempt = false;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Guard: Answer me clearly, boy. Yes or no.");
            }
        }
    }

    public void QuestCompleted(Player player)
    {
        if (IsCompleted) return;

        IsCompleted = true;
        Console.WriteLine($"\nQuest completed: {QuestTitle}");

        if (ID == World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN)
        {
            Console.WriteLine("Alchemist: Incredible! You defeated the rats.");
            player.Inventory.AddItem(new Item("Rare Herb"));
            player.LearnSkill(new Skill("Fireball", 10, "A basic fire attack.")); // skill reward
        }
        else if (ID == World.QUEST_ID_CLEAR_FARMERS_FIELD)
        {
            Console.WriteLine("Farmer: Well done! The snakes won’t ruin my crops anymore.");
            player.Inventory.AddItem(new Item("Farm Ingredient"));
            player.LearnSkill(new Skill("Poison Strike", 8, "Deals extra damage to snakes.")); // skill reward
        }
        else if (ID == World.QUEST_ID_COLLECT_SPIDER_SILK)
        {
            Console.WriteLine("Guard: You’ve returned with spider silk!");
            player.Inventory.AddItem(new Item("Elixir Potion"));
        }

        if (player.Inventory.HasAllQuestItems())
        {
            Console.WriteLine("\n--- Ending ---");
            Console.WriteLine("You return home with all the ingredients...");
            Console.WriteLine("Your mother drinks the cure, her color returns, and she hugs you with tears in her eyes.");
            Console.WriteLine("You’ve saved her life. You are now a true hero.");
            Environment.Exit(0);
        }
    }
}
