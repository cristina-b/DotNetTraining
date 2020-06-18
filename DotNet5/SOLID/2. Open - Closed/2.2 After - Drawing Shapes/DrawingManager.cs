namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;
    using System.Collections.Generic;

    public class DrawingManager : DrawManager
    {
        private List<IShape> shapeList;        

        public override void DrawShapes()
        {
            foreach (IShape shape in shapeList)
                shape.Draw();
        }
    }
}
