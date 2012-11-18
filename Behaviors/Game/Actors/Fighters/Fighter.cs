﻿#region License GNU GPL
// Fighter.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using System;
using BiM.Behaviors.Game.Actors.Interfaces;
using BiM.Behaviors.Game.Fights;
using BiM.Behaviors.Game.Stats;
using BiM.Behaviors.Game.World;
using BiM.Protocol.Data;
using BiM.Protocol.Enums;
using BiM.Protocol.Types;

namespace BiM.Behaviors.Game.Actors.Fighters
{
    public abstract class Fighter : ContextActor, INamed
    {
        protected Fighter()
        {
            CastsHistory = new SpellCastHistory(this);
        }

        public delegate void TurnHandler(Fighter fighter);
        public event TurnHandler TurnStarted;

        internal void NotifyTurnStarted()
        {
            TurnHandler handler = TurnStarted;
            if (handler != null) handler( this);
        }

        public event TurnHandler TurnEnded;

        internal void NotifyTurnEnded()
        {
            if (IsMoving())
                NotifyStopMoving(false);

            TurnHandler handler = TurnEnded;
            if (handler != null) handler(this);
        }

        public delegate void SpellCastHandler(Fighter fighter, SpellCast cast);
        public event SpellCastHandler SpellCasted;

        internal void NotifySpellCasted(SpellCast cast)
        {
            CastsHistory.AddSpellCast(cast);

            SpellCastHandler handler = SpellCasted;
            if (handler != null) handler(this, cast);
        }

        private bool m_isReady;

        public Fight Fight
        {
            get;
            protected set;
        }

        public FightTeam Team
        {
            get;
            protected set;
        }

        public virtual bool IsAlive
        {
            get;
            set;
        }

        public bool IsReady
        {
            get { return m_isReady; }
            set
            {
                m_isReady = value;
                Action<Fighter, bool> evnt = ReadyStateChanged;

                if (evnt != null)
                    evnt(this, value);
            }
        }

        public virtual string Name
        {
            get;
            protected set;
        }

        public virtual int Level
        {
            get;
            protected set;
        }

        public virtual IMinimalStats Stats
        {
            get;
            protected set;
        }

        public SpellCastHistory CastsHistory
        {
            get;
            protected set;
        }

        public override Map Map
        {
            get
            {
                return Fight.Map;
            }
            protected set
            {
            }
        }

        public override IContext Context
        {
            get { return Fight; }
            protected set
            {
            }
        }

        /// <summary>
        /// Returns true whenever it's fighter's turn
        /// </summary>
        /// <returns></returns>
        public virtual bool IsPlaying()
        {
            return this == Fight.TimeLine.CurrentPlayer;
        }

        /// <summary>
        /// Returns true whenever the fighter is able to play (i.g not dead)
        /// </summary>
        /// <returns></returns>
        public virtual bool CanPlay()
        {
            return IsAlive;
        }

        public int GetRealSpellRange(SpellLevel spell)
        {
            var range =  (int) (spell.rangeCanBeBoosted ? Stats.Range + spell.range : spell.range);

            if (range < spell.minRange)
                return (int) spell.minRange;

            return range;
        }

        public bool IsInSpellRange(Cell cell, SpellLevel spell)
        {
            var range = GetRealSpellRange(spell);
            var dist = Cell.ManhattanDistanceTo(cell);

            if (!(dist >= spell.minRange && dist <= range)) return false;
            return IsInLineIfNeeded(cell, spell);
        }

        private bool IsInLineIfNeeded(Cell cell, SpellLevel spell)
        {
            if (!spell.castInLine) return true;
            return Cell.X == cell.X || Cell.Y == cell.Y;
        }

        
        public FightTeam GetOpposedTeam()
        {
            return Fight.GetTeam(Team.Id == FightTeamColor.Blue ? FightTeamColor.Red : FightTeamColor.Blue);
        }

        public event Action<Fighter, bool> ReadyStateChanged;

        public virtual void Update(GameFightFighterInformations informations)
        {
            IsAlive = informations.alive;

            Stats.Update(informations.stats);

            Update(informations.disposition);
        }

        public override string ToString()
        {
            return String.Format("{0} (lv {1} {2})", Name, Level, Team.TeamType == TeamTypeEnum.TEAM_TYPE_PLAYER ? "friend" : "foe");
        }
    }
}