using Paladin.SpellBooks.Talents;

namespace Paladin.SpellBooks.Specs.Protection
{
    public class ProtectionTalents : PaladinTalents
    {
        #region Tier 1
        private Talent _holyShield;
        public Talent HolyShield
        {
            get
            {
                if (_holyShield == null)
                {
                    _holyShield = new Talent() { Name = "Holy Shield", Row = 1, Column = 1 };
                }
                return _holyShield;
            }
            set
            {
                _holyShield = value;
            }
        }

        private Talent _blessedHammer;
        public Talent BlessedHammer
        {
            get
            {
                if (_blessedHammer == null)
                {
                    _blessedHammer = new Talent() { Name = "Blessed Hammer", Row = 1, Column = 2 };
                }
                return _blessedHammer;
            }
            set
            {
                _blessedHammer = value;
            }
        }

        private Talent _consecratedHammer;
        public Talent ConsecratedHammer
        {
            get
            {
                if (_consecratedHammer == null)
                {
                    _consecratedHammer = new Talent() { Name = "Consecrated Hammer", Row = 1, Column = 3 };
                }
                return _consecratedHammer;
            }
            set
            {
                _consecratedHammer = value;
            }
        }
        #endregion

        #region Tier 2
        private Talent _firstAvenger;
        public Talent FirstAvenger
        {
            get
            {
                if (_firstAvenger == null)
                {
                    _firstAvenger = new Talent() { Name = "First Avenger", Row = 2, Column = 1 };
                }
                return _firstAvenger;
            }
            set
            {
                _firstAvenger = value;
            }
        }

        private Talent _bastionOfLight;
        public Talent BastionOfLight
        {
            get
            {
                if (_bastionOfLight == null)
                {
                    _bastionOfLight = new Talent() { Name = "Bastion of Light", Row = 2, Column = 2 };
                }
                return _bastionOfLight;
            }
            set
            {
                _bastionOfLight = value;
            }
        }

        private Talent _crusadersJudgment;
        public Talent CrusadersJudgment
        {
            get
            {
                if (_crusadersJudgment == null)
                {
                    _crusadersJudgment = new Talent() { Name = "Crusader's Judgment", Row = 2, Column = 3 };
                }
                return _crusadersJudgment;
            }
            set
            {
                _crusadersJudgment = value;
            }
        }
        #endregion
        
        #region Tier 4
        private Talent _blessingOfSpellwarding;
        public Talent BlessingOfSpellwarding
        {
            get
            {
                if (_blessingOfSpellwarding == null)
                {
                    _blessingOfSpellwarding = new Talent() { Name = "Blessing of Spellwarding", Row = 4, Column = 1 };
                }
                return _blessingOfSpellwarding;
            }
            set
            {
                _blessingOfSpellwarding = value;
            }
        }

        private Talent _cavalier;
        public Talent Cavalier
        {
            get
            {
                if (_cavalier == null)
                {
                    _cavalier = new Talent() { Name = "Cavalier", Row = 4, Column = 1 };
                }
                return _cavalier;
            }
            set
            {
                _cavalier = value;
            }
        }

        private Talent _retributionAura;
        public Talent RetributionAura
        {
            get
            {
                if (_retributionAura == null)
                {
                    _retributionAura = new Talent() { Name = "Retribution Aura", Row = 4, Column = 3 };
                }
                return _retributionAura;
            }
            set
            {
                _retributionAura = value;
            }
        }
        #endregion

        #region Tier 5
        private Talent _handOfTheProtector;
        public Talent HandOfTheProtector
        {
            get
            {
                if (_handOfTheProtector == null)
                {
                    _handOfTheProtector = new Talent() { Name = "Hand of the Protector", Row = 5, Column = 1 };
                }
                return _handOfTheProtector;
            }
            set
            {
                _handOfTheProtector = value;
            }
        }

        private Talent _knightTemplar;
        public Talent KnightTemplar
        {
            get
            {
                if (_knightTemplar == null)
                {
                    _knightTemplar = new Talent() { Name = "Knight Templar", Row = 5, Column = 2 };
                }
                return _knightTemplar;
            }
            set
            {
                _knightTemplar = value;
            }
        }

        private Talent _finalStand;
        public Talent FinalStand
        {
            get
            {
                if (_finalStand == null)
                {
                    _finalStand = new Talent() { Name = "Final Stand", Row = 5, Column = 3 };
                }
                return _finalStand;
            }
            set
            {
                _finalStand = value;
            }
        }
        #endregion

        #region Tier 6
        private Talent _aegisOfLight;
        public Talent AegisOfLight
        {
            get
            {
                if (_aegisOfLight == null)
                {
                    _aegisOfLight = new Talent() { Name = "Aegis of Light", Row = 6, Column = 1 };
                }
                return _aegisOfLight;
            }
            set
            {
                _aegisOfLight = value;
            }
        }
        
        private Talent _judgmentOfLight;
        public Talent JudgmentOfLight
        {
            get
            {
                if (_judgmentOfLight == null)
                {
                    _judgmentOfLight = new Talent() { Name = "Judgment of Light", Row = 6, Column = 2 };
                }
                return _judgmentOfLight;
            }
            set
            {
                _judgmentOfLight = value;
            }
        }

        private Talent _consecratedGround;
        public Talent ConsecratedGround
        {
            get
            {
                if (_consecratedGround == null)
                {
                    _consecratedGround = new Talent() { Name = "Consecrated Ground", Row = 6, Column = 3 };
                }
                return _consecratedGround;
            }
            set
            {
                _consecratedGround = value;
            }
        }
        #endregion

        #region Tier 7
        private Talent _righteousProtector;
        public Talent RighteousProtector
        {
            get
            {
                if (_righteousProtector == null)
                {
                    _righteousProtector = new Talent() { Name = "Righteous Protector", Row = 7, Column = 1 };
                }
                return _righteousProtector;
            }
            set
            {
                _righteousProtector = value;
            }
        }

        private Talent _seraphim;
        public Talent Seraphim
        {
            get
            {
                if (_seraphim == null)
                {
                    _seraphim = new Talent() { Name = "Seraphim", Row = 7, Column = 2 };
                }
                return _seraphim;
            }
            set
            {
                _seraphim = value;
            }
        }

        private Talent _lastDefender;
        public Talent LastDefender
        {
            get
            {
                if (_lastDefender == null)
                {
                    _lastDefender = new Talent() { Name = "Last Defender", Row = 7, Column = 3 };
                }
                return _lastDefender;
            }
            set
            {
                _lastDefender = value;
            }
        }
        #endregion
    }
}
