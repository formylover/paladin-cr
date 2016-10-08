using System.Threading.Tasks;
using Styx;
using Styx.WoWInternals;
using System.Collections.Generic;

namespace Paladin.SpellBooks.Specs
{
    public abstract class PaladinSpells<T> : ISpellBookExpanded<T>
        where T : PaladinTalents
    {
        public abstract T MyTalents { get; set; }

        private Spell _lastSpell;
        public Spell LastSpell
        {
            get
            {
                if (_lastSpell == null)
                {
                    _lastSpell = new Spell();
                }
                return _lastSpell;
            }
            set
            {
                _lastSpell = value;
            }
        }

        public Spell RestHealSpell
        {
            get { return FlashOfLight; }
        }

        private Spell _avengingWrath;
        public Spell AvengingWrath
        {
            get
            {
                if (_avengingWrath == null)
                {
                    int _id = 31884;
                    _avengingWrath = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.OffGlobalCooldown };
                }
                return _avengingWrath;
            }
        }

        private Spell _blessingOfFreedom;
        public Spell BlessingOfFreedom
        {
            get
            {
                if (_blessingOfFreedom == null)
                {
                    int _id = 1044;
                    _blessingOfFreedom = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfFreedom;
            }
        }

        private Spell _blessingOfProtection;
        public Spell BlessingOfProtection
        {
            get
            {
                if (_blessingOfProtection == null)
                {
                    int _id = 1022;
                    _blessingOfProtection = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blessingOfProtection;
            }
        }

        private Spell _blindingLight;
        public Spell BlindingLight
        {
            get
            {
                if (_blindingLight == null)
                {
                    int _id = 115750;
                    _blindingLight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _blindingLight;
            }
        }

        private Spell _cleanseToxins;
        public Spell CleanseToxins
        {
            get
            {
                if (_cleanseToxins == null)
                {
                    int _id = 213644;
                    _cleanseToxins = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _cleanseToxins;
            }
        }

        private Spell _divineShield;
        public Spell DivineShield
        {
            get
            {
                if (_divineShield == null)
                {
                    int _id = 642;
                    _divineShield = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _divineShield;
            }
        }

        private Spell _divineSteed;
        public Spell DivineSteed
        {
            get
            {
                if (_divineSteed == null)
                {
                    int _id = 190784;
                    _divineSteed = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _divineSteed;
            }
        }

        private Spell _flashOfLight;
        public Spell FlashOfLight
        {
            get
            {
                if (_flashOfLight == null)
                {
                    int _id = 19750;
                    _flashOfLight = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _flashOfLight;
            }
        }

        private Spell _hammerOfJustice;
        public Spell HammerOfJustice
        {
            get
            {
                if (_hammerOfJustice == null)
                {
                    int _id = 853;
                    _hammerOfJustice = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _hammerOfJustice;
            }
        }

        private Spell _handOfReckoning;
        public Spell HandOfReckoning
        {
            get
            {
                if (_handOfReckoning == null)
                {
                    int _id = 62124;
                    _handOfReckoning = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _handOfReckoning;
            }
        }

        private Spell _judgment;
        public Spell Judgment
        {
            get
            {
                if (_judgment == null)
                {
                    int _id = 20271;
                    _judgment = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _judgment;
            }
        }

        private Spell _layOnHands;
        public Spell LayOnHands
        {
            get
            {
                if (_layOnHands == null)
                {
                    int _id = 633;
                    _layOnHands = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _layOnHands;
            }
        }

        private Spell _rebuke;
        public Spell Rebuke
        {
            get
            {
                if (_rebuke == null)
                {
                    int _id = 96231;
                    _rebuke = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id), SpellFlags = SpellFlags.Facing };
                }
                return _rebuke;
            }
        }

        private Spell _redemption;
        public Spell Redemption
        {
            get
            {
                if (_redemption == null)
                {
                    int _id = 7328;
                    _redemption = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _redemption;
            }
        }

        private Spell _repentance;
        public Spell Repentance
        {
            get
            {
                if (_repentance == null)
                {
                    int _id = 20066;
                    _repentance = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _repentance;
            }
        }

        #region Racials
        private Spell _warStomp;
        public Spell WarStomp
        {
            get
            {
                if (_warStomp == null)
                {
                    int _id = 20549;
                    _warStomp = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _warStomp;
            }
        }

        private Spell _everyManForHimself;
        public Spell EveryManForHimself
        {
            get
            {
                if (_everyManForHimself == null)
                {
                    int _id = 59752;
                    _everyManForHimself = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _everyManForHimself;
            }
        }

        private Spell _stoneform;
        public Spell Stoneform
        {
            get
            {
                if (_stoneform == null)
                {
                    int _id = 20594;
                    _stoneform = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _stoneform;
            }
        }

        private Spell _giftOfTheNaaru;
        public Spell GiftOfTheNaaru
        {
            get
            {
                if (_giftOfTheNaaru == null)
                {
                    int _id = 28880;
                    _giftOfTheNaaru = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _giftOfTheNaaru;
            }
        }

        private Spell _arcaneTorrent;
        public Spell ArcaneTorrent
        {
            get
            {
                if (_arcaneTorrent == null)
                {
                    int _id = 155145;
                    _arcaneTorrent = new Spell() { ID = _id, CRSpell = WoWSpell.FromId(_id) };
                }
                return _arcaneTorrent;
            }
        }
        #endregion

        protected abstract IEnumerable<Spell> Blessings();
    }
}
