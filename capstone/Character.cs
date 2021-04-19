using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Character
    {
        public enum Atitude
        {
            happy,
            tired,
            angry,
            sad,
        }

        #region Fields
        private string _name;
        private int _hp;
        private bool _isAlive;
       

        private int _CHA;
        private int _INT;
        private int _STR;
        private int _WIS;
        private int _DEX;
        private int _CON;


        #endregion

        #region Stuff

        public int Constitution
        {
            get { return _CON; }
            set { _CON = value; }
        }

        public int Dexterity
        {
            get { return _DEX; }
            set { _DEX = value; }
        }

        public int Wisdom
        {
            get { return _WIS; }
            set { _WIS = value; }
        }

        public int Strength
        {
            get { return _STR; }
            set { _STR = value; }
        }

        public int Charisma
        {
            get { return _CHA; }
            set { _CHA = value; }
        }

        public int Intellegence
        {
            get { return _INT; }
            set { _INT = value; }
        }

       
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitPoints
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public bool isAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }


        #endregion
        #region constructors
        public Character()
        {

        }

        public Character( string Name, int HitPoints, int Constitution, int Dexterity, int Wisdom, int Strength, int Charisma, int Intellegence )
        {
            _name = Name;
            _hp = HitPoints;
            _CON = Constitution;
            _DEX = Dexterity;
            _WIS = Wisdom;
            _STR = Strength;
            _CHA = Charisma;
            _INT = Intellegence;
        }

        public static int DiceRoll(int numberOfSides)
        {
            Random random = new Random((int)DateTime.Now.Millisecond);
            
            return random.Next(1, numberOfSides + 1);

        }
        #endregion

    }
}
