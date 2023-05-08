using Objects;
using UnityEngine;

namespace Movers
{
    public class Move : MonoBehaviour
    {
        public Transform start;
        public Transform end;
        private Line line;

        void Update()
        {
            this.transform.position = HolisticMath.Lerp(new Coords(start.position), new Coords(end.position), Time.time).ToVector3();
        }
    }
}