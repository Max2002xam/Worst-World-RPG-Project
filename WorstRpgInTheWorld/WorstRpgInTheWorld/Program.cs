namespace WorstRpgInTheWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Player player;
            gameEvent gameEvents;
            Random random = new Random();
            int[] test = new int[2];
            string heroName;
            char choseClass = ' ';
            Console.WriteLine("Hello, Dumbass! Welcome to the world worst RPG!");
            Console.WriteLine("Ok idiot! First of all, what is your name?");
            Console.WriteLine("========================");
            heroName = Console.ReadLine();
            program.insultPlayerName(heroName);
            do
            {
                Console.WriteLine("Ok.... Guy that I already forgot the name, what class do you want?");
                Console.WriteLine("========================");
                Console.WriteLine("(A)dventurer - Generalist, get + 5 in every stat by default (exept the worst stat)");
                Console.WriteLine("(S)oldier - Brave and Strong! (unlike you!) has + 10 HP + 10 DEF + 10 ATK but get 3 bad point because SCREW YOU!");
                Console.WriteLine("(M)age - has pretty decent magic and luck, but the other stats are basic, + 15 MAGIC + 15 LUCK + 3 bad points");
                Console.WriteLine("(B)arbarian - Only has good attack bonus, otherwise it's an idiot, just like you! + 20 ATK");
                Console.WriteLine("(I)diot - I made this class just for you! No bonuses exept for luck since I think that it's only because of your luck that you are still alive today! + 30 LUCK");
                choseClass = char.Parse(Console.ReadLine());
                if ((choseClass != 'A' && choseClass != 'S' && choseClass != 'M' && choseClass != 'B' && choseClass != 'I'))
                {
                    Console.WriteLine("Ok dumbass! Are you too stupid to write the first letter of a class correctly?");
                }
            } while (choseClass != 'A' && choseClass != 'S' && choseClass != 'M' && choseClass != 'B' && choseClass != 'I');
            player = program.createPlayer(choseClass);
            Console.WriteLine("ok, now, we'll display the stats!");
            Console.WriteLine("========================");
            player.displayStats();
            Console.WriteLine("========================");
            Console.WriteLine("You happy with that?");
            Console.ReadLine();
            Console.WriteLine("Don't care, You'll go with that!");
            gameEvents = new gameEvent(player);
            Console.WriteLine("Now It's time to start this randomly generated adventure! LEZGOOOOOOO:");
            gameEvents.gameWorking();

            if (gameEvents.getGameWin() != true)
            {
                Console.WriteLine($"RIP : {heroName} he sucked, even in death!");
                Console.WriteLine("final look at the stats:");
                player.displayStats();
            } else
            {
                Console.WriteLine("It's a surprise... Really! Who would spend so much time getting abused by a computer? Well... I never knew you whould be that stupid!");
                Console.WriteLine("What? Oh... You were expecting me to say something nice since you have won? Are you that stupid?");
                Console.WriteLine($"You just wasted your time beating this! But I guess I can congratulate your stubborness... Great job {heroName}! The simple fact I called you by your name should be enough for you!");
                Console.WriteLine($"Ok, before you go, anything to say as the winner of stupidity?");
                Console.ReadLine();
                Console.WriteLine("Heh... I shouldn't expect much from you!");
                Console.WriteLine("Now get out! Go touch some grass or something! Get out of my sight!");
                Console.WriteLine("Oh and yeah, here is a final look at the stats:");
                player.displayStats();
            }
        }

        public void insultPlayerName(string name)
        {
            Random random = new Random();
            int playerInsultId = random.Next(0, 9);
            switch (playerInsultId)
            {
                case 0:
                    Console.WriteLine($"{name}? Heh... I guess I have seen worst...");
                    break;
                case 1:
                    Console.WriteLine($"{name}? Well that's original! That's my way of saying it sucks...");
                    break;
                case 2:
                    Console.WriteLine($"{name}? It's so bad... I guess that's a good name for you");
                    break;
                case 3:
                    Console.WriteLine($"{name}? Are you serious? Well... I guess your parents didn't really want to have a child");
                    break;
                case 4:
                    Console.WriteLine($"{name}? AHAHAHAHAHAHAH!..... Wait you are serious?");
                    break;
                case 5:
                    Console.WriteLine($"{name}? No way! That's my brother's name!         No just kidding! Nobody in my family has such a bad name");
                    break;
                case 6:
                    Console.WriteLine($"{name}? Well... at least you have a name... Nevermind, having no name would have been better");
                    break;
                case 7:
                    Console.WriteLine($"{name}? I am pretty sure It means 'idiot' in a language... I don't remember which one but I guess it describe you well!");
                    break;
                case 8:
                    Console.WriteLine($"{name}? If I had a penny every time I heard a name worst than that, I would be broke!");
                    break;
                case 9:
                    Console.WriteLine($"{name}? wait... Nevermind... I don't care anymore...");
                    break;
            }
        }

        public Player createPlayer(char classType)
        {
            int generalStat = 100;
            Random random = new Random();
            int[] stat = new int[6];
            for (int i = 0; i < stat.Length - 1; i++)
            {
                stat[i] = random.Next(1, generalStat / 4);
                generalStat = generalStat - stat[i];
                if (classType == 'A')
                {
                    stat[i] = stat[i] + 5;
                }
            }
            stat[5] = generalStat;
            if (classType == 'S'){
                stat[0] = stat[0] + 10;
                stat[1] = stat[1] + 10;
                stat[2] = stat[2] + 10;
                stat[5] = stat[5] + 3;
            }
            if (classType == 'M')
            {
                stat[3] = stat[3] + 15;
                stat[4] = stat[4] + 15;
                stat[5] = stat[5] + 3;
            }
            if (classType == 'B')
            {
                stat[1] = stat[1] + 20;
            }
            if (classType == 'I')
            {
                stat[4] = stat[4] + 30;
            }
            return new Player(stat[0], stat[1], stat[2], stat[3], stat[4], stat[5] / 2);
        }
    }
}