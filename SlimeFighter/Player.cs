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
        private int _damage;
        private int _allyDamage;
        private bool _allyPresent;
        private string _ally;
        private int _gold;
        private bool _defending;


        #region Properties

        public bool Defending
        {
            get { return _defending; }
            set { _defending = value; }
        }

        public bool AllyPresent
        {
            get { return _allyPresent; }
            set { _allyPresent = value; }
        }

        public string Ally
        {
            get { return _ally; }
            set { _ally = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public int AllyDamage
        {
            get { return _allyDamage; }
            set { _allyDamage = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        #endregion
    }
}
