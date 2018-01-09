using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Slime
    {

        public enum Charms
        {
            REDCHARM, //Attack , Can add additional damage when you attack, Using the slime will apply fire to your sword for 2 turns, Chance to inflict burn TBA
            BLUECHARM,//Defence , Chance to negate some damage (1,5) if damage already low then enemy deals (1) damage
            PINKCHARM, //Regeneration , Use to heal yourself for 5 damage. After every battle heal for 5 health
            GREENCHARM //Extra Experience
        
        }

        private string _color;
        private int _health;
        private int _damage;
        //private bool _passive;
        private bool _king;
        private bool _hasCharm;
        private Charms _charm;
        private bool _encounter;

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

        //public bool Passive
        //{
        //    get { return _passive; }
        //    set { _passive = value; }
        //}

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

        public bool HasCharm
        {
            get { return _hasCharm; }
            set { _hasCharm = value; }
        }

        public Charms AllyCharm
        {
            get { return _charm; }
            set { _charm = value; }
        }

        public bool AllyDisabler
        {
            get { return _encounter; }
            set { _encounter = value; }
        }

        #endregion

    }
}