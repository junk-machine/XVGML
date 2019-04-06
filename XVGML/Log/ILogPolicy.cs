using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XVGML.Log {
    public interface ILogPolicy {
        void LogException(Exception ex);
        void LogWarning(String message);
    }
}
