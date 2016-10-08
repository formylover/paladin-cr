using Paladin.SpellBooks.Talents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paladin.SpellBooks.Specs
{
    public abstract class PaladinTalents : ITalents
    {
        #region Tier 3
        private Talent _fistOfJustice;
        public Talent FistOfJustice
        {
            get
            {
                if (_fistOfJustice == null)
                {
                    _fistOfJustice = new Talent() { Name = "Fist of Justice", Row = 3, Column = 1 };
                }
                return _fistOfJustice;
            }
            set
            {
                _fistOfJustice = value;
            }
        }

        private Talent _repentance;
        public Talent Repentance
        {
            get
            {
                if (_repentance == null)
                {
                    _repentance = new Talent() { Name = "Repentance", Row = 3, Column = 2 };
                }
                return _repentance;
            }
            set
            {
                _repentance = value;
            }
        }

        private Talent _blindingLight;
        public Talent BlindingLight
        {
            get
            {
                if (_blindingLight == null)
                {
                    _blindingLight = new Talent() { Name = "Blinding Light", Row = 3, Column = 3 };
                }
                return _blindingLight;
            }
            set
            {
                _blindingLight = value;
            }
        }
        #endregion
    }
}
