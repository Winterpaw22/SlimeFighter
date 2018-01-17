using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeQuest
{
    public class Slime
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

        //private bool Passive
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


        #region Methods and Initializers
        /// <summary>
        /// Creates slimes's to fight against. Fixup later so it can give different slimes depending on level
        /// </summary>
        /// <param name="slime">The slime class that must be passed through to collect new data for every slime this creates</param>
        /// <param name="ally">For activating the ally charm and setting it somewhat up</param>
        static public void InitializeNewSlime(Slime slime, Ally ally)
        {
            //A random system to handle the slime
            Random random = new Random();
            int slimeType = random.Next(1, 5);
            int charmChance = random.Next(1, 10);

            //Green Slime Builder
            if (slimeType == 1)
            {
                slime.Health = 20;
                slime.Damage = 2;
                slime.Color = "green";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.GREENCHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;
            }
            //Red Slime Builder
            else if (slimeType == 2)
            {
                slime.Health = 20;
                slime.Damage = 5;
                slime.Color = "red";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.REDCHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;
            }
            //Blue Slime Builder
            else if (slimeType == 3)
            {
                slime.Health = 30;
                slime.Damage = 4;
                slime.Color = "blue";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.BLUECHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;
            }
            //Pink Slime Builder
            else if (slimeType == 4)
            {
                slime.Health = 45;
                slime.Damage = 3;
                slime.Color = "pink";

                if (charmChance < 5 && ally.Active)
                {
                    ally.Charm = Ally.Charms.PINKCHARM;
                    slime.HasCharm = true;
                }
                else slime.HasCharm = false;

            }
            //Pine Slime Builder
            else
            {
                //just in case something goes wrong a slime is still initialized, although a weak one
                slime.Health = 10;
                slime.Damage = 1;
                slime.Color = "pine";
                slime.HasCharm = false;

            }
            //King Slime builder
            if (slime.KingSlime)
            {
                slime.HasCharm = false;
                slime.Health = 55;
                slime.Damage = 10;
                slime.Color = "purple";
                //if (charmChance < 5 && ally.Active)
                //{
                //    ally.Charm = Ally.Charms.GREENCHARM;
                //    slime.HasCharm = true;
                //}
                //else slime.HasCharm = false;
            }


        }
        #endregion
    }
}