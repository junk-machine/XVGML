using System;
using System.Collections.Generic;

namespace XVGML.Core.Attributes {
    class AttributeConvertersResolver {
        private Dictionary<Type, IAttributeConverter> cache;

        public AttributeConvertersResolver() {
            cache = new Dictionary<Type, IAttributeConverter>();
        }

        public void Register(Type propertyType, IAttributeConverter converter) {
            cache[propertyType] = converter;
        }

        public IAttributeConverter Resolve(Type type) {
            if (!cache.ContainsKey(type)) {
                throw new InvalidOperationException("Appropriate Attribute Converter was not found for type \"" + type.FullName + "\".");
            }
            return cache[type];
        }
    }
}
