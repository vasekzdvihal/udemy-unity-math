using Math;
using UnityEngine;

namespace Illustrators
{
    public class DrawGraph : MonoBehaviour
    {
        public int size = 20;
        public int xMax = 200;
        public int yMax = 200;

        private Coords _startPointXAxis;
        private  Coords _endPointXAxis;
        private  Coords _startPointYAxis;
        private  Coords _endPointYAxis;
    
        void Start()
        {
            // Init
            this._startPointXAxis = new Coords(xMax, 0);
            this._endPointXAxis = new Coords(-xMax, 0);
            this._startPointYAxis = new Coords(0, yMax);
            this._endPointYAxis = new Coords(0, -yMax);
        
            Coords.DrawPoint(new Coords(0, 0), 2, Color.grey); // Origin
            Coords.DrawLine(_startPointYAxis, _endPointYAxis, 1, Color.green); // Y axis
            Coords.DrawLine(_startPointXAxis, _endPointXAxis, 1, Color.red); // X axis

            var xOffset = (int)(xMax / (float)size); // number of gaps on the x axis
            for (var x = -xOffset * size; x <= xMax; x+= size)
            {
                Coords.DrawLine(new Coords(x, -yMax), new Coords(x, yMax), .5f, Color.white);
            }

            var yOffset = (int)(yMax / (float)size); // number of gaps on the y axis
            for (var y = -yOffset * size; y <= yMax; y+= size)
            {
                Coords.DrawLine(new Coords(-xMax, y), new Coords(xMax, y), .5f, Color.white);
            }
        }
    }
}
