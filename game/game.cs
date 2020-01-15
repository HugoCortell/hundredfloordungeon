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
        string[] weapon_list = { "Sword", "Bow", "Dagger", "Staff", "Katana", "Hammer", "Spear", "Cutlass", "Fists", "Broken Glass Bottle"};
        // NOTE!!!!!!!!!!!!!!!!!!!! TODO: DAMAGE RANDOMIZATION FOR PLAYERS (Copy method used for enemies)
        string[] damage_dat = { "15", "13", "7", "5", "20", "7", "17", "16", "1", "3"};

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
            { potionCount = potionCount + 6; }

            else if (classnumint != 4 && classnumint != 10)
            {
                scrollCount--; // Fix for scroll count being 1 instead of zero
                potionCount++; // I dont even know why I have to do this, for some reason it thinks its zero...
            }

        dungeon(playername, playerclass, weapon_list, damage_dat, currentWeapon, weaponCount, scrollCount, potionCount);
    }

    public static void dungeon(string playername, string playerclass, string[] weapon_list, string[] damage_dat, string currentWeapon, int weaponCount, int scrollCount, int potionCount)
    {
        // DATA
        string inputString;

        int health = 100; // Theres no actual limit to health, this is intentional.
        int damagedealt;
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
        string[] scroll_boot_emission = { "vibrate", "emmit", "shine", "glow", "create", "radiate" };
        string[] scroll_general_colour = { "red", "green", "blue", "white", "black", "pink", "orange", "yellow", "purple", "dark" };
        string[] scroll_boot_feel = { "warm", "cold", "cilly", "menacing", "good", "evil", "malicious", "overpowering", "strong", "great", "wrong", "fantastic", "powerful", "active", "inactive", "aware", "lonley", "like paper, what did you expect", "magical", "plain", "special", "unequal", "equalizing", "anaholative", "godly", "heavenly", "destructive", "assertive", "powerless", "painful" };
        string[] scroll_action_actionType = { "ray", "gas", "arrow", "ray", "godray", "electrical ark", "ray", "flash", "flash of darkness", "ray", "flash of light", "forcefield", "ray", "ray", "ray", "black hole" };
        string[] scroll_action_attack = { "shrouds", "zaps", "absorbs", "envelops", "hits", "pierces", "poisons", "decays", "attacks", "pushes back", "blows away", "slices", "cuts" };


        int damCalCount = 0; // Gee can you guess why this is zero? I wonder!
        string damagedealtstr;
        string enemy_damageMinS;
        string enemy_damageMaxS;
        int enemy_damageMin;
        int enemy_damageMax;

        string frontEntity;
        frontEntity = "Visual Studio Crash Handler";
        int entityCount = 0; // Set to zero so it may compile
        bool isEnemyPresent = false;
        //bool newRoom = false; // NOTE: DISABLED FOR NOW JUST TO CLEAR THE CONSOLE ERROR
        int floor = 0;
        int enemyHealth = 0; // Set to zero so it may compile
        string enemyHealthStrg;

        string[] entity_list = { "Goblin", "Group of Kobolts" };
        string[] entity_health = { "12", "32" };
        string[] entity_damage = { "3", "5", "1", "5", "999" }; // IGNORE THE LAST VALUE, Its made to keep an overflow at bay, because programing does not make sense

        // FIXES
        Random rand = new Random();

        // ACTUAL CODE
        dungeon_start:

        // Runtime Refresh Items
        int escapeDamage = rand.Next(1, 25);
        int ranheal = rand.Next(25, 50);
        int scrolldmg = rand.Next(1, 450);
        int lootroll = rand.Next(1, 7);

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
            Console.WriteLine("pickup       - Picks up weapon from the ground");
            Console.WriteLine("[s]croll         - Uses ancient scroll");
            Console.WriteLine("[+]heal          - Uses health potion");
            Console.WriteLine("[n]ext           - Enters the next floor");
            Console.WriteLine("");
            Console.WriteLine("Press [ENTER] to continue.");
            Console.ReadLine();
        }
        if (inputString == "n" && isEnemyPresent == false || inputString == "next" && isEnemyPresent == false)
        {
            floor++;
            if (floor == 100)
            {
                // Here goes the 100th floor
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

            damagedealtstr = damage_dat[weaponCount];
            Int32.TryParse(damagedealtstr, out damagedealt); // converts the string output into a int output for usage in calculations

            Console.Clear();
            Console.WriteLine("You " + flavourtextattack + " your " + currentWeapon + " at the " + frontEntity + "!");
            Console.WriteLine("The " + frontEntity + " takes " + damagedealtstr + " damage!");
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
                Console.WriteLine("HERE GOES LOOT BULLSHIT");
                Console.WriteLine("SOMETHING SOMEGTHDGAGFS");
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to continue.");
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
            string scrollString3 = "emmit";
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
            Console.WriteLine("You " + scrollString1 + ", it " + scrollString2 + " starts to " + scrollString3 + " a " + scrollString4 + " lgiht... It feels " + scrollString5 + ".");
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
        goto dungeon_start;
    }

    public void weaponPickup()
    {

    }
}
