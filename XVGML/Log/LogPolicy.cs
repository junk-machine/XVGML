using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XVGML.Log {
    public static class LogPolicy {
        private static ILogPolicy current;

        static LogPolicy() {
            current = new QuietLogPolicy();
        }

        public static void SetLogPolicy(ILogPolicy policy) {
            current = policy;
        }

        internal static void LogException(Exception ex) {
            current.LogException(ex);
        }

        internal static void LogWarning(String message) {
            current.LogWarning(message);
        }

        class QuietLogPolicy : ILogPolicy {
            public void LogException(Exception ex) { }
            public void LogWarning(String message) { }
        }
    }
}
