
using Math;
using Objects;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject tank;
    public GameObject fuel;
    public Text tankPosition;
    public Text fuelPosition;
    public Text energyAmt;
    public Text angle;

    public void AddEnergy(string amt)
    {
	    if (int.TryParse(amt, out _))
        {
            energyAmt.text = amt;
        }
    }

    public void SetAngle(string amt)
    {
	    if (!float.TryParse(amt, out var n)) return;
	    
	    n *= Mathf.PI / 180.0f;
	    tank.transform.up = HolisticMath.Rotate(new Coords(tank.transform.up), n, false).ToVector3();
    }


    // Use this for initialization
	void Start () {
        tankPosition.text = tank.transform.position + "";
        fuelPosition.text = fuel.GetComponent<CreateObjects>().objPosition + "";
	}
}
