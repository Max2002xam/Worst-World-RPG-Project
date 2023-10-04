using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorstRpgInTheWorld
{
    internal class Player
    {
        private int hp;
        private int atk;
        private int def;
        int magic;
        int luck;
        int screwYou;
        Random random = new Random();
        public Player(int hp, int atk, int def, int magic, int luck, int screwYou)
        {
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.magic = magic;
            this.luck = luck;
            this.screwYou = screwYou;
        } 

        public int attackDamage(int enemyDef)
        {
            int damage = (atk + (luck / random.Next(2, (luck * screwYou) + 2)) / 2) * 2 - ((enemyDef + random.Next(1, screwYou) / 4) + 1);
            if (damage < 2)
            {
                damage = 2;
            }
            return damage;
        }

        public void resistance(int enemyAtk, int enemyLuck)
        {
            int damage;
            damage = (((enemyAtk + (random.Next(1, enemyLuck) / 4)))*2 / ((def * ((random.Next(1, luck))/4))+1));
            if (damage < 2)
            {
                damage = 1;
            }
            Console.WriteLine($"You took {damage} damage!");
            hp = hp - damage;
        }

        public int magicAttack(int enemyLuck)
        {
            if (random.Next(1,luck)*4 - screwYou > ((magic / luck) + screwYou) /2)
            {
                return (magic * (random.Next(1,luck) / 8) - random.Next(0, enemyLuck / 2));
            } else
            {
                Console.WriteLine("You messed up!");
                return 1;
            }
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

        public void displayStats()
        {
            Console.WriteLine($"Hps :{hp}");
            Console.WriteLine($"Atk :{atk}");
            Console.WriteLine($"Def :{def}");
            Console.WriteLine($"Magic :{magic}");
            Console.WriteLine($"Luck :{luck}");
            Console.WriteLine($"screwYou :{screwYou} (Yes, that's an actual stat!)");
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

        public int getScrewed()
        {
            return screwYou;
        }

        public void raiseSY(int screwYouGain)
        {
            screwYou = screwYou + screwYouGain;
        }

        public int getGeneralStat()
        {
            return (hp + atk + def + magic + luck);
        }

    }
}
