using System;
using System.Drawing;

namespace XVGML.Basic.Types {
    public class Size {
        public Single Width { get; set; }
        public Single Height { get; set; }

        public Size() {
            Width = 0;
            Height = 0;
        }

        public static implicit operator SizeF(Size size) {
            return new SizeF(size.Width, size.Height);
        }

        public static implicit operator Size(SizeF size) {
            return new Size { Width = size.Width, Height = size.Height };
        }
    }
}
