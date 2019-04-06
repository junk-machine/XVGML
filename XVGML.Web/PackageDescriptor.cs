using System;
using System.Collections.Generic;
using XVGML.Core.Packaging;
using XVGML.Web.Elements;
using XVGML.Web.Types;
using XVGML.Web.AttributeConverters;

namespace XVGML.Web {
    public class PackageDescriptor : IPackageDescriptor {
        private const string packageNamespace = "web";

        public IEnumerable<ElementDescriptor> GetElements() {
            var elements = new LinkedList<ElementDescriptor>();
            elements.AddLast(new ElementDescriptor(packageNamespace, "Image", typeof(Image)));
            return elements;
        }

        public IEnumerable<AttributeConverterDescriptor> GetAttributeConverters() {
            var converters = new LinkedList<AttributeConverterDescriptor>();
            converters.AddLast(new AttributeConverterDescriptor(typeof(ImageSizing), new ImageSizingConverter()));
            return converters;
        }
    }
}
