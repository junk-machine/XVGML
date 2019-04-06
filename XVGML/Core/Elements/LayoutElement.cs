using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XVGML.Core.Elements {
    public class LayoutElement {
        public IGraphicElement Presentation { get; set; }

        public LinkedList<LayoutElement> Children { get; private set; }

        public LayoutElement(IGraphicElement presentation) {
            Presentation = presentation;
            Children = new LinkedList<LayoutElement>();
        }
    }
}
