using System;
using XVGML.Core.Attributes;
using XVGML.Web.Types;

namespace XVGML.Web.AttributeConverters {
    class ImageSizingConverter : IAttributeConverter {
        public object Convert(string value) {
            try {
                return Enum.Parse(typeof(ImageSizing), value, true);
            } catch {
                return default(ImageSizing);
            }
        }
    }
}
