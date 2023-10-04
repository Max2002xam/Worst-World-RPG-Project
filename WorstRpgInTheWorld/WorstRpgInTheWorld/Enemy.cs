using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorstRpgInTheWorld
{
    internal class Enemy
    {
        int baseStat;
        int hp;
        int atk;
        int def;
        int magic;
        int luck;
        string name = "";
        Random random = new Random();
        public Enemy(int baseStat)
        {
            this.baseStat = baseStat;
            generateName();
            generateStat();
        } 

        public bool isAlive()
        {
            if (hp <= 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        private void generateStat()
        {
            int[] stat = new int[5] { 1, 1, 1, 1, 1};
            int statChange;
            Random random = new Random();
            int isBoss = random.Next(1, 20);
            if (isBoss == 1 || isBoss == 2 || isBoss == 3)
            {
                name = name + " MINIBOSS";
                baseStat = baseStat * 2;
            }
            if (isBoss == 4)
            {
                name = name + " BOSS";
                baseStat = baseStat * 5;
            }

            do
            {
                for (int i = 0; i < stat.Length - 1; i++)
                {
                    if (baseStat <= 3)
                    {
                        stat[i] = stat[i] + baseStat;
                        baseStat = 0;
                    } else
                    {
                        statChange = random.Next(1, baseStat / 4);
                        stat[i] = stat[i] + statChange;
                        baseStat = baseStat - stat[i];
                    }
                }
            } while (baseStat > 0);
            hp = stat[0];
            atk = stat[1];
            def = stat[2];
            magic = stat[3];
            luck = stat[4];
        }

        private void generateName()
        {
            Random random = new Random();
            List<string> race = new List<string>() {"Goblin", "Slime", "DragonNewt", "Human", "Undead", "Vampire", "Idiot", "Anime Reference", "Low Paid Employe", "Orc", "Ogre", "Living Vegetable", "Granny", "Milf","Donut Baker", "Anime Protagonist", "Meme man", ""};
            List<string> title = new List<string>() {"The King", "The Emperor", "The Rookie killer", "The Devourer", "The Assassin", "The programmer (Self-insert, fuck you!)", "The Pirate King", "The Thieves chief", "The Meme Lord", "" };
            List<string> color = new List<string>() {"Red", "Blue", "Green", "Brown", "White", "Black", "Gold", "Silver", "Orange", "Lime", "Purple", "Grey", "Lemon", "Invisible (You can still hit it, it's just his name idiot!)", ""};
            List<string> creatureName = new List<string>() {"Gerard","Dimisculus","Jotaro","Noah","Tibo","Daniel","Ube","Jemnolpirst","Xx_D4rk_m0nst4r_xX","Jason","Velra","Gordima","Ripolm","Holp","Uvli","Dirlimini","Ferta","Gordon","Miko","Suavamente","Comic Sans","Zaberry","Elvio", ""};
            int idRace = random.Next(0, race.Count() - 1);
            int idTitle = random.Next(0, title.Count() - 1);
            int idColor = random.Next(0, color.Count() - 1);
            int idCreatureName = random.Next(0, creatureName.Count() - 1);

            name = name + creatureName[idCreatureName].ToString() + ", The " + color[idColor].ToString() + " " + race[idRace].ToString();
            if (baseStat > 200)
            {
                name = name + ", " + title[idTitle];
                if (baseStat > 500)
                {
                    idTitle = random.Next(0, title.Count() - 1);
                    name = name + " of " + title[idTitle] + " (Big stats! I hope you die!)";
                }
            }

        }

        public int getHp()
        {
            return hp;
        }

        public void raiseHP(int hpGain)
        {
            hp = hp + hpGain;
        }

        public int getAtk()
        {
            return atk;
        }

        public void raiseATK(int atkGain)
        {
            atk = atk + atkGain;
        }

        public int getDef()
        {
            return def;
        }

        public void raiseDEF(int defGain)
        {
            def = def + defGain;
        }

        public int getMagic()
        {
            return magic;
        }
        public void raiseMAGIC(int magicGain)
        {
            magic = magic + magicGain;
        }

        public int getLuck()
        {
            return luck;
        }
        public void raiseLUCK(int luckGain)
        {
            luck = luck + luckGain;
        }

        public string getName()
        {
            return name;
        }

        public int getGeneralStat()
        {
            return (hp + atk + def + magic + luck);
        }
    }
}
