using System.Xml.Linq;
using XVGML.Core.Elements;
using XVGML.Core.Packaging;
using XVGML.Core.Attributes;

namespace XVGML {
    public class LayoutBuilder {
        private GraphicElementsFactory elementsFactory;
        private ElementsResolver elementsResolver;
        private AttributeConvertersResolver attributeConvertersResolver;

        public LayoutBuilder() {
            elementsResolver = new ElementsResolver();
            attributeConvertersResolver = new AttributeConvertersResolver();
            elementsFactory = new GraphicElementsFactory(elementsResolver, attributeConvertersResolver);
        }

        public void RegisterPackage(IPackageDescriptor descriptor) {
            foreach (var element in descriptor.GetElements()) {
                elementsResolver.Register(element.Namespace, element.Name, element.ActualType);
            }
            foreach (var attributeConverter in descriptor.GetAttributeConverters()) {
                attributeConvertersResolver.Register(attributeConverter.Type, attributeConverter.Converter);
            }
        }

        public LayoutElement Build(XElement xElement) {
            var result = new LayoutElement(
                    elementsFactory.Produce(xElement)
                );

            foreach (var child in xElement.Elements()) {
                result.Children.AddLast(Build(child));
            }

            return result;
        }

    }
}
