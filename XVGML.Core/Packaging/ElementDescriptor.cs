using System;

namespace XVGML.Core.Packaging {
    public class ElementDescriptor {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public Type ActualType { get; set; }

        public ElementDescriptor() { }
        public ElementDescriptor(string namespaceName, string elementName, Type actualType) {
            Namespace = namespaceName;
            Name = elementName;
            ActualType = actualType;
        }
    }
}
