using Styx;
using Styx.WoWInternals;
using System.Collections.Generic;

namespace Paladin.SpellBooks.Specs.Holy
{
    public partial class HolySpells : PaladinSpells<HolyTalents>
    {
        private HolyTalents _myTalents;
        public override HolyTalents MyTalents
        {
            get
            {
                if (_myTalents == null)
                {
                    _myTalents = new HolyTalents();
                }
                return _myTalents;
            }
            set
            {
                _myTalents = value;
            }
        }

        private Spell _auraMastery;
        public Spell AuraMastery
        {
            get
            {
                if (_auraMastery == null)
                {
                    int _id = 31821;
                    _auraMastery = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _auraMastery;
            }
        }

        private Spell _bestowFaith;
        public Spell BestowFaith
        {
            get
            {
                if (_bestowFaith == null)
                {
                    int _id = 223306;
                    _bestowFaith = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _bestowFaith;
            }
        }

        private Spell _beaconOfLight;
        public Spell BeaconOfLight
        {
            get
            {
                if (_beaconOfLight == null)
                {
                    int _id = 53563;
                    _beaconOfLight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _beaconOfLight;
            }
        }

        private Spell _cleanse;
        public Spell Cleanse
        {
            get
            {
                if (_cleanse == null)
                {
                    int _id = 4987;
                    _cleanse = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _cleanse;
            }
        }

        private Spell _divineProtection;
        public Spell DivineProtection
        {
            get
            {
                if (_divineProtection == null)
                {
                    int _id = 498;
                    _divineProtection = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _divineProtection;
            }
        }

        private Spell _holyAvenger;
        public Spell HolyAvenger
        {
            get
            {
                if (_holyAvenger == null)
                {
                    int _id = 105809;
                    _holyAvenger = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _holyAvenger;
            }
        }

        private Spell _holyLight;
        public Spell HolyLight
        {
            get
            {
                if (_holyLight == null)
                {
                    int _id = 82326;
                    _holyLight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _holyLight;
            }
        }

        private Spell _holyShock;
        public Spell HolyShock
        {
            get
            {
                if (_holyShock == null)
                {
                    int _id = 20473;
                    _holyShock = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _holyShock;
            }
        }

        private Spell _lightOfDawn;
        public Spell LightOfDawn
        {
            get
            {
                if (_lightOfDawn == null)
                {
                    int _id = 85222;
                    _lightOfDawn = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _lightOfDawn;
            }
        }

        private Spell _lightOfTheMatyr;
        public Spell LightOfTheMatyr
        {
            get
            {
                if (_lightOfTheMatyr == null)
                {
                    int _id = 193998;
                    _lightOfTheMatyr = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _lightOfTheMatyr;
            }
        }

        private Spell _ruleOfLaw;
        public Spell RuleOfLaw
        {
            get
            {
                if (_ruleOfLaw == null)
                {
                    int _id = 214202;
                    _ruleOfLaw = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _ruleOfLaw;
            }
        }

        private Spell _tyrsDeliverance;
        public Spell TyrsDeliverance
        {
            get
            {
                if (_tyrsDeliverance == null)
                {
                    int _id = 200652;
                    _tyrsDeliverance = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _tyrsDeliverance;
            }
        }

        protected override IEnumerable<Spell> Blessings()
        {
            return new List<Spell>();
        }
    }
}