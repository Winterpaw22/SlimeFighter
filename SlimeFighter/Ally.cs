using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    class Ally
    {

        #region Call Names

        public enum Effect
        {
            FIRE, 
            WATER,
            POISON,
            REGENERATION
        };

        private bool _charm;
        private string _name;
        private bool _active;
        private string _exp;
        private Effect _effect;
        #endregion

        #region Properties
        public bool Charm
        {
            get { return _charm; }
            set { _charm = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Effect Type
        {
            get { return _effect; }
            set { _effect = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
       
#endregion
    }
}
