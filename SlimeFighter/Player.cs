using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Player
    {
        private string _name;
        private int _health;
        private int[] _damage;
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
    }
}
