using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Slime
    {

        static string _color;
        static int _health;
        static int _damage;
        static bool _passive;

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

        #endregion

    }
}