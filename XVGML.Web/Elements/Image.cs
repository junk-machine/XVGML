using System;
using XVGML.Core.Elements;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using XVGML.Core;
using XVGML.Web.Types;
using XVGML.Basic.Types;

namespace XVGML.Web.Elements {
    class Image : IGraphicElement {
        public Location Location { get; set; }
        public Basic.Types.Size Size { get; set; }
        public ImageSizing Sizing { get; set; }
        public String Source { get; set; }

        private System.Drawing.Image cachedImage;

        public Image() {
            Location = new Location();
            Size = new Basic.Types.Size();
            Sizing = ImageSizing.Scale;
        }

        public GraphicsPath Render(ICanvas canvas) {
            var image = DownloadImage();
            switch (Sizing) {
                case ImageSizing.Original:
                    Single minWidth = Math.Min(Size.Width, image.Width);
                    Single minHeight = Math.Min(Size.Height, image.Height);
                    canvas.DrawImage(image,
                        new RectangleF(Location.Left, Location.Top, minWidth, minHeight),
                        new RectangleF(0, 0, minWidth, minHeight));
                    break;
                case ImageSizing.Scale:
                    Single scale = Math.Min(Size.Width / image.Width, Size.Height / image.Height);
                    canvas.DrawImage(image,
                        new RectangleF(Location.Left, Location.Top, image.Width * scale, image.Height * scale),
                        new RectangleF(0, 0, image.Width, image.Height));
                    break;
                case ImageSizing.Stretch:
                    canvas.DrawImage(image,
                        new RectangleF(Location.Left, Location.Top, Size.Width, Size.Height),
                        new RectangleF(0, 0, image.Width, image.Height));
                    break;
            }
            return CalculateInnerBounds();
        }

        public SizeF RequiredSpace {
            get {
                var image = DownloadImage();
                switch (Sizing) {
                    case ImageSizing.Original:
                        return new SizeF(Math.Min(Size.Width, image.Width),
                                         Math.Min(Size.Height, image.Height));
                    case ImageSizing.Scale:
                        Single scale = Math.Min(Size.Width / image.Width, Size.Height / image.Height);
                        return new SizeF(image.Width * scale, image.Height * scale);
                    case ImageSizing.Stretch:
                        return Size;
                }
                return Size;
            }
        }

        private GraphicsPath CalculateInnerBounds() {
            return new GraphicsPath();
        }

        private System.Drawing.Image DownloadImage() {
            if (cachedImage == null) {
                using (Stream stream = WebRequest.Create(Source).GetResponse().GetResponseStream()) {
                    cachedImage = System.Drawing.Image.FromStream(stream);
                }
            }
            return cachedImage;
        }
    }
}
