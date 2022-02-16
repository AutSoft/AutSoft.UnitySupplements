﻿using AutSoft.UnitySupplements.EventBus;
using System;

namespace AutSoft.UnitySupplements.Timeline
{
    public sealed class TimeRangeChanged : IEvent
    {
        public TimeRangeChanged(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; }
        public DateTimeOffset End { get; }
    }
}
