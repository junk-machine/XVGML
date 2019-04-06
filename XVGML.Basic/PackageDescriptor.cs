using System;
using System.Collections.Generic;
using System.Drawing;
using XVGML.Core.Packaging;
using XVGML.Basic.AttributeConverters;
using XVGML.Basic.Elements;
using XVGML.Basic.Types;

namespace XVGML.Basic {
    public class PackageDescriptor : IPackageDescriptor {
        private const string packageNamespace = "basic";
        private const string fillsNamespace = "fill";

        public IEnumerable<ElementDescriptor> GetElements() {
            var elements = new LinkedList<ElementDescriptor>();
            elements.AddLast(new ElementDescriptor(packageNamespace, "Canvas", typeof(Canvas)));
            elements.AddLast(new ElementDescriptor(packageNamespace, "Line", typeof(XVGML.Basic.Elements.Line)));
            elements.AddLast(new ElementDescriptor(packageNamespace, "Rectangle", typeof(XVGML.Basic.Elements.Rectangle)));
            elements.AddLast(new ElementDescriptor(packageNamespace, "Ellipse", typeof(XVGML.Basic.Elements.Ellipse)));
            elements.AddLast(new ElementDescriptor(packageNamespace, "Label", typeof(XVGML.Basic.Elements.Label)));

            elements.AddLast(new ElementDescriptor(fillsNamespace, "Solid", typeof(XVGML.Basic.Elements.Fills.Solid)));
            elements.AddLast(new ElementDescriptor(fillsNamespace, "Gradient", typeof(XVGML.Basic.Elements.Fills.Gradient)));
            return elements;
        }

        public IEnumerable<AttributeConverterDescriptor> GetAttributeConverters() {
            var converters = new LinkedList<AttributeConverterDescriptor>();
            converters.AddLast(new AttributeConverterDescriptor(typeof(Boolean), new BooleanConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Byte), new ByteConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Color), new AttributeConverters.ColorConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(DateTime), new DateTimeConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Decimal), new DecimalConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Double), new DoubleConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Int16), new Int16Converter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Int32), new Int32Converter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Int64), new Int64Converter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(SByte), new SByteConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Single), new SingleConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(String), new StringConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(UInt16), new UInt16Converter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(UInt32), new UInt32Converter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(UInt64), new UInt64Converter()));

            converters.AddLast(new AttributeConverterDescriptor(typeof(PointF), new AttributeConverters.PointConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Types.Size), new AttributeConverters.SizeConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Location), new LocationConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Font), new AttributeConverters.FontConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(Padding), new PaddingConverter()));
            converters.AddLast(new AttributeConverterDescriptor(typeof(LineStyle), new LineStyleConverter()));
            return converters;
        }
    }
}
