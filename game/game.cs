using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "Dungeon of a Hundred Floors";

        Random rand = new Random();
        string playername; // Creates a string to store the player's name
        string menuinput;
        string playerclass;
        string classdescstr;
        playername = "Adventurer"; // Backup name in case of null value return
        string classnum;
        int classnumint;
        string currentWeapon;
        classnumint = 9;
        int weaponCount;
        int scrollCount;
        int potionCount;
        weaponCount = 3; // Sets default weapon as Dagger
        scrollCount = 0;
        potionCount = 1;

        // DEFAULT STORAGE
        string[] quick_names = { "Alex", "Alexander", "Frederik", "Alexandrov", "Thomas", "Randal", "Tom", "Freddy", "Noah", "Peter", "John", "Josh", "Jessie", "Frank", "Phil", "Hugo Cortell The Great", "Otto", "Zariel", "Ronald", "Gerald", "Daniel", "Dan", "Dorothy", "Ivan", "Jack", "Zorreh", "Timmy", "Torre", "Jose", "Juan", "Larry", "Poopy mcpooper", "Uto", "Lincon", "Tedward", "Ed", "Edd", "Eddy", "Ester" };
        string[] quick_class = { "Warrior", "Ranger", "Rouge", "Mage", "Samurai", "Blacksmith", "Guard", "Pirate", "Peasant", "Alchemist" };
        string[] classdesc = { "You clearly know your way around a sword.", "I wonder how many arrows that quiver of yours holds...", "You better not have stolen anything while we were speaking.", "Your magic tricks wont be of much use down there. I hope you know how to use a sword." };
        string[] weapon_list = { "Sword", "Bow", "Dagger", "Staff", "Katana", "Hammer", "Spear", "Cutlass", "Fists", "Broken Glass Bottle", "Broadsword", "Shortsword", "Warhammer", "Club", "Polearm", "Morningstar", "Wip", "Halberd", "Axe", "Pickaxe", "Lance", "Bludgeon", "Mace", "Rapier", "Ulfberht", "Esoc", "Dao", "Falchion", "Liuyedao", "Backsword", "Woldo", "Tachi", "Claymore", "Pitchfork", "Harpoon"};
        string[] damage_dat = { "7", "15", "10", "13", "5", "8", "3", "7", "8", "27", "5", "7", "15", "17", "12", "16", "1", "3", "2", "5", "9", "17", "5", "12", "10", "15", "5", "8", "7", "10", "7", "12", "2", "8", "10", "25", "7", "15", "4", "9", "12", "16", "7", "10", "8", "11", "1", "35", "7", "18", "5", "15", "7", "17", "5", "18", "8", "15", "9", "13", "11", "17", "12", "17", "11", "22", "5", "8", "7", "8", "999" };

    label_main_menu: // Actual start of the menu
        menuinput = "";

        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        Console.WriteLine("Hello Adventurer,");
        Console.WriteLine("Welcome to the dungeon of a hundred floors!");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Please enter one of the following commands:");
        Console.WriteLine("[L]oad game | [P]lay new game | [Q]uick game");
        Console.WriteLine("");
        menuinput = Console.ReadLine();
        if (menuinput == "l" || menuinput == "load")
        {
            // PLACEHOLDER FOR THE LOADING SYSTEM
            Console.WriteLine("Loading does not work (yet), start a new game instead.");
            Console.WriteLine("[Press ENTER to restart]");
            Console.ReadLine();
            goto label_main_menu;
        }
        else if (menuinput == "p" || menuinput == "play")
        {
            Console.Clear();
            Console.WriteLine("Hello Adventurer!");
            Console.WriteLine("");
            Console.WriteLine("You seem like a strong and capable hero, one deserving of a name...");
            Console.WriteLine("What is your name?");
            Console.WriteLine("");
            playername = Console.ReadLine();
            player_setup_one:
            Console.Clear();
            Console.WriteLine(playername + "? That is a very heroic sounding name!");
            Console.WriteLine("");
            Console.WriteLine("But a hero is more than just [his/her] name, what class are you?");
            Console.WriteLine("Type a number to select a class...");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Ranger");
            Console.WriteLine("3. Rouge");
            Console.WriteLine("4. Mage");
            Console.WriteLine("");
            classnum = Console.ReadLine();
            Int32.TryParse(classnum, out classnumint);
            if (classnumint >= 1 && classnumint <= 4)
            {
                classnumint--; // Quick n' dirty fix for the int starting at 1
                playerclass = quick_class[classnumint];
                weaponCount = classnumint;
                classdescstr = classdesc[classnumint];
                currentWeapon = weapon_list[weaponCount];

                Console.Clear();
                Console.WriteLine("Ah, a " + playerclass + ". " + classdescstr);
                Console.WriteLine("I best not keep you here for too long, I know you are eager to enter the dungeon.");
                Console.WriteLine("");
                Console.WriteLine("Most people dont ever come back, but im sure you already know that...");
                Console.WriteLine("[Press ENTER to start your adventure]");
                Console.ReadLine();
                goto label_dungeon_call;
            }
            else
            {
                goto player_setup_one;
            }
        }
        else if (menuinput == "q" || menuinput == "quick")
        {
            // Randomizes name and class
            classnumint--;
            int index = rand.Next(quick_names.Length);
            playername = quick_names[index];

            classnumint = rand.Next(quick_class.Length);
            playerclass = quick_class[classnumint];

            weaponCount = classnumint;
            currentWeapon = weapon_list[weaponCount];

            Console.Clear();
            Console.WriteLine("Quick Start Selected, character randomized.");
            Console.WriteLine("[Press ENTER to start your adventure]");
            Console.ReadLine();
            goto label_dungeon_call;

        }
        else
        {
            goto label_main_menu;
        }

    // This way I dont have to write it twice.
    // If for some reason setup is skipped, the game is made to handle it anyways.
    label_dungeon_call:

            // Adds class-specific starting perks
            classnumint++;
            if (classnumint == 4)
            {
                scrollCount = scrollCount + 3;
                potionCount = potionCount + 1;
            }

            if (classnumint == 10)
            { potionCount = potionCount + 7; }

        dungeon(playername, playerclass, weapon_list, damage_dat, currentWeapon, weaponCount, scrollCount, potionCount);
    }

    public static void dungeon(string playername, string playerclass, string[] weapon_list, string[] damage_dat, string currentWeapon, int weaponCount, int scrollCount, int potionCount)
    {
        // DATA
        string inputString;

        int health = 100; // Theres no actual limit to health, this is intentional.
        string[] healthstr = { "3" };
        int deathint;
        string randeath;
        string[] deathnote = { "bleeding out on the floor", "in the cold, dank floor", "splattered all over the walls of the dungeon, like an abstract painting", "your remains shall become a feast for the monsters in this floor", "you will never again see the light of day", "dont take it personal, kid", "better luck next time", "cut in half like a steak", "smashed to pieces by your foes", "your remains rot away, your belongings are added to the dungeon's treasury", "being stupid enough to enter the dungeon tends to do that", "the old man from the character creator knew you would die, but he sent you anyways", "you dont wanna know what gobilns do with fresh corpses", "this has become your final resting place", "more adventurers will follow your lead, all of them will meet the same end as you did", "your skill was not enough to beat this floor", "the darkness from the dungeon shrouds you, and will never let go..", "weeks from now, some may notice you are gone", "the local goblins will put your head on display, atop a spear" };
        string[] attackPatternStr = { "swing", "swing", "swing", "toss", "throw", "thrust", "impale" };
        string[] enemy_attackPatternStr = { "attacks", "fights back at", "launches itself at", "attacks", "mauls", "thrusts its weapon at", "attacks", "gives a beating to", "attacks" };
        int attackpatternint;
        string flavourtextattack;

        string[] scroll_boot_action = { "slowly take the scroll out of your backpack", "quickly take the scroll out of your backpack", "with musch haste take the scroll out of your backpack", "tightly grab your scroll", "get a scroll", "use a scroll", "take your scroll", "take the scroll out of your backpack without hasitation", "reach out to your pouch, taking a scroll from it", "tightly yet firmly grab your scroll", "take the scroll out of your backpack", "take the scroll out of your backpack in a panic" };
        string[] scroll_boot_time = { "quickly", "slowly", "rapidly", "very slowly" };
        string[] scroll_boot_emission = { "vibrate", "emit", "shine", "glow", "create", "radiate" };
        string[] scroll_general_colour = { "red", "green", "blue", "white", "black", "pink", "orange", "yellow", "purple", "dark" };
        string[] scroll_boot_feel = { "warm", "cold", "cilly", "menacing", "good", "evil", "malicious", "overpowering", "strong", "great", "wrong", "fantastic", "powerful", "active", "inactive", "aware", "lonley", "like paper, what did you expect", "magical", "plain", "special", "unequal", "equalizing", "anaholative", "godly", "heavenly", "destructive", "assertive", "powerless", "painful" };
        string[] scroll_action_actionType = { "ray", "gas", "arrow", "ray", "godray", "electrical ark", "ray", "flash", "flash of darkness", "ray", "flash of light", "forcefield", "ray", "ray", "ray", "black hole" };
        string[] scroll_action_attack = { "shrouds", "zaps", "absorbs", "envelops", "hits", "pierces", "poisons", "decays", "attacks", "pushes back", "blows away", "slices", "cuts" };

        // Loot Generation
        int loot_type = 0;
        string lootdrops = "Visual Studio Error, the rarest of items!";

        // V2 combat system - Enemy variables
        int damCalCount = 0; // Gee can you guess why this is zero? I wonder!
        string enemy_damageMinS;
        string enemy_damageMaxS;
        int enemy_damageMin;
        int enemy_damageMax;

        // Same but for the player
        string player_damageMinS;
        string player_damageMaxS;
        int player_damageMin;
        int player_damageMax;

        string frontEntity;
        frontEntity = "Visual Studio Crash Handler";
        int entityCount = 0; // Set to zero so it may compile
        bool isEnemyPresent = false;
        int floor = 0;
        int enemyHealth = 0; // Set to zero so it may compile
        string enemyHealthStrg;

        string[] entity_list = { "Goblin", "Group of Kobolts", "Troll", "Bandit", "Graverobber", "Zombie", "Ghoul", "Litch", "Deamon", "Rat", "Slime", "Skeleton", "Cultist", "Lizard Man", "Golem", "Elemental", "Orc", "Ogre", "Cyclops", "Gnome", "Guardian", "Harpy" };
        string[] entity_health = { "12", "32", "150", "75", "50", "75", "50", "25", "95", "5", "75", "25", "10", "50", "225", "25", "50", "150", "25", "15", "75", "25" };
        string[] entity_damage = { "3", "5", "1", "5", "10", "18", "5", "12", "1", "15", "5", "10", "7", "15", "10", "20", "11", "20", "1", "3", "1", "8", "7", "13", "5", "50", "8", "20", "5", "15", "15", "25", "10", "15", "7", "15", "5", "30", "1", "7", "5", "15", "7", "25", "999" }; // IGNORE THE LAST VALUE, Its made to keep an overflow at bay, because programing does not make sense

        // FIXES
        Random rand = new Random();

        // ACTUAL CODE
        dungeon_start:

        // Runtime Refresh Items
        // [NOTE] Randoms never reach the max value, remember to always add one extra number!
        int escapeDamage = rand.Next(1, 26);
        int ranheal = rand.Next(25, 51);
        int scrolldmg = rand.Next(1, 451);
        int lootroll = rand.Next(1, 8);

        // PROPER START
        Console.Clear();

        // DEAD STATE
        deathint = rand.Next(deathnote.Length);
        if (health <= 0)
        {
        death_label:
            Console.Clear();
            Console.WriteLine("Your name is " + playername + ", you are a " + playerclass + " in floor " + floor + ".");
            randeath = deathnote[deathint];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have died, " + randeath + ".");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Your death is not the first down here, and it certainly wont be the last...");
            Console.WriteLine("Press [N]ext to restart");
            inputString = Console.ReadLine();

            if (inputString == "n" || inputString == "next")
            { Main(null); }
            goto death_label;

        }

        // NORMAL STATE
        Console.WriteLine("Your name is " + playername + ", you are a " + playerclass + " with " + health + " health in floor " + floor + ".");
        Console.WriteLine("You have a " + currentWeapon + ", " + potionCount + " potions and " + scrollCount + " ancient scrolls.");
        Console.WriteLine("");
        if (isEnemyPresent == true)
        { Console.WriteLine("Before you stands a " + frontEntity + " it has " + enemyHealth + " health left."); }
        if (isEnemyPresent == false)
        { Console.WriteLine("There are no enemies left in the room, you may enter the next floor..."); }
        Console.WriteLine("Type [H]elp for a list of commands.");
        Console.WriteLine("");
        inputString = Console.ReadLine();
        if (inputString == "h" || inputString == "help")
        {
            Console.Clear();
            Console.WriteLine("COMMAND LIST:");
            Console.WriteLine("");
            Console.WriteLine("[h]elp           - Displays this menu");
            Console.WriteLine("[a]ttack         - Attack the current enemy with your weapon");
            Console.WriteLine("[p]ickup         - Picks up items from the ground");
            Console.WriteLine("[s]croll         - Uses ancient scroll");
            Console.WriteLine("[+]heal          - Uses health potion");
            Console.WriteLine("[n]ext           - Enters the next floor");
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue."); // add a random tip system?
            Console.ReadLine();
        }
        if (inputString == "n" && isEnemyPresent == false || inputString == "next" && isEnemyPresent == false)
        {
            floor++;
            if (floor == 100)
            {
                Console.Clear();
                Console.WriteLine("You arrive at floor 100...");
                Console.WriteLine("Before you stands a massive door.");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("You open the door, leading down a long corridor,");
                Console.WriteLine("Eventually, you make it to a large room, inside of that room there is nothing but a massive throne.");
                Console.WriteLine("");
                Console.WriteLine("On that throne sits a huge man, covered in steel plates and armour along every inch of his body,");
                Console.WriteLine("You are unable to discern if the being inside of the armour is alive.");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("As you step closer, the floor starts to tremble more and more violently...");
                Console.WriteLine("Eventually you fall over from the tremors, as soon as you touch the ground, the earth stops moving.");
                Console.WriteLine("");
                Console.WriteLine("You look up, there before you is the man from the throne, standing, looking down on you.");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Before you can say a word or raise your " + currentWeapon + ", the man starts to speak...");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What is it you desire, brave adventurer?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The man takes his broadsword and impales it into the ground, using it as a pole to rest upon.");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I am the god of endings,");
                Console.WriteLine("You have fought long and hard, I can grant you eternal peace, an ending to your story.");
                Console.WriteLine("");
                Console.WriteLine("So once more, brave adventurer...");
                Console.WriteLine("What is it you most desire?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                    label_end_decision:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("What is it you most desire?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("[1] Gold         - Riches unlike no other");
                Console.WriteLine("[2] Weapons      - The strongest weapon in the dungeon");
                Console.WriteLine("[3] Power        - The secret of immortality");
                Console.WriteLine("");
                Console.WriteLine("[Insert your answer to continue...]");
                inputString = Console.ReadLine();
                if (inputString == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Gold?");
                    Console.WriteLine("Why yes of course, the desire of all adventurers!");
                    Console.WriteLine("");
                    Console.WriteLine("I shall grant you your wish, piles upon piles of gold, mountains so large that you shault never see the end of them!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("Suddenly, you start hearing small metalic objects clash against the floor tiles,");
                    Console.WriteLine("A golden coin hits you in the head, you look up and realize that it is raining pure gold!");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.WriteLine("The flood of gold does not stop, piles form everywhere as far as you can see...");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You start to slowly drown as the piles of gold engulf you...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Your last breath is drawn in an attempt to not choke on the gold, it was a futile edevour.");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    health = 0;
                    goto dungeon_start;
                }
                else if (inputString == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A mighty weapon?");
                    Console.WriteLine("Well, it so happens I have it in my possesion!");
                    Console.WriteLine("");
                    Console.WriteLine("You may have it.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.WriteLine("The man lets go of his massive broadsword, its shadow,");
                    Console.WriteLine("Which is as massive as the tallest castles in the highlands, dawns upon you.");
                    Console.WriteLine("The shadow rapidly starts to become smaller and smaller as it tips towards you.");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The massive broadsword falls atop you, crushing every bone in your body.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You are now nothing but a puddle of blood covered in bone dust.");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("It appears that you could not handle such a mighty weapon after all... Brave adventurer.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    health = 0;
                    goto dungeon_start;
                }
                else if (inputString == "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Power?");
                    Console.WriteLine("So you wish to be unkilleable?");
                    Console.WriteLine("");
                    Console.WriteLine("I can do that.");
                    Console.WriteLine("Drink this... Brave adventurer.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.WriteLine("The man extends his hand out, giving you a strange potion unlike anything you have ever seen...");
                    Console.WriteLine("You drink the gray potion with eagerness, seeking to amend your own mortality.");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your skin starts to slowly petrify, you scream in horror!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You panic as every ounce of your being is petrified, slowly destroying nerves as it makes its way to your neck...");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.WriteLine("Nothing but a satue is left of you,");
                    Console.WriteLine("Your memory forever lives on in the form of a statue amongst many in the halls of the dungeon.");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    health = 0;
                    goto dungeon_start;
                }
                else if (inputString == "a" || inputString == "attack")
                {
                    Console.Clear();
                    Console.WriteLine("You see right through the intent of this false god and decide to strike.");
                    Console.WriteLine("Aggressively, you begin to drink every potion in your possesion.");
                    Console.WriteLine("");
                    Console.WriteLine("The man notices your intent too, but continues to stand idle, amused by your courage.");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.WriteLine("Knowing that your weapon would be of no use, you toss it aside, much to the amusement of the man.");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Adventurer, do you intend to fight me with your bare fists?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("You then take a torch out of your bag.");
                    Console.WriteLine("The man stares, awaiting your next move...");
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You take the torch and burn your bag!");
                    Console.ForegroundColor = ConsoleColor.White;

                    int bossDMGD = scrolldmg * scrollCount;

                    Console.WriteLine("");
                    Console.WriteLine("The man, shocked by your unexpected action, takes a defensive stance!");
                    Console.WriteLine("");
                    Console.WriteLine("Every spell within the bag burns, realeasing its powers all at once!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your " + scrollCount + " scrolls deal a combined damage of " + bossDMGD + "!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("Press [ENTER] to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    if (bossDMGD >= 5000)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The raw magical power bursts right through him, clearing a hole in the middle of his chest!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.WriteLine("The man stumbles back, in disbelief.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You little, insignificant man, you beast, you MONSTER pretending to be a " + playerclass + "!");
                        Console.WriteLine("Curse you! CURSE YOU!");
                        Console.WriteLine("");
                        Console.WriteLine("Press [ENTER] to continue.");
                        Console.ReadLine();
                        label_endlessmode_selection:
                        Console.Clear();
                        Console.WriteLine("The man falls over, the battle has been decided and you are its victor.");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have defeated the lord of the dungeon,");
                        Console.WriteLine("You may return to the surface and celebrate with the villagers or continue to the next floor...");
                        Console.WriteLine("");
                        Console.WriteLine("Press [ENTER] for credits.");
                        Console.WriteLine("Press [N]ext to continue.");
                        inputString = Console.ReadLine();
                        if (inputString == "")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You exit the dungeon and the villagers greet you to celebrate!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            Console.WriteLine("Hundred Floor Dungeon by Hugo Cortell");
                            Console.WriteLine("VFS Student 2020");
                            Console.WriteLine("");
                            Console.WriteLine("Press [ENTER] to exit.");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else if (inputString == "n" || inputString == "next")
                        {
                            scrollCount = 0;
                            floor = 101;
                            goto dungeon_start;
                        }
                        goto label_endlessmode_selection;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You attempted to harm me, you failed.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.WriteLine("Press [ENTER] to continue.");
                        Console.ReadLine();
                        Console.WriteLine("The man swings his massive broad sword, cutting you in half.");
                        Console.WriteLine("");
                        Console.WriteLine("Press [ENTER] to continue.");
                        Console.ReadLine();
                        health = 0;
                        goto dungeon_start;
                    }
                }

                goto label_end_decision;
            }

            // Selects the next enemy
            entityCount = rand.Next(entity_list.Length);
            frontEntity = entity_list[entityCount];

            // Sets its starting health based on stats sheet
            enemyHealthStrg = entity_health[entityCount];
            Int32.TryParse(enemyHealthStrg, out enemyHealth);

            // Generates the damage calculation int
            damCalCount = entityCount;
            damCalCount = damCalCount * 2;

            // Resets the dungeon by spawning an enemy
            isEnemyPresent = true;
        }
        else if (inputString == "n" && isEnemyPresent == true || inputString == "next" && isEnemyPresent == true)
        {
            Console.WriteLine("Your opponent blocks the exit!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You took " + escapeDamage + " damage while attempting to get past him.");
            Console.ForegroundColor = ConsoleColor.White;
            health = health - escapeDamage;
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
        }
        if (inputString == "+" && potionCount > 0 || inputString == "heal" && potionCount > 0)
        {
            potionCount--;
            Console.WriteLine("You take a healing potion from your backpack,");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("its healing powers grant you +" + ranheal + " health.");
            Console.ForegroundColor = ConsoleColor.White;
            health = health + ranheal;
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();

        }
        else if (inputString == "+" && potionCount == 0 || inputString == "heal" && potionCount == 0)
        {
            Console.WriteLine("You have no potions left in your backpack!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your opponent senses this and decides to strike, dealing "+ escapeDamage + " damage.");
            Console.ForegroundColor = ConsoleColor.White;
            health = health - escapeDamage;
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();

        }
        if (inputString == "a" && isEnemyPresent == true || inputString == "attack" && isEnemyPresent == true)
        {
            // Flavour Text Generator, 'cause this is flavourtown babyyyyy
            attackpatternint = rand.Next(attackPatternStr.Length);
            flavourtextattack = attackPatternStr[attackpatternint];

            // Indexes the weapon, then generates damage positioner
            var indexedWeaponInt = Array.FindIndex(weapon_list, x => x == currentWeapon); // Finds string within an array, then assigns a generic value [C: BLUEPIXY]
            indexedWeaponInt = indexedWeaponInt++; // Conversts value to custom numerical system
            weaponCount = indexedWeaponInt * 2; // Transforms value to a weapon count value, for the damage system

            // Checks damage dealt - Using the new V2 combat system
            player_damageMinS = damage_dat[weaponCount];
            Int32.TryParse(player_damageMinS, out player_damageMin);
            weaponCount++; // Checks the next variable (the max damage, defined by the array)
            player_damageMaxS = damage_dat[weaponCount];
            Int32.TryParse(player_damageMaxS, out player_damageMax);
            weaponCount--; // Resets array to previous position (Preventing an overflow)
            player_damageMax++; // Fixes the array number (REMOVE IF THE ARRAY JUST MAGICALLY FIXES ITSELF)
            int damagedealt = rand.Next(player_damageMin, player_damageMax); // Calculates [output] damage

            Console.Clear();
            Console.WriteLine("You " + flavourtextattack + " your " + currentWeapon + " at the " + frontEntity + "!");
            Console.WriteLine("The " + frontEntity + " takes " + damagedealt + " damage!");
            enemyHealth = enemyHealth - damagedealt;
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
            if (enemyHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("The " + frontEntity + " has been slain!");
                isEnemyPresent = false;
                Console.WriteLine("");
                if (lootroll >= 3) // looting system
                {
                    if ( lootroll == 3 || lootroll == 4)
                    {
                        lootdrops = "healing potion";
                        loot_type = 1;
                    }
                    else if (lootroll == 5)
                    {
                        lootdrops = "Magical Scroll";
                        loot_type = 2;
                    }
                    else if (lootroll == 6 || lootroll == 7)
                    {
                        lootroll = rand.Next(weapon_list.Length);

                        // Item blacklist, add [&&]'s to the while statement to blacklist specific weapons from the array
                        while (lootroll == 8) // Remember to remove -1 from the value of the weapon, arrays start at zero!
                        {
                            lootroll = rand.Next(weapon_list.Length);
                        }

                        lootdrops = weapon_list[lootroll];

                        loot_type = 3;
                    }
                    Console.WriteLine("On the floor lies a... " + lootdrops + ".");
                }

                else
                { Console.WriteLine("Your foe had no loot for you to take."); }
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                inputString = Console.ReadLine();

                if (inputString == "p" || inputString == "pickup")
                {
                    if (loot_type == 1)
                    {

                        potionCount++;
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You picked the potion up.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press [ENTER] to continue.");
                    }

                    else if (loot_type == 2)
                    {
                        scrollCount++;
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You picked the scroll up.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press [ENTER] to continue.");
                    }

                    else if (loot_type == 3)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You exchanged your " + currentWeapon + " for the " + lootdrops + " on the floor.");
                        Console.ForegroundColor = ConsoleColor.White;

                        weaponCount = lootroll; // Replaces the weapon in actuallity (the int that dictates damage)
                        currentWeapon = weapon_list[weaponCount]; // Same but for the string


                        Console.WriteLine("Press [ENTER] to continue.");
                    }
                }
                inputString = "voidvalue"; // Da quickest of fixes
                goto label_combat_continue;
            }

            // Smart reusage of strings and ints
            attackpatternint = rand.Next(enemy_attackPatternStr.Length);
            flavourtextattack = enemy_attackPatternStr[attackpatternint];

            // Checks damage dealt by opponent
            enemy_damageMinS = entity_damage[damCalCount];
            Int32.TryParse(enemy_damageMinS, out enemy_damageMin);
            damCalCount++; // Checks the next variable (the max damage, defined by the array)
            enemy_damageMaxS = entity_damage[damCalCount];
            Int32.TryParse(enemy_damageMaxS, out enemy_damageMax);
            damCalCount--; // Resets array to previous position (Preventing an overflow)
            enemy_damageMax++;
            int enemyDamageDealt = rand.Next(enemy_damageMin, enemy_damageMax); // Calculates damage

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The " + frontEntity + " " + flavourtextattack + " you, dealing " + enemyDamageDealt + " damage.");
            Console.ForegroundColor = ConsoleColor.White;
            health = health - enemyDamageDealt;

            // continuation section
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            label_combat_continue:
            Console.ReadLine();
        }
        if (inputString == "s" && scrollCount > 0 && isEnemyPresent == true || inputString == "scroll" && scrollCount > 0 && isEnemyPresent == true)
        {
            // ADVANCED Flavour Text Generator, BABYYYYYYYYYYYYY
            // Seriously, this got out of hand quick, im having too much fun.
            string scrollString1 = "take a scroll out";
            string scrollString2 = "slowly";
            string scrollString3 = "emit";
            string scrollString4 = "magical";
            string scrollString5 = "otherworldly";
            string scrollString6 = "ray";
            string scrollString7 = "goes trough";
            int scrollFlavourINT1 = 1;
            int scrollFlavourINT2 = 1;
            int scrollFlavourINT3 = 1;
            int scrollFlavourINT4 = 1;
            int scrollFlavourINT5 = 1;
            int scrollFlavourINT6 = 1;
            int scrollFlavourINT7 = 1;

            scrollFlavourINT1 = rand.Next(scroll_boot_action.Length); // oh lawrd
            scrollString1 = scroll_boot_action[scrollFlavourINT1];
            scrollFlavourINT2 = rand.Next(scroll_boot_time.Length);
            scrollString2 = scroll_boot_time[scrollFlavourINT2];
            scrollFlavourINT3 = rand.Next(scroll_boot_emission.Length);
            scrollString3 = scroll_boot_emission[scrollFlavourINT3];
            scrollFlavourINT4 = rand.Next(scroll_general_colour.Length);
            scrollString4 = scroll_general_colour[scrollFlavourINT4];
            scrollFlavourINT5 = rand.Next(scroll_boot_feel.Length);
            scrollString5 = scroll_boot_feel[scrollFlavourINT5];
            scrollFlavourINT6 = rand.Next(scroll_action_actionType.Length);
            scrollString6 = scroll_action_actionType[scrollFlavourINT6];
            scrollFlavourINT7 = rand.Next(scroll_action_attack.Length);
            scrollString7 = scroll_action_attack[scrollFlavourINT7];

            attackpatternint = rand.Next(attackPatternStr.Length);
            flavourtextattack = attackPatternStr[attackpatternint];

            Console.Clear();
            Console.WriteLine("You " + scrollString1 + ", it " + scrollString2 + " starts to " + scrollString3 + " a " + scrollString4 + " light... It feels " + scrollString5 + ".");
            Console.WriteLine("Suddenly, the scroll emits a " + scrollString4 + " " + scrollString6 + " which " + scrollString7 + " your opponent!");
            Console.WriteLine("Your attack has dealt " + scrolldmg + " damage!");
            enemyHealth = enemyHealth - scrolldmg;
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
            if (enemyHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("The " + frontEntity + " has been slain!");
                Console.WriteLine("Your scroll was so powerful that it destroyed the loot alongside your foe...");
                isEnemyPresent = false;
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                goto label_magical_combat_continue;
            }

            // Smart reusage of strings and ints
            attackpatternint = rand.Next(enemy_attackPatternStr.Length);
            flavourtextattack = enemy_attackPatternStr[attackpatternint];

            // Checks damage dealt by opponent
            enemy_damageMinS = entity_damage[damCalCount];
            Int32.TryParse(enemy_damageMinS, out enemy_damageMin);
            damCalCount++; // Checks the next variable (the max damage, defined by the array)
            enemy_damageMaxS = entity_damage[damCalCount];
            Int32.TryParse(enemy_damageMaxS, out enemy_damageMax);
            damCalCount--; // Resets array to previous position (Preventing an overflow)
            enemy_damageMax++;
            int enemyDamageDealt = rand.Next(enemy_damageMin, enemy_damageMax); // Calculates damage
            enemyDamageDealt = enemyDamageDealt + escapeDamage * 2;

            Console.WriteLine("");
            Console.WriteLine("After a failed magical attack, your opponent senses weakness and decides to strike!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The " + frontEntity + " " + flavourtextattack + " you, dealing " + enemyDamageDealt + " critical damage.");
            Console.ForegroundColor = ConsoleColor.White;
            health = health - enemyDamageDealt;

            // continuation section
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            label_magical_combat_continue:
            scrollCount--;
            Console.ReadLine();
        }
        else if (inputString == "s" && scrollCount == 0 && isEnemyPresent == true || inputString == "scroll" && scrollCount == 0 && isEnemyPresent == true)
        {
            Console.WriteLine("You have no scrolls left!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your opponent senses this and decides to strike, dealing " + escapeDamage + " damage.");
            Console.ForegroundColor = ConsoleColor.White;
            health = health - escapeDamage;
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
        }
        if (inputString == "p" && currentWeapon != "Fists" || inputString == "pickup" && currentWeapon != "Fists") // Not as elegant as using an int, might be updated later 
        {
            label_pickup_action:
            Console.Clear();
            Console.WriteLine("Are you sure you wish to drop your " + currentWeapon + "?");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press [P]ickup to continue.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press [ENTER] to cancel.");
            Console.ForegroundColor = ConsoleColor.White;
            inputString = Console.ReadLine();
            if (inputString == "p")
            {
                Console.WriteLine("");
                Console.WriteLine("You throw away your weapon, you are now unnarmed.");
                currentWeapon = weapon_list[8]; // Replaces current weapon with selected item
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                goto dungeon_start;
            }
            else if (inputString == "")
            {
                Console.WriteLine("");
                Console.WriteLine("You are probably going to need your weapon anyways...");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
                Console.ReadLine();
                goto dungeon_start;
            }
            goto label_pickup_action;
        }
        else if (inputString == "p" && currentWeapon == "Fists" || inputString == "pickup" && currentWeapon == "Fists")
        {
            Console.WriteLine("There is nothing you can pick up or drop here.");
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
        }
        goto dungeon_start;
    }
}
