using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq.Expressions;
using XVGML.Core.Attributes;

namespace XVGML.Core.Elements {
    using PropertyAssignerDelegate = Action<IGraphicElement, string>;

    class GraphicElementsFactory {
        private Dictionary<Type, IConstructor> constructorsCache;
        private Dictionary<Type, Dictionary<string, ComplexPropertyAssigner>> propertyAssignersCache;

        private ElementsResolver elementsResolver;
        private AttributeConvertersResolver attributeConvertersResolver;

        public GraphicElementsFactory(ElementsResolver elementsResolver, AttributeConvertersResolver attributeConvertersResolver) {
            constructorsCache = new Dictionary<Type, IConstructor>();
            propertyAssignersCache = new Dictionary<Type, Dictionary<string, ComplexPropertyAssigner>>();
            this.elementsResolver = elementsResolver;
            this.attributeConvertersResolver = attributeConvertersResolver;
        }

        public IGraphicElement Produce(XElement xElement) {
            var elementType = elementsResolver.Resolve(xElement.Name);

            if (!constructorsCache.ContainsKey(elementType)) {
                constructorsCache.Add(elementType, GetConstructor(elementType));
            }

            var newElement = constructorsCache[elementType].New();

            foreach (var attribute in xElement.Attributes()) {
                if (attribute.IsNamespaceDeclaration) continue;
                AssignProperty(newElement, attribute.Name.LocalName, attribute.Value);
            }

            return newElement;
        }
        
        #region Object Constructing

        private interface IConstructor {
            IGraphicElement New();
        }

        private class Constructor<T> : IConstructor where T: IGraphicElement, new() {
            public IGraphicElement New() {
                return new T();
            }
        }

        private IConstructor GetConstructor(Type type) {
            return (IConstructor)typeof(Constructor<>).MakeGenericType(type).GetConstructor(new Type[0]).Invoke(new object[0]);
        }

        #endregion Object Constructing

        #region Property Assignment

        public void AssignProperty(IGraphicElement element, string complexPropertyName, string value) {
            var elementType = element.GetType();
            if (!propertyAssignersCache.ContainsKey(elementType)) {
                propertyAssignersCache.Add(elementType, new Dictionary<string, ComplexPropertyAssigner>());
            }
            if (!propertyAssignersCache[elementType].ContainsKey(complexPropertyName)) {
                propertyAssignersCache[elementType].Add(complexPropertyName, GetPropertyAssigner(elementType, complexPropertyName));
            }

            var assigner = propertyAssignersCache[elementType][complexPropertyName];
            if (assigner != null) {
                assigner.Assign(element, value);
            }
        }

        private ComplexPropertyAssigner GetPropertyAssigner(Type elementType, string complexPropertyName) {
            var elementParameter = Expression.Parameter(typeof(IGraphicElement), "element");
            var valueParameter = Expression.Parameter(typeof(string), "value");

            var properties = complexPropertyName.Split('-');
            var currentType = elementType;
            Expression currentObject = elementParameter;
            var assigner = new ComplexPropertyAssigner();
            for (int index = 0; index < properties.Length; ++index) {
                var property = currentType.GetProperty(properties[index]);
                if (property == null) { return null; }

                var valueGet = Expression.Call(
                        Expression.Convert(currentObject, currentType),
                        property.GetGetMethod()
                    );

                Delegate currentPropertyAssigner;
                if (index == properties.Length - 1) {
                    // New value through input text conversion
                    var convertMethod = typeof(IAttributeConverter).GetMethod("Convert", new[] { typeof(String) });
                    var newValueExpression = Expression.Call(
                                            Expression.Constant(attributeConvertersResolver.Resolve(property.PropertyType)),
                                            convertMethod,
                                            valueParameter
                                        );
                    currentPropertyAssigner = Expression.Lambda<PropertyAssignerDelegate>(
                        Expression.Call(Expression.Convert(currentObject, currentType),
                                            property.GetSetMethod(),
                                            property.PropertyType.IsByRef
                                                ? (Expression)Expression.Coalesce(valueGet, newValueExpression)
                                                : Expression.Convert(newValueExpression, property.PropertyType)
                                        ), elementParameter, valueParameter).Compile();
                } else {
                    // New value by creating new empty object
                    var newValueExpression = Expression.New(property.PropertyType);
                    currentPropertyAssigner = Expression.Lambda<Action<IGraphicElement>>(
                        Expression.Call(Expression.Convert(currentObject, currentType),
                                            property.GetSetMethod(),
                                            property.PropertyType.IsValueType
                                                ? Expression.Convert(newValueExpression, property.PropertyType)
                                                : (Expression)Expression.Coalesce(valueGet, newValueExpression)
                                        ), elementParameter).Compile();
                }
                
                assigner.Add(currentPropertyAssigner);
                currentObject = valueGet;
                currentType = property.PropertyType;
            }

            return assigner;
        }

        class ComplexPropertyAssigner {
            private LinkedList<Delegate> assigners { get; set; }

            public ComplexPropertyAssigner() {
                assigners = new LinkedList<Delegate>();
            }

            public void Add(Delegate method) {
                assigners.AddLast(method);
            }

            public void Assign(IGraphicElement element, string value) {
                foreach (var assigner in assigners) {
                    if (assigner is PropertyAssignerDelegate) {
                        (assigner as PropertyAssignerDelegate)(element, value);
                        return;
                    }
                    ((Action<IGraphicElement>)assigner)(element);
                }
            }
        }

        #endregion Property Assignment
    }
}
