using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorstRpgInTheWorld
{
    internal class gameEvent
    {
        private int money;
        private int score;
        private Player player;
        private bool gameWin = false;
        public gameEvent(Player player){
            this.player = player;
        }


        public void gameWorking()
        {
            Random random = new Random();
            int eventNumber = 1;
            int eventID;
            do
            {
                Console.WriteLine($"event number : {eventNumber}");
                if (eventNumber != 100)
                {
                eventID = random.Next(0, 4);
                switch (eventID)
                {
                    case 0:
                        getFreeMoney();
                        break;
                    case 1:
                        Shop();
                        break;
                    case 2:
                        enterFight();
                        break;
                    case 3:
                        Nothing();
                        break;

                }
                } else
                {
                    Console.WriteLine($"Well... Will you look at that... You have been doing this for the 100th time now!");
                    gameWin = true;
                }
                score++;
                eventNumber++;
                Console.ReadLine();
            } while (player.isAlive() && eventNumber != 100);
        }
        #region positiveEvent

        public void Nothing()
        {
            Random random = new Random();
            int randomText = random.Next(0, 4);
            switch (randomText)
            {
                case 0:
                    Console.WriteLine("Nothing happened for now... Just like in your life!");
                    break;
                case 1:
                    Console.WriteLine("a huge dragon appear and kill you in one hit!!!... Nah just kidding! Nothing happened! I'm sure that I scared you!");
                    break;
                case 2:
                    Console.WriteLine("You see a butterfly! That's it! Nothing else!");
                    break;
                case 3:
                    Console.WriteLine("You sit down and do nothing! A wise decision for a not-so-wise character!");
                    break;
                case 4:
                    Console.WriteLine("ZZZZZZZZZZZzzzzzz... Huh? Oh, yeah... Nothing happened! Back to sleeping I go!");
                    break;

            }
        }

        public void Shop()
        {
            char choose;
            Console.WriteLine("Oh! There is a shop! You want to go there? (Y/N) ");
            choose = char.Parse(Console.ReadLine());
            if (choose == 'Y')
            {
                Console.WriteLine("Oh! By the way! Choose carefully! You can only take one item! :)");
                do
                {
                    Console.WriteLine("'Hello Adventurer! Welcome to my humble shop!'");
                    Console.WriteLine("============|SHOP|=============");
                    Console.WriteLine($"Your money: {money}");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("(1) 10 $ : Health potion: + 10 hp, you are too stupid to carry it, so just drink it here ");
                    Console.WriteLine("(2) 15 $ Sharpener: +1 Atk, sharpen yourself! Because you have no idea how to use it on your weapon");
                    Console.WriteLine("(3) 12 $ light Armor: + 1 Def, You don't know how to put it on, but at least it boost your stat");
                    Console.WriteLine("(4) 10 $ Shiny stone: +1 magic, made in china is written on the side... It probably the magic land! Idiot...");
                    Console.WriteLine("(5) 7 $ 4 leaf clover: +1 luck, It's just a fake copy made in plastic, but I guess you can't see the difference");
                    Console.WriteLine("(6) Give all your money: -1 screwYou, Being nice can help you! Even if I think you'll do that when you are broke, you jerk");
                    Console.WriteLine("(7) Try to steal money: +1 screwYou +? money, you may succed and get some stuff, or just fail and die! Don't joke with the shopkeeper!");
                    Console.WriteLine("(8) Leave");
                    choose = char.Parse(Console.ReadLine());
                } while (choose != '1' && choose != '2' && choose != '3' && choose != '4' && choose != '5' && choose != '6' && choose != '7' && choose != '8');
                switch (choose)
                {
                    case '1':
                        if (money >= 10)
                        {
                            Console.WriteLine("You drink  the health potion, you won't die too soon I guess + 10 HP");
                            player.raiseHP(10);
                            money = money - 10;
                        } else
                        {
                            Console.WriteLine("You are too broke you BOZO! The shopkeeper kick you out!");
                        }
                        break;
                    case '2':
                        if (money >= 15)
                        {
                            Console.WriteLine("You use the sharpener on your teeth! You destroyed them! Now you are more determined to kill enemies!");
                            player.raiseATK(1);
                            money = money - 15;
                        }
                        else
                        {
                            Console.WriteLine("You are too broke you BOZO! The shopkeeper kick you out!");
                        }
                        break;
                    case '3':
                        if (money >= 12)
                        {
                            Console.WriteLine("You try to put the armor, you fail miserably and it exploded! But the experience made you soul skin harder for some reason...");
                            player.raiseDEF(1);
                            money = money - 12;
                        }
                        else
                        {
                            Console.WriteLine("You are too broke you BOZO! The shopkeeper kick you out!");
                        }
                        break;
                    case '4':
                        if (money >= 10)
                        {
                            Console.WriteLine("You eat the stone, your stomach didn't like that! but for some reason it worked! You gain more magic!");
                            player.raiseMAGIC(1);
                            money = money - 10;
                        }
                        else
                        {
                            Console.WriteLine("You are too broke you BOZO! The shopkeeper kick you out!");
                        }
                        break;
                    case '5':
                        if (money >= 7)
                        {
                            Console.WriteLine("You look at the 4 leaf clover! It dissolve because of your ugly stare! But since you destroyed a fake one, you gained luck!");
                            player.raiseLUCK(1);
                            money = money - 7;
                        }
                        else
                        {
                            Console.WriteLine("You are too broke you BOZO! The shopkeeper kick you out!");
                        }
                        break;
                    case '6':
                        if (money >= 1)
                        {
                            Console.WriteLine("You give all your money to the shopkeeper who just look at you thinking you are stupid, but you won't get screwed too often anymore");
                            player.raiseSY(-1);
                            money = 0;
                        }
                        else
                        {
                            Console.WriteLine("You are too broke you BOZO! The shopkeeper kick you out!");
                        }
                        break;
                    case '7':
                        Random random = new Random();
                        int r1 = random.Next(1, player.getLuck());
                        int r2 = random.Next(1, player.getScrewed());
                        if (r1 > r2)
                        {
                            Console.WriteLine("You stole money! The shopkeeper won't remember since he has alzheimer! You stole money from a sick man! You really are an horrible person!");
                            money =+ random.Next(1, player.getLuck()*2 - player.getScrewed());
                            Console.WriteLine($"You now have {money}! Oh and you get 1 screwYou point because F*** you!");

                        } else
                        {
                            Console.WriteLine("You screwed up! The shopkeeper kicks you out with his famous technique: 'GETTHEF*CKOUTOFMYSHOP!!!' you lost 5 hps");
                            player.raiseHP(-5);
                        }
                        player.raiseSY(1);
                        break;
                    case '8':
                        Console.WriteLine("You decide to leave, but you hit your face on the door, nice waste of time!");
                        break;
                }
            } else if (choose == 'N'){
                Console.WriteLine("Wha... It's a bonus you dumbass! Jeez... Ok! Don't go there! Do what you want!");
            } else
            {
                Console.WriteLine("You know what? Screw you! If you can't write, you can't shop!");
            }
        }

        public void getFreeMoney()
        {
            char choose;
            Console.WriteLine("there seems to be a lost purse on the ground, do you want to take it? (Y/N)");
            choose = char.Parse(Console.ReadLine());
            if (choose == 'Y')
            {
                Random random = new Random();
                int r1 = random.Next(1, player.getLuck());
                int r2 = random.Next(1, player.getScrewed());
                if (r1 > r2 * 2)
                {
                    Console.WriteLine("WOW! You found the lucky fairy in that purse! She gave you + 5 in every stats (exept screwYou) and 30 gold! Now say thank you!");
                    player.raiseHP(5);
                    player.raiseDEF(5);
                    player.raiseATK(5);
                    player.raiseMAGIC(5);
                    player.raiseLUCK(5);
                    money = money + 30;
                } else if (r1 > r2)
                {
                    Console.WriteLine("you found some money, nice! You are now a thief!");
                    money = money + random.Next(1, player.getLuck() * 2);
                } else if (r1 == r2)
                {
                    Console.WriteLine("It was empty, useless! Now you know how your parents felt when they got you!");
                } else if (r1 < r2 / 4)
                {
                    Console.WriteLine("You were about to take it when a meteorite felt from the sky!");
                    player.resistance(r2 * 4, 32);
                    Console.WriteLine("That was worth it! :)");
                } else if (r1<r2 /2) {
                    Console.WriteLine("It was a trap! Right when you took it, it EXPLODED!");
                    player.resistance(r2, 8);
                } else
                {
                    Console.WriteLine("You went to get it, but you triped on a rock AND you fell on a rock, now that's just unlucky...");
                    player.resistance(r2/2, 4);
                }
            } else
            {
                Console.WriteLine("You decided to walk by pretending to ignore it! But you trip and fall on the ground like an idiot! Well, good news! You lost nothing!");
            }

        }

        #endregion positiveEvent

        #region negativeEvent

        public void enterFight()
        {
            bool ranAway = true;
            Random random  = new Random();
            Enemy monster = new Enemy(player.getGeneralStat() * random.Next(1, (player.getScrewed() / 10) + 1) + 5);
            int enemyValue = monster.getGeneralStat();
            string enemyName = monster.getName();
            Console.WriteLine("Oh no! An Enemy appeared!");
            char choose;
            Console.WriteLine($"You are attacked by {monster.getName()}");
            do
            {
                do
                {
                    Console.WriteLine($"Your hps : {player.getHp()}, Enemy's Hp : {monster.getHp()}");
                    Console.WriteLine("What do you want to do? (Please die)");
                    Console.WriteLine("(A)ttack : Attack the enemy, the stronger you are, the best you will do!");
                    Console.WriteLine("(M)agic : Use a magic attack! That's it!");
                    Console.WriteLine("(D)ance : Be an idiot and waste your turn, but who knows? It might do something useful");
                    Console.WriteLine("(R)un away : Attack the enemy, the stronger you are, the best you will do!");
                    choose = char.Parse(Console.ReadLine());
                } while (choose != 'A' && choose != 'M' && choose != 'D' && choose != 'R');
                switch (choose)
                {
                    case 'A':
                        int attackDamage;
                        if (random.Next(1, 100) * player.getLuck() > 10 * player.getScrewed())
                        {
                            attackDamage = player.attackDamage(monster.getDef());
                            Console.WriteLine($"You attack! You dealt {attackDamage}!");
                        }
                        else
                        {
                            attackDamage = ((player.attackDamage(monster.getDef()) / 100) + 1);
                            Console.WriteLine($"You tried to attack! You tripped on a rock and trowed your weapon at the enemy, dealing {attackDamage}! You suck!");
                        }
                        monster.raiseHP(-attackDamage);

                        break;
                    case 'M':
                        Console.WriteLine("You used your magic!");
                        int magicDamage = player.magicAttack(monster.getLuck());
                        Console.WriteLine($"You dealt {magicDamage}!");
                        monster.raiseHP(-magicDamage);
                        break;
                    case 'D':
                        Console.WriteLine("You danced like a dumbass! Expecting something to happen!");
                        break;
                    case 'R':
                        if (random.Next(1, player.getLuck()) > random.Next(0, player.getScrewed()))
                        {
                            Console.WriteLine("You ran away like a little b*tch!");
                            ranAway = false;
                        }
                        else
                        {
                            Console.WriteLine("You tried to run, but you fell like an idiot!");
                        }
                        break;
                }
                if (player.isAlive() && monster.isAlive() && ranAway)
                    {
                    Console.WriteLine($"{monster.getName()}'s turn! (I hope you die!)");
                    player.resistance(monster.getAtk(), monster.getLuck());
                    }

            } while (player.isAlive() && monster.isAlive() && ranAway);
            if (monster.isAlive() == false)
            {
                Console.WriteLine($"Congrats Jerk... You won {enemyValue / 10}$!");
                money = money + enemyValue / 10;
            } 
        }

        public void encounterRobber()
        {

            Random random = new Random();
            int eventID = random.Next(0,5);
            char choice = ' ';
            Console.WriteLine("A strange man ask you money, what do you do? (Choose carefully)");
            Console.WriteLine("(G)ive him your money");
            Console.WriteLine("(S)cream for help");
            Console.WriteLine("(F)ight the stranger");
            Console.WriteLine("(T)alk to the stranger");
            Console.WriteLine("(R)un away or at least try");
            choice = char.Parse(Console.ReadLine());

            switch (choice)
            {
                case 'G':
                    switch (eventID)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        default:

                            break;
                    }
                    break;
                case 'S':
                    switch (eventID)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        default:

                            break;
                    }
                    break;
                case 'F':
                    switch (eventID)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        default:

                            break;
                    }
                    break;
                case 'T':
                    switch (eventID)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        default:

                            break;
                    }
                    break;
                case 'R':

                    break;
                default:
                    Console.WriteLine("You had an heart attack because you couldn't choose, unfortunatly, you didn't die, but you were left on 1HP, next time choose! You dumbass!");
                    player.raiseHP((- player.getHp()) + 1);
                    break;
            }
        }
        #endregion negativeEvent

        public bool getGameWin()
        {
            return gameWin;
        }
    }
}
