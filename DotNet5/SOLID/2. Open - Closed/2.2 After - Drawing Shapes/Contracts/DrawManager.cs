using System.Collections.Generic;

namespace OpenClosedDrawingShapesAfter.Contracts
{
    public abstract class DrawManager
    {
        IEnumerable<IShape> shapes;
        public abstract void DrawShapes();
    }
}
