using Styx;
using Styx.WoWInternals;
using System.Collections.Generic;

namespace Paladin.SpellBooks.Specs.Protection
{
    public partial class ProtectionSpells : PaladinSpells<ProtectionTalents>
    {
        private ProtectionTalents _myTalents;
        public override ProtectionTalents MyTalents
        {
            get
            {
                if (_myTalents == null)
                {
                    _myTalents = new ProtectionTalents();
                }
                return _myTalents;
            }
            set
            {
                _myTalents = value;
            }
        }

        private Spell _ardentDefender;
        public Spell ArdentDefender
        {
            get
            {
                if (_ardentDefender == null)
                {
                    int _id = 31850;
                    _ardentDefender = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _ardentDefender;
            }
        }

        private Spell _avengersShield;
        public Spell AvengersShield
        {
            get
            {
                if (_avengersShield == null)
                {
                    int _id = 31935;
                    _avengersShield = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _avengersShield;
            }
        }

        private Spell _bastionOfLight;
        public Spell BastionOfLight
        {
            get
            {
                if (_bastionOfLight == null)
                {
                    int _id = 204035;
                    _bastionOfLight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _bastionOfLight;
            }
        }

        private Spell _blessingOfSacrifice;
        public Spell BlessingOfSacrifice
        {
            get
            {
                if (_blessingOfSacrifice == null)
                {
                    int _id = 6940;
                    _blessingOfSacrifice = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfSacrifice;
            }
        }

        private Spell _blessedHammer;
        public Spell BlessedHammer
        {
            get
            {
                if (_blessedHammer == null)
                {
                    int _id = 204019;
                    _blessedHammer = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessedHammer;
            }
        }

        private Spell _consecration;
        public Spell Consecration
        {
            get
            {
                if (_consecration == null)
                {
                    int _id = 26573;
                    _consecration = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _consecration;
            }
        }

        private Spell _eyeOfTyr;
        public Spell EyeOfTyr
        {
            get
            {
                if (_eyeOfTyr == null)
                {
                    int _id = 209202;
                    _eyeOfTyr = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _eyeOfTyr;
            }
        }

        private Spell _guardianOfAncientKings;
        public Spell GuardianOfAncientKings
        {
            get
            {
                if (_guardianOfAncientKings == null)
                {
                    int _id = 86659;
                    _guardianOfAncientKings = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _guardianOfAncientKings;
            }
        }

        private Spell _hammerOfRighteous;
        public Spell HammerOfRighteous
        {
            get
            {
                if (_hammerOfRighteous == null)
                {
                    int _id = 53595;
                    _hammerOfRighteous = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _hammerOfRighteous;
            }
        }

        private Spell _handOfTheProtector;
        public Spell HandOfTheProtector
        {
            get
            {
                if (_handOfTheProtector == null)
                {
                    int _id = 213652;
                    _handOfTheProtector = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _handOfTheProtector;
            }
        }

        private Spell _shieldOfTheRighteous;
        public Spell ShieldOfTheRighteous
        {
            get
            {
                if (_shieldOfTheRighteous == null)
                {
                    int _id = 53600;
                    _shieldOfTheRighteous = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _shieldOfTheRighteous;
            }
        }

        private Spell _seraphim;
        public Spell Seraphim
        {
            get
            {
                if (_seraphim == null)
                {
                    int _id = 152262;
                    _seraphim = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _seraphim;
            }
        }

        protected override IEnumerable<Spell> Blessings()
        {
            return new List<Spell>();
        }
    }
}