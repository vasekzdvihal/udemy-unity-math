using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
  // Start is called before the first frame update
    void Start()
    {
      // DrawGeminiStarSign();
    }
    
    void DrawGeminiStarSign()
    {
       var pollux = new Coords(2, 18);
       var castor = new Coords(5, 28);
       var alhena = new Coords(23, 8);
       
       var alzirr = new Coords(22, 3);
       var mebsuta = new Coords(20, 17);
       var mekbuda = new Coords(16, 11);
       var wasat = new Coords(10, 12);
       var tejat = new Coords(25, 15);
       var propus = new Coords(27, 16);
       
       var kGem = new Coords(3, 14);
       var uGem = new Coords(5,16);
       var lGem = new Coords(7, 17);
       var rGem = new Coords(11, 27);
       var oGem = new Coords(16, 27);

       var aGem = new Coords(12, 5);
       var vGem = new Coords(24, 12);

       Coords.DrawPoint(pollux, 4, Color.yellow);
       Coords.DrawPoint(castor, 4, Color.yellow);
       Coords.DrawPoint(alhena, 4, Color.yellow);
       
       Coords.DrawPoint(alzirr, 3, Color.yellow);
       Coords.DrawPoint(mebsuta, 3, Color.yellow);
       Coords.DrawPoint(mekbuda, 3, Color.yellow);
       Coords.DrawPoint(wasat, 3, Color.yellow);
       Coords.DrawPoint(tejat, 3, Color.yellow);
       Coords.DrawPoint(propus, 3, Color.yellow);
       
       Coords.DrawPoint(kGem, 2, Color.yellow);
       Coords.DrawPoint(uGem, 2, Color.yellow);
       Coords.DrawPoint(lGem, 2, Color.yellow);
       Coords.DrawPoint(rGem, 2, Color.yellow);
       Coords.DrawPoint(oGem, 2, Color.yellow);
       Coords.DrawPoint(aGem, 2, Color.yellow);
       Coords.DrawPoint(vGem, 2, Color.yellow);

       // heads
       Coords.DrawLine(pollux, uGem, 1, Color.magenta); 
       Coords.DrawLine(castor, rGem, 1, Color.magenta); 
       
       // hands
       Coords.DrawLine(kGem, uGem, 1, Color.magenta); 
       Coords.DrawLine(uGem, lGem, 1, Color.magenta); 
       Coords.DrawLine(lGem, rGem, 1, Color.magenta); 
       Coords.DrawLine(rGem, oGem, 1, Color.magenta); 
       
       // bodies
       Coords.DrawLine(uGem, wasat, 1, Color.magenta);
       Coords.DrawLine(rGem, mebsuta, 1, Color.magenta); 
       
       // legs
       Coords.DrawLine(wasat, aGem, 1, Color.magenta); 
       Coords.DrawLine(aGem, alzirr, 1, Color.magenta); 
       Coords.DrawLine(wasat, mekbuda, 1, Color.magenta); 
       Coords.DrawLine(mekbuda, alhena, 1, Color.magenta);

       Coords.DrawLine(mebsuta, vGem, 1, Color.magenta); 
       Coords.DrawLine(mebsuta, tejat, 1, Color.magenta); 
       Coords.DrawLine(tejat, propus, 1, Color.magenta); 
    }
}
