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
        private int _gold;
        private bool _defending;
        private bool _pinkCharm;
        private string _allyEffect;
        private string _allyName;
        private bool _allyPresent;




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

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public bool Defending
        {
            get { return _defending; }
            set { _defending = value; }
        }

        public bool PinkCharm
        {
            get { return _pinkCharm; }
            set { _pinkCharm = value; }
        }

        public string AllyName
        {
            get { return _allyName; }
            set { _allyName = value; }
        }

        public string AllyEffect
        {
            get { return _allyEffect; }
            set { _allyEffect = value; }
        }

        public bool AllyPresent
        {
            get { return _allyPresent; }
            set { _allyPresent = value; }
        }
        

        
        
        #endregion
    }
}
