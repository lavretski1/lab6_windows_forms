using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_6
{
    public enum DraggableElementTypes 
    {
        Matrix,
        AddOperator,
        MultiplyOperator,
        TraceOperator
    }
    public class SerializableElement
    {
        public DraggableElementTypes ElementType { get; set; }
        public List<List<float>>? Matrix { get; set; }
    }
    public class DraggableLabel: Label
    {
        public Matrix? Matrix { get; set; }
        public DraggableElementTypes ElementType { get; set; }
    }
}
