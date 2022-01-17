﻿using System.Collections.Generic;

namespace StopWatch
{
    public interface IChronometer
    {
        string GetTime { get;  }

        List<string> Laps { get; }

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}