using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private Line line;

    void Start()
    {
        line = new Line(new Coords(start.position), new Coords(end.position));
    }

    void Update()
    {
        this.transform.position = line.GetPointAt(Time.time).ToVector3();
    }
}