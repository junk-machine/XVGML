using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XVGML.Core.Elements {
    class ElementsResolver {
        private Dictionary<string, Dictionary<string, Type>> cache;

        public ElementsResolver() {
            cache = new Dictionary<string, Dictionary<string, Type>>();
        }

        public void Register(string namespaceName, string elementName, Type actualType) {
            if (!cache.ContainsKey(namespaceName)) {
                cache.Add(namespaceName, new Dictionary<string,Type>());
            }
            cache[namespaceName][elementName] = actualType;
        }

        public Type Resolve(XName xName) {
            if (!cache.ContainsKey(xName.NamespaceName)) {
                throw new InvalidOperationException("Unknown namespace \"" + xName.NamespaceName + "\".");
            }
            if (!cache[xName.NamespaceName].ContainsKey(xName.LocalName)) {
                throw new InvalidOperationException("Unknown element \"" + xName.LocalName + "\".");
            }
            return cache[xName.NamespaceName][xName.LocalName];
        }
    }
}
