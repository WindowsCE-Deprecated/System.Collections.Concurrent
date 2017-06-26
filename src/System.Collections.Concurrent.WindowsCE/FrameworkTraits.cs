using System;
using System.Threading;

namespace FrameworkTraits
{
    internal static class Volatile
    {
        public static T Read<T>(ref T location) where T : class
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            var value = location;
            Thread.MemoryBarrier();
            return value;
        }

        public static void Write<T>(ref T location, T value) where T : class
        {
            // 
            // The VM will replace this with a more efficient implementation.
            //
            Thread.MemoryBarrier();
            location = value;
        }
    }

    internal static class PlatformHelper
    {
        public static int ProcessorCount
        {
            get { return 1; }
        }
    }

    internal static class Monitor
    {
        public static void Enter(object obj, ref bool lockTaken)
        {
            if (lockTaken)
                throw new ArgumentException("Argument must be initialized to false", nameof(lockTaken));

            System.Threading.Monitor.Enter(obj);
            lockTaken = true;
        }
    }
}
