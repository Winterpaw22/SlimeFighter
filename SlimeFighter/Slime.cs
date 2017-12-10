using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Slime
    {

        private string _color;
        private int _health;
        private int _damage;
        private bool _passive;
        private bool _king;
        private bool _pinkCharm;
        private bool _pinkEncounter;

        #region Properties

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public bool Passive
        {
            get { return _passive; }
            set { _passive = value; }
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public bool KingSlime
        {
            get { return _king; }
            set { _king = value; }
        }

        public bool PinkCharmAlly
        {
            get { return _pinkCharm; }
            set { _pinkCharm = value; }
        }

        public bool PinkSlimeDisabler
        {
            get { return _pinkEncounter; }
            set { _pinkEncounter = value; }
        }

        #endregion

    }
}