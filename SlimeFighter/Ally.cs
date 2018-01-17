using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    public class Ally
    {

        #region Call Names

        public enum Effect
        {
            FIRE, 
            WATER,
            SHARPEN, // Sharpens your blade to deal more damage
            REGENERATION // Heals you
        };

        public enum Charms
        {
            REDCHARM, //Attack , Can add additional damage when you attack, Using the slime will apply fire to your sword for 2 turns, Chance to inflict burn TBA
            BLUECHARM,//Defence , Chance to negate some damage (1,5) if damage already low then enemy deals (1) damage
            PINKCHARM, //Regeneration , Use to heal yourself for 5 damage. After every battle heal for 5 health
            GREENCHARM //Extra Experience

        }


        private Charms _charm;
        private string _name;
        private bool _active;
        private string _exp;
        private Effect _effect;
        #endregion

        #region Properties
        public Charms Charm
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
