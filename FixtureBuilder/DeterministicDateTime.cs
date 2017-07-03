using System;

namespace FixtureBuilder
{
    public static class DeterministicDateTime
    {
        public static Func<DateTime> NowFunc = () => DateTime.Now;
        public static Func<DateTime> UtcNowFunc = () => DateTime.Now;

        public static DateTime Now { get { return NowFunc(); } }
        public static DateTime UtcNow { get { return UtcNowFunc(); } }
    }
}
