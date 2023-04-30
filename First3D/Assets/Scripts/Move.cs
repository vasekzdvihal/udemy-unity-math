using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private Line line;

    void Start()
    {
        //line = new Line(new Coords(start.position), new Coords(end.position), Line.LineTypeEnum.Segment);
    }

    void Update()
    {
        this.transform.position = HolisticMath.Lerp(new Coords(start.position), new Coords(end.position), Time.time).ToVector3();
    }
}