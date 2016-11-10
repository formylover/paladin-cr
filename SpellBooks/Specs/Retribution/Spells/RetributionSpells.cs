using Styx;
using Styx.WoWInternals;
using System.Collections.Generic;

namespace Paladin.SpellBooks.Specs.Retribution
{
    public partial class RetributionSpells : PaladinSpells<RetributionTalents>
    {
        private RetributionTalents _myTalents;
        public override RetributionTalents MyTalents
        {
            get
            {
                if (_myTalents == null)
                {
                    _myTalents = new RetributionTalents();
                }
                return _myTalents;
            }
            set
            {
                _myTalents = value;
            }
        }

        private Spell _bladeOfWrath;
        public Spell BladeOfWrath
        {
            get
            {
                if (_bladeOfWrath == null)
                {
                    int _id = 202270;
                    _bladeOfWrath = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _bladeOfWrath;
            }
        }

        private Spell _bladeOfJustice;
        public Spell BladeOfJustice
        {
            get
            {
                if (_bladeOfJustice == null)
                {
                    int _id = 184575;
                    _bladeOfJustice = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _bladeOfJustice;
            }
        }

        private Spell _blessingOfKings;
        public Spell BlessingOfKings
        {
            get
            {
                if (_blessingOfKings == null)
                {
                    int _id = 203538;
                    _blessingOfKings = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfKings;
            }
        }

        private Spell _blessingOfMight;
        public Spell BlessingOfMight
        {
            get
            {
                if (_blessingOfMight == null)
                {
                    int _id = 203528;
                    _blessingOfMight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfMight;
            }
        }

        private Spell _blessingOfWisdom;
        public Spell BlessingOfWisdom
        {
            get
            {
                if (_blessingOfWisdom == null)
                {
                    int _id = 203539;
                    _blessingOfWisdom = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfWisdom;
            }
        }

        private Spell _consecration;
        public Spell Consecration
        {
            get
            {
                if (_consecration == null)
                {
                    int _id = 205228;
                    _consecration = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _consecration;
            }
        }

        private Spell _crusade;
        public Spell Crusade
        {
            get
            {
                if (_crusade == null)
                {
                    int _id = 231895;
                    _crusade = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.OffGlobalCooldown };
                }
                return _crusade;
            }
        }

        private Spell _divineHammer;
        public Spell DivineHammer
        {
            get
            {
                if (_divineHammer == null)
                {
                    int _id = 198034;
                    _divineHammer = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _divineHammer;
            }
        }

        private Spell _divineStorm;
        public Spell DivineStorm
        {
            get
            {
                if (_divineStorm == null)
                {
                    int _id = 53385;
                    _divineStorm = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _divineStorm;
            }
        }
        
        private Spell _executionSentence;
        public Spell ExecutionSentence
        {
            get
            {
                if (_executionSentence == null)
                {
                    int _id = 213757;
                    _executionSentence = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _executionSentence;
            }
        }

        private Spell _eyeForAnEye;
        public Spell EyeForAnEye
        {
            get
            {
                if (_eyeForAnEye == null)
                {
                    int _id = 205191;
                    _eyeForAnEye = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _eyeForAnEye;
            }
        }

        private Spell _handOfHindrance;
        public Spell HandOfHindrance
        {
            get
            {
                if (_handOfHindrance == null)
                {
                    int _id = 183218;
                    _handOfHindrance = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _handOfHindrance;
            }
        }

        private Spell _holyWrath;
        public Spell HolyWrath
        {
            get
            {
                if (_holyWrath == null)
                {
                    int _id = 210220;
                    _holyWrath = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _holyWrath;
            }
        }

        private Spell _justcarsVengeance;
        public Spell JusticarsVengeance
        {
            get
            {
                if (_justcarsVengeance == null)
                {
                    int _id = 215661;
                    _justcarsVengeance = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _justcarsVengeance;
            }
        }

        private Spell _sealOfLight;
        public Spell SealOfLight
        {
            get
            {
                if (_sealOfLight == null)
                {
                    int _id = 202273;
                    _sealOfLight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _sealOfLight;
            }
            set
            {
                _sealOfLight = value;
            }
        }

        private Spell _shieldOfVengeance;
        public Spell ShieldOfVengeance
        {
            get
            {
                if (_shieldOfVengeance == null)
                {
                    int _id = 184662;
                    _shieldOfVengeance = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.OffGlobalCooldown };
                }
                return _shieldOfVengeance;
            }
        }

        private Spell _templarsVerdict;
        public Spell TemplarsVerdict
        {
            get
            {
                if (_templarsVerdict == null)
                {
                    int _id = 85256;
                    _templarsVerdict = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _templarsVerdict;
            }
        }

        private Spell _wakeOfAshes;
        public Spell WakeOfAshes
        {
            get
            {
                if (_wakeOfAshes == null)
                {
                    int _id = 205273;
                    _wakeOfAshes = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _wakeOfAshes;
            }
        }

        private Spell _wordOfGlory;
        public Spell WordOfGlory
        {
            get
            {
                if (_wordOfGlory == null)
                {
                    int _id = 210191;
                    _wordOfGlory = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _wordOfGlory;
            }
        }

        private Spell _zeal;
        public Spell Zeal
        {
            get
            {
                if (_zeal == null)
                {
                    int _id = 217020;
                    _zeal = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _zeal;
            }
        }

        #region Honor Talents
        private Spell _blessingOfSancutary;
        public Spell BlessingOfSanctuary
        {
            get
            {
                if (_blessingOfSancutary == null)
                {
                    int _id = 210256;
                    _blessingOfSancutary = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfSancutary;
            }
        }

        private Spell _hammerOfReckoning;
        public Spell HammerOfReckoning
        {
            get
            {
                if (_hammerOfReckoning == null)
                {
                    int _id = 204939;
                    _hammerOfReckoning = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _hammerOfReckoning;
            }
        }
        #endregion

        protected override IEnumerable<Spell> Blessings()
        {
            var list = new List<Spell>();

            list.Add(BlessingOfKings);
            list.Add(BlessingOfMight);
            list.Add(BlessingOfWisdom);
            return list;
        }

        public bool Cooldowns
        {
            get
            {
                if (MyTalents.Crusade.IsActive())
                {
                    if (StyxWoW.Me.HasAura(Crusade.CRSpell.Id))
                        return true;

                    return Crusade.CRSpell.CooldownTimeLeft.TotalSeconds >= 45;
                }

                // If we currently have cooldowns active return true;
                if (StyxWoW.Me.HasAura(AvengingWrath.CRSpell.Id))
                    return true;

                return AvengingWrath.CRSpell.CooldownTimeLeft.TotalSeconds >= 45;
            }
        }
    }
}
