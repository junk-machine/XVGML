using System.Collections.Generic;

namespace XVGML.Core.Packaging {
    
    public interface IPackageDescriptor {
        IEnumerable<ElementDescriptor> GetElements();
        IEnumerable<AttributeConverterDescriptor> GetAttributeConverters();
    }
}
