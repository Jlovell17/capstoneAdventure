using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    // **************************************************
    //
    // Title: Capstone Project- Dungeon Rescue
    // Description: Final project, text based adventure
    // Application Type: Console
    // Author: Lovell, James
    // Dated Created: 4/07/2021
    // Last Modified: 4/11/2021
    //
    // **************************************************


    // make lists of locations and character properties to keep track of.
    // comma deliniated file io tracking character class and stats
    // create intro method asking if new or contuing game.
    // if character dies in room give password for current room
    // 

    //
    //
    //basic story premis credit goes to matthew covile on youtube
    //
    //
    public enum Storystates
    {
        NONE,
        TAVERN,
        CHASE,
        CAVE,
        FIRST,
        OFFERING,
        TRAP,
        TOMB,
        HIDDENCHAMBER,
        DONE,
    }

    class Program
    {
        static List<Character> characters;

        static void Main(string[] args)
        {


            SetTheme();
            // create a method for setting up all the characters and thier stats and run that here to initialize.
            characters =  CharacterInitializer();
            DisplayWelcomeScreen();


        }

        //******************************

        #region story

        static void storyStart()
        {
            Console.Clear();

            //introduce the party, 
            Console.WriteLine();
            Console.WriteLine("\tflash back.");
            Console.WriteLine();
            Console.WriteLine("\tDusk falls and four travelers come to the Green Dragon Inn for food, warmth, and a place to rest.");
            Console.WriteLine();
            Console.WriteLine("\tSeveral villagers are here, eating, drinking, talking about thier day. One day is much the same as another in the hamlet of Vilane, "); 
            Console.WriteLine();
            Console.WriteLine("\tbut looking at you something tells them today will be different...");
            Console.WriteLine();
            Console.WriteLine("\t''Welcome to the Green Dragon Tavern!''");
            Console.WriteLine();
            Console.WriteLine("\tA jovial man cleaning a mug waves at you from behind the well used counter of the " +
                "aforenamed inn and tavern franchise. ");
            Console.WriteLine();
            Console.WriteLine("\tYou are Merri the wandering halfling, and your companions, Alyx the dark Rogue, Luxor the beefy Fighter, and Diedra, a spindly Wizard");
            Console.WriteLine();
            Console.WriteLine("\tamble up to the bar."); 
            Console.WriteLine();
            Console.WriteLine( "\tThe group laughs and gripes good naturedly about the days travels and orders drinks and fare from the tavern's bearded proprieter.");
            DisplayContinuePrompt();
            Console.Clear();

            TavernInterruptionStoryStart();
      
        }

        static void TavernInterruptionStoryStart()
        {
            // paint the picture:  
            // A sizzling rack of lamb is set before you and a cheer is given by Luxor and Merri
            //as soon as the player establishes thier name and class if that sticks around.
            // move the camera:
            // lead the player: 
            Console.WriteLine();
            DisplayScreenHeader("\tThe call to action!");
            Console.WriteLine();
            Console.WriteLine("\tThe first drink is the most refreshing. You and the companions raise your glasses, sloshing some of the heady wine on the table.");
            Console.WriteLine();
            Console.WriteLine("\tA sizzling rack of lamb is set before you and a cheer is given by Luxor and Merri!");
            Console.WriteLine("");
            Console.WriteLine("\tSettling into the meal, your group is interrupted by a commotion from the from of the front of the tavern.");
            Console.WriteLine();
            Console.WriteLine("\t''My daughter! THEY'VE TAKEN BESS!!'' A large man in a white linen shirt and a lonmg leather apron was sobbing to the entire taproom.");
            Console.WriteLine();
            Console.WriteLine("\t''What do you mean George?'' asked the tavern keeper.");
            Console.WriteLine();
            Console.WriteLine("\tThe Blacksmith turned to face the innkeep: ''Bill!'' He said between sobs");
            Console.WriteLine();
            Console.WriteLine("\t''Those goblins are at it again, but this time its not our livestock! its my daughter!''");
            Console.WriteLine();
            Console.WriteLine("\tThis caused a look of concern to cross Bill's face and murmuring from several townspeople seated across the bar");
            Console.WriteLine();
            Console.WriteLine("\t''How can you tell it was them? Could she have just left?'' asked a man down the bar.");
            Console.WriteLine();
            Console.WriteLine("\t''Thier tracks were everywhere, those three toed feet! And the whole house was torn apart!''");
            Console.WriteLine();
            Console.WriteLine("\tGeorge stuffed his face in his hands and muffled out '' I was only gone to get more barstock for the forge... only gone an hour...''");
            Console.WriteLine();
            Console.WriteLine("\tBy this point several people had gathered together around George and were trying to comfort him.");
            Console.WriteLine();
            Console.WriteLine("\t''Where did they take her?''a young man asked standing up");
            Console.WriteLine();
            Console.WriteLine("\t''To the north!''said George");
            Console.WriteLine();
            Console.WriteLine("\t''I'm going then!'' the young man proclaimed hot-headedly.");
            TextDumpMethod("''Hold on now boy!'' said the tavern owner, ''I know you're sweet on her but dont be stupid!''");
            DisplayContinuePrompt();
            Console.Clear();
            ChaseSceenChoices();
        }

        static void ChaseSceenChoices()
        {
            Character player = characters.FirstOrDefault(c => c.Name == "Merri");

            string userResponse;
            // paint the picture:
            // move the camera:
            // lead the player: use the rouge to id the tracks and trace the goblins, auto success, ask player if they choose to wait and prepare first, or If they take off at once.
            // penalize if they take off at once, Maybe make method for a chase sceen and recover the girl? two endings?
            // 


            //
            // give option of rolling for tracking 
            Console.WriteLine();
            DisplayScreenHeader("Decision Time");
            TextDumpMethod("...At this point it's clear that something must be done... What do you do?");
            DisplayContinuePrompt(); 
            userResponse = ValidateStringInput("'Let him go' mind your business and let the boy attempt the rescue, 'offer to help' and rescue the girl or 'stop the boy' and stay out of trouble'?"
                ,"'let him go','offer to help','stop the boy'",
                new string[] { "stop the boy", "let him go", "offer to help" });

            if (userResponse == "let him go")
            {
                GameOverMessage("Bad End:", "\tThe party kept thier heads down as the boy ran off to the north side of town." +
                    "\n\n\tHe was never seen again." +
                    "\n\n\tThe party finished thier meal, quietly paid for a room for the night, and somberly left the next morning to adventures yet unknown "); 
            }
            if (userResponse == "offer to help")
            {
                string userResponse2;
                TextDumpMethod("Deidra the level headed Wizard calmly interrupted the group in the tavern.");
                TextDumpMethod("''Gentlemen, Ladies, before this boy  runs off and gets himself goblinated, may we offer our services?''");
                TextDumpMethod("''Ah! A group of adventureres!''  the bartender exclaimed.''just who we need to help!''");
                TextDumpMethod("Diedra gave a slight bow and introduced the party. ");
                TextDumpMethod("''we have heard your troubles, can we offer our services?''asked Luxor.");
                TextDumpMethod("''The boy would be in over his head'' said Bill. ''Since George is a blubering mess now, maybe I can be of service?''");
                TextDumpMethod("Luxor and Deidra both nodded in agreement.");
                TextDumpMethod("''Help our town deal with its goblin problems and we will pay you a silver for every pair of ears you bring back''");
                TextDumpMethod("After a brief discussion a deal was struck and the party set out the rescue Bess and to put a stop to the goblin raids");

                DisplayContinuePrompt();
                userResponse2 = ValidateStringInput("Outside the Green Dragon a question pops up," +
                    "\n\n\tAre we ready to run off after them already? or do we need to get ready? 'after them' | ' get ready'",
                    "'after them '|  'get ready' please",
                    new string[] { "after them",  "get ready" } );
                if (userResponse2=="after them")
                {
                    
                    Console.Clear();
                    DisplayScreenHeader("After Them!");
                    TextDumpMethod("Galvanized by the sceen in the pub, and well prepared from practiced travels the group springs into action.");
                    TextDumpMethod("Running to the blacksmiths shop the group spots the unmistakable proof of a break in.");
                    TextDumpMethod("Roll perception!");
                    //
                    //
                    //CALL UP CHARACTER STATS FOR FACTORING INTO ROLL
                    //
                    //
                    int perceptionRoll;
                    perceptionRoll = Character.DiceRoll(20);

                    if (perceptionRoll + player.Wisdom >= 8)
                    {
                        TextDumpMethod($"you rolled a {perceptionRoll}");
                        TextDumpMethod("Merri excited pointed at the tracks the blacksmith mentioned. " +
                            "\n\n\tLeading out of town to the north are several sets of three toed footprints and a pair of dragmarks ");
                    }
                    else
                    {
                        TextDumpMethod($"you rolled a {perceptionRoll}");
                        TextDumpMethod("''Merri! Stop daydreaming and follow us!'' snapped the wizard as the rest of the group followed the obvious trail out of town.");
                    }
                    
                    DisplayContinuePrompt();
                    CaveApproach();

                }
                if (userResponse2=="get ready")
                {
                    GameOverMessage("Bad End","While making extra preperations for all the eventualities in countering the goblins" +
                        "\n\n\t A rain storm started up and the trail leading out of town was slowly and steadily obliterated." +
                        "\n\n\t The trail was lost and the goblins got away...");

                }

              
            }
            if (userResponse == "stop the boy")
            {
                GameOverMessage("Bad end","Luxor stands up and strides over to the rash youth, knocking him out casually and handing him back to a stunned Bill" +
                    "\n\n\t ''It's not worth watching this one run off and get himself dead, tell him to watch his head next time. ''" +
                    "\n\n\t The goblins completed thier ritual outside of town and the raids only got worse, and Bess was never seen again"); 

            }            
        }

        static void CaveApproach()
        {
            // paint the picture: 
            // move the camera:
            // lead the player: 
            Character player = characters.FirstOrDefault(c => c.Name == "Luxor");
            string userResponse;
            Console.Clear();
            DisplayScreenHeader("The Tomb");
            TextDumpMethod("After trudging through the forest for hours the four adventurers come across an old structure built into a hill. ");
            TextDumpMethod("There are a pair of goblin guards outside the door... What do you do?");
            DisplayContinuePrompt();
            userResponse = ValidateStringInput("what does the party do? Sneak in? or Attack?",
                " 'Sneak in' or 'Attack' please " ,
                new string[] { "sneak in", "attack", "LEEROY JENKINS" });

            if (userResponse == "sneak in")
            {
                Console.WriteLine("alright, roll dexterity to sneak in!");
                DisplayContinuePrompt();
                //
                //
                //COME BACK WITH JOHN AND FACTOR IN CHARACTER DEX
                //
                //
                int dexterityCheckRoll;
                dexterityCheckRoll = Character.DiceRoll(20);
                if (dexterityCheckRoll + player.Dexterity >= 12)
                {
                    Console.WriteLine($"you rolled a {dexterityCheckRoll} plus your dex modifier{player.Dexterity}, {dexterityCheckRoll + player.Dexterity}!");
                    TextDumpMethod("Deidra casts a minor illusion to fool the goblin guards and while they are distracted the party sneaks in.");
                    DisplayContinuePrompt();
                    OfferingRoom();
                }
                else
                {
                    
                    GameOverMessage("Bad End","The goblin gaurds detect your attempt to sneak up on them and alert the others!" +
                        "\n\n\tA swarm of gaurds spill out of the ruins and overwhelms the party!");
                    DisplayContinuePrompt();
                }
                DisplayContinuePrompt();
            }

            //this is a secret, inside joke
            if (userResponse== "attack" || userResponse=="LEEROY JENKINS")
            {

                int attackRoll;
                attackRoll = Character.DiceRoll(20);
                if (attackRoll + player.Strength >= 12)
                {
                    Console.WriteLine($"you rolled a {attackRoll}!");
                    TextDumpMethod("Luxor sprints forward and takes down one of the surprised goblins with his mace!" +
                        "\n\n\tDeidra unleashes a glowing spell into the other goblin who turns to ash!");
                    DisplayContinuePrompt();
                    OfferingRoom();
                }
                else
                {
                    Console.WriteLine($"you rolled a {attackRoll}!");
                    GameOverMessage("Bad End", "The goblin gaurds detect your attempt to attack them and alert the others!" +
                        "\n\n\tA swarm of gaurds spill out of the ruins and overwhelms the party!");
                }
                DisplayContinuePrompt();
            }                       
        }


        static void OfferingRoom()
        {
            Character player = characters.FirstOrDefault(c => c.Name == "Luxor");
            // paint the picture: girl hiding in corner
            // move the camera: as the players edge around the corner..
            // lead the player: attack or ...
            string userResponse;
            Console.Clear();
            DisplayScreenHeader(" The Offering Room ");
            TextDumpMethod("Peering around the corner into the offering room, its clear this was once a crypt, but no more!");
            TextDumpMethod("3 armed goblins are arrayed in a large stone room with a brazier in the middle.");
            TextDumpMethod("A goblin cleric is making menacing gestures at a woman who could only be Bess, using a talisman staff and chanting an eldritch dirge");
            TextDumpMethod("The foul ritual is underway! There isnt much time, what do you do?");
            DisplayContinuePrompt();

            Console.WriteLine("talk or fight?");
            DisplayContinuePrompt();
            userResponse = ValidateStringInput("Talk or Fight?","Talk or fight?", new string[] { "talk", "fight" });

            if (userResponse == "talk")
            {
                
                Console.Clear();
                int persuationRoll;
                persuationRoll = Character.DiceRoll(20);
                if (persuationRoll + player.Charisma >= 12)
                {
                    Console.WriteLine($"you rolled a {persuationRoll + player.Charisma}!");
                    TextDumpMethod("''Give us the girl and leave this place!''Luxor shouts to the room!");
                    TextDumpMethod("The goblins, caught off gaurd by this interruption, jump.");
                    TextDumpMethod("The goblin cleric having been interrupted in his casting, begins to scream as his spell turns against him!");
                    TextDumpMethod("Alyx the thief nimbly darts into the fray and grabs Bess before turning and fleeing into the doorway you all came through!");
                    TextDumpMethod("Deidra casts a shield across the door and there is a flash of green light!");
                    TextDumpMethod("When the light clears the goblins, and most of the room, are no more.");
                    DisplayContinuePrompt();
                    Resolution();
                }
                else
                {
                    Console.WriteLine($"you rolled a {persuationRoll + player.Charisma}!");
                    GameOverMessage("Bad End", "The goblin gaurds laugh at your attempts to postpone thier ritual and with a flash of light from the cleric's staff The world fades to black.");
                }
                DisplayContinuePrompt();

            }

            if (userResponse == "fight")
            {

                Console.WriteLine("The fight is on!");

                int attackRoll;
                attackRoll = Character.DiceRoll(20);
                if (attackRoll + player.Strength >= 12)
                {
                    Console.WriteLine($"you rolled a {attackRoll + player.Strength}!");
                    TextDumpMethod("Luxor charges into the room with a yell and cuts down two goblins in a flurry of blows.");
                    TextDumpMethod("Deidra casts a shield around Bess!");
                    TextDumpMethod("Merry casts a stone at the Goblin cleric unbalancing him!");
                    TextDumpMethod("Alyx the thief sneaks up behind him and proves his undoing!");
                    TextDumpMethod("As all the goblins fall to the floor vitory is yours!");
                    DisplayContinuePrompt();
                    Resolution();
                }
                else
                {
                    Console.WriteLine($"you rolled a {attackRoll + player.Strength}!");
                    GameOverMessage("Bad End", "Luxor trips on the way into the crypt!" +
                        "\n\n\talyx is spotted sneaking in and gets blocked by a goblin!" +
                        "\n\n\tDeidra fails concentration and his spell poofs in has face." +
                        "Bess lets out a scream and the goblins spell goes off! ... fade to black...");
                }
                DisplayContinuePrompt();
            }


        }

        static void Resolution()
        {
            TextDumpMethod("Having outsmarted and defeated the Goblins, Bess is rescued and returned to the town.");
            TextDumpMethod("The blacksmith is greatful and gifts each party member high level loot.");
            TextDumpMethod("The goblins lair is cleared of the goblins and thier accumulate3d treasure, and the anchient tomb is resealed to let the dead slumber.");
            TextDumpMethod("The party rides off onto the next adventure, but thats a story for another time...");
            DisplayContinuePrompt();
        }
        #endregion

        //******************************

        #region CharacterManagment

        static List<Character> CharacterInitializer()
        {
            List<Character> characters = new List<Character>();
            // ask john or jp wth i'm doing here, set each character to the same base stats, then fine tune on my own time.
            Character Luxor = new Character("Luxor", 45, 4, 2, -1, 3, 3, 1);
            characters.Add(Luxor);
            Character Gloim = new Character("Gloim", 50, 4, 1, 2, 3, 2, 1);
            characters.Add(Gloim);
            Character Diedra = new Character( "Diedra", 30, -1, 2, 3, -1, 2, 4);
            characters.Add(Diedra);
            Character Merri = new Character("Merri",40,2,3,1,-1,3,1);
            characters.Add(Merri);
                return characters;
        }
        //
        #endregion

        //******************************

        #region AdminMethods

        static void DisplayWelcomeScreen()
        {

            string userResponse;
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tRescue from the Goblin Crypt!");
            Console.WriteLine();
            Console.WriteLine("\tWelcome to our short adventure, can you save the town of Vilane" +
                " from its Nightly terrors? Will you stop the monsters and save the girl?" );
            Console.WriteLine();
            Console.WriteLine( "\tJoin our adventurers and find out!");
            Console.WriteLine();
            Console.WriteLine("\t\tInstructions:");
            Console.WriteLine();
            Console.WriteLine("\tYou the user will take control of our party, and I, the narrator will be the game's official ");
            Console.WriteLine();
            Console.WriteLine("\tIt's impossible to give the true DnD experience with text boxes without an AI or a live human on the other end");
            Console.WriteLine();
            Console.WriteLine("\tBut we can get close. There will be many questions asked of you, and you must make the decicions that will win or lose you the game.");
            Console.WriteLine();
            Console.WriteLine("\tWise or foolish, your choices and the dice will decide your fate!");

            //intro music method 

            DisplayContinuePrompt();
            
            userResponse = ValidateStringInput("\t\tTell me traveler, is this a new adventure or have you been down this road before? [new | continue]",
                "'new' or 'continue' please!", new string[] {"new","continue" });
            if (userResponse == "continue")
            {
                             
                bool quitApplication = false;
                //case menu 
                {
                    DisplayScreenHeader("restart shortcut");

                    Console.WriteLine("please pick the room you left off on");
                   
                    string menuChoice;
                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta) tavern ");
                    Console.WriteLine("\tb) quest start");
                    Console.WriteLine("\tc) chase");
                    Console.WriteLine("\td) cave");
                    Console.WriteLine("\te) offering room");
                    Console.WriteLine("\tq) Quit");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            storyStart();
                            break;

                        case "b":
                            TavernInterruptionStoryStart();
                            break;

                        case "c":
                            ChaseSceenChoices();
                            break;

                        case "d":
                            CaveApproach();
                            break;

                        case "e":
                            OfferingRoom();
                            break;
                                               
                        case "q":
                           
                            quitApplication = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            

                            break;
                    }

                } while (quitApplication) ;
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("\tYou've tracked the goblin raiders to thier hideout, a tomb that sits upon a hill.");
                Console.WriteLine();
                Console.WriteLine("\tWithin lies a host of monsters and the girl they kidnapped to use in thier fell ritual...If you hurry she may still be alive!");
                DisplayContinuePrompt();
                storyStart();
            }
        }

        /// <summary>
        /// Method for displaying message at failure condition, give room code for retry
        /// </summary>
        static void GameOverMessage(string header, string failureMessage)//need to send what stage the game ends if I dont want to write custom stage ends for every stage.
        {
            // call this method if the players health reaches zero or a decision is made 
            // that would lead to quest failure
            // screen header "Game Over"
            // musical method if I get the time to beep out the notes. "dun dun duuuuuh"
            // prompt user to quit or restart.
            // ask john about save states? prompt quit if that gets too complicated.
            DisplayScreenHeader(header);
            Console.WriteLine();
            Console.WriteLine("\t" + failureMessage);
            Console.WriteLine();
            DisplayContinuePrompt();

        }

        
        /// <summary>
        /// method for reader exposition text
        /// </summary>
        static void TextDumpMethod(string textDump)
        {
            // Screen header describing situation.... eg: "In the Tavern"
            Console.WriteLine();
            Console.WriteLine("\t" + textDump);
            
            // text dump method to hold 

        }

        /// <summary>
        /// string validation method
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="error"></param>
        /// <param name="validInputs"></param>
        /// <returns></returns>
        static string ValidateStringInput(string prompt, string error, string[] validInputs)
        {
            // credit goes to jp from the online class for helping me with this

            bool validInput = false;
            string userinput = "";
            int index = 0;

            while (!validInput)
            {
                //display prompt
                Console.Clear();
                Console.Write(prompt);
                userinput = Console.ReadLine();

                //check if input is valid
                for (index = 0; index < validInputs.Length; index++)
                {
                    if (validInputs[index].ToLower() == userinput.ToLower())
                    {
                        validInput = true;
                        break;
                    }
                }
                //if a valid input is not found display an error message
                if (!validInput)
                {
                    Console.WriteLine("\n{0}", error);
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                }
            }
            return validInputs[index];
        }

        /// <summary>
        /// Screen header method
        /// </summary>
        /// <param name="headerText"></param>
        static void DisplayScreenHeader(string headerText)
        {
            
            //double check if we need the console clear
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        /// <summary>
        /// Display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// set window theme
        /// </summary>
        static void SetTheme()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WindowHeight = 40;
            Console.WindowWidth = 155;
        }

        #endregion

    }


}
