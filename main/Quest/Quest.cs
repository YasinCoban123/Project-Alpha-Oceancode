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

    public void QuestCompleted()
    {
        IsCompleted = true;
        Console.WriteLine($"Quest completed: {QuestTitle}");
    }

    public void FarmersFieldQuest()
    {
        bool questAccepted = false;
        bool firstAttempt = true;

        while (questAccepted is false)
        {
            if (firstAttempt)
            {
                Console.WriteLine("Farmer: Boy! I knew I'd find you snooping around here.");
                Console.WriteLine("Farmer: Word travels fast 'round these parts... I heard about your poor mother.");
                Console.WriteLine("Farmer: You’re looking for that healing herb, aren’t ya? Well, I might just have what you need.");
                Console.WriteLine("Farmer: But nothing comes for free, even in times like these.");
                Console.WriteLine("Farmer: My field’s crawling with damn rats. Three of the vermin are running wild in my crops.");
                Console.WriteLine("Farmer: Help me take care of them, and I’ll give you the ingredient for your ma.");
            }
            else
            {
                Console.WriteLine("Farmer: Back again, boy?");
                Console.WriteLine("Farmer: My offer still stands — you help me with those rats, and I’ll help you help your mother.");
            }
            Console.WriteLine("Do you want to accept the quest? (yes/no)");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                questAccepted = true;
                World.QuestByID(World.QUEST_ID_CLEAR_FARMERS_FIELD).QuestStarted();
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
        bool questAccepted = false;
        bool firstAttempt = true;

        while (questAccepted is false)
        {
            if (firstAttempt)
            {
                Console.WriteLine("Alchemist: Ah, young one. I’ve heard of your search... your mother’s illness weighs heavy, I’m sure.");
                Console.WriteLine("Alchemist: You're after a rare herb, yes? One I happen to grow right here in my garden.");
                Console.WriteLine("Alchemist: However... my garden has become dangerous. Three venomous snakes have slithered their way in.");
                Console.WriteLine("Alchemist: I can’t harvest anything while they’re lurking about.");
                Console.WriteLine("Alchemist: Rid me of those snakes, and the herb is yours.");
            }
            else
            {
                Console.WriteLine("Alchemist: Still seeking the herb? The snakes remain, and so does my offer.");
                Console.WriteLine("Alchemist: Three of them. Silent, deadly, and coiled beneath my roses.");
            }

            Console.WriteLine("Do you want to accept the quest? (yes/no)");
            string response = Console.ReadLine().ToLower();

            if (response == "yes")
            {
                questAccepted = true;
                World.QuestByID(World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN).QuestStarted();
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
        bool questAccepted = false;
        bool firstAttempt = true;

        while (questAccepted is false)
        {
            if (firstAttempt)
            {
                Console.WriteLine("Guard: Hold on, boy.");
                Console.WriteLine("Guard: That forest beyond this gate is crawling with giant spiders.");
                Console.WriteLine("Guard: I know you’re looking for a rare ingredient to save your mother — spider silk.");
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
                World.QuestByID(World.QUEST_ID_COLLECT_SPIDER_SILK).QuestStarted();
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
}