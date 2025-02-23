using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Modifiers_System
{
    public enum StatType
    {
        Strengh,
        Intelligence,
        Speed
    }

    public class Stats
    {
        readonly BaseStats_SO defaultStats;
        public readonly StatsMediator mediator;

        public Stats(BaseStats_SO defaultStats, StatsMediator mediator)
        {
            this.defaultStats = defaultStats;
            this.mediator = mediator;
        }

        public float Strengh {
            get{
                var q = new Query(StatType.Strengh, defaultStats.Strengh);
                mediator.PerformQuery(this, q);

                return q.Value;
            }
        }

        public float Intelligence {
            get{
                var q = new Query(StatType.Intelligence, defaultStats.Intelligence);
                mediator.PerformQuery(this, q);

                return q.Value;
            }
        }
        public float Speed
        {
            get{
                var q = new Query(StatType.Speed, defaultStats.Speed);
                mediator.PerformQuery(this, q);

                return q.Value;
            }
        }
    }
}
