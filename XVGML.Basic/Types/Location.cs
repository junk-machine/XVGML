using System;
using System.Drawing;

namespace XVGML.Basic.Types {
    public class Location {
        public Single Top { get; set; }
        public Single Left { get; set; }

        public Location() {
            Top = 0;
            Left = 0;
        }

        public static implicit operator PointF(Location location) {
            return new PointF(location.Left, location.Top);
        }

        public static implicit operator Location(PointF point) {
            return new Location { Top = point.Y, Left = point.X };
        }
    }
}
