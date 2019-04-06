using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;
using XVGML;
using System.Drawing.Imaging;
using XVGML.Core.Elements;

namespace Test {
    class Program {
        private LayoutBuilder builder;
        private LayoutBuilder Builder {
            get {
                if (builder == null) {
                    builder = new LayoutBuilder();
                    builder.RegisterPackage(new XVGML.Basic.PackageDescriptor());
                    builder.RegisterPackage(new XVGML.Web.PackageDescriptor());
                }
                return builder;
            }
        }

        private LayoutRenderer renderer;
        private LayoutRenderer Renderer {
            get {
                if (renderer == null)
                    renderer = new LayoutRenderer();
                return renderer;
            }
        }

        public Program() { }

        private Program(string filePath) {
            var root = XElement.Load(filePath);
            var image = Renderer.Render(Builder.Build(root));
            image.Save(filePath + ".png", ImageFormat.Png);
        }

        static void Main(string[] args) {
            new Program(@"SourceImages\BasicTest.xml");
            new Program(@"SourceImages\Demotivator.xml");
        }
    }
}
