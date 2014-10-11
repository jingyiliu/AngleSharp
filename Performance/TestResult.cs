﻿namespace Performance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TestResult
    {
        public TestResult(ITest test, IHtmlParser parser)
        {
            Test = test;
            Parser = parser;
            Durations = new List<TimeSpan>();
        }

        public List<TimeSpan> Durations
        {
            get;
            private set;
        }

        public TimeSpan Shortest
        {
            get { return Durations.Min(); }
        }

        public TimeSpan Longest
        {
            get { return Durations.Max(); }
        }

        public TimeSpan Average
        {
            get { return TimeSpan.FromMilliseconds(Durations.Average(m => m.TotalMilliseconds)); }
        }

        public TimeSpan Deviation
        {
            get
            {
                var avg = Durations.Average(m => m.TotalMilliseconds);
                var sqr = Durations.Average(m => m.TotalMilliseconds * m.TotalMilliseconds);
                var dev = Math.Sqrt(sqr - avg * avg);
                return TimeSpan.FromMilliseconds(dev);
            }
        }

        public ITest Test
        {
            get;
            private set;
        }

        public IHtmlParser Parser
        {
            get;
            private set;
        }
    }
}