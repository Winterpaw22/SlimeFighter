using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    public class Player
    {
        private string _name;
        private int _health;
        private int _maxHealth;
        private int[] _damage;
        private int _defense;
        private int _gold;
        private int _exp;
        
        


        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }


        public int[] Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }


        public int Experience
        {
            get { return _exp; }
            set { _exp = value; }
        }
        #endregion


        /// <summary>
        /// Initializes the player
        /// </summary>
        /// <param name="player"> The player class that holds all the players stats</param>
        /// <param name="playerName"> Takes in the a name the player wants and names the player</param>
        public static void InitializePlayer(Player player, string playerName)
        {
            player.Name = playerName;
            player.Health = 100;
            player.MaxHealth = 100;
            player.Defense = 5;
            player.Damage = new int[2];
            player.Damage[0] = 1;
            player.Damage[1] = 7;
            player.Experience = 0;
        }
    }
}
