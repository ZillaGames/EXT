using System;

namespace TimeSpanEXT
{
    public static class TimeSpanExtension
    {
        public static float SecondsF(this TimeSpan timeSpan)
            => timeSpan.Milliseconds / 1000f;
    }
}
