using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeManager : MonoBehaviour
{
    // TODO https://stackoverflow.com/questions/8447/what-does-the-flags-enum-attribute-mean-in-c
    public static int MAGIC = 16;
    public static int INTELLIGENCE = 8;
    public static int CHARISMA = 4;
    public static int FLY = 2;
    public static int INVISIBLE = 1;
    
    public Text attributeDisplay;
    private int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MAGIC")) attributes |= MAGIC;
        if (other.gameObject.CompareTag("INTELLIGENCE")) attributes |= INTELLIGENCE;
        if (other.gameObject.CompareTag("CHARISMA")) attributes |= CHARISMA;
        if (other.gameObject.CompareTag("FLY")) attributes |= FLY;
        if (other.gameObject.CompareTag("INVISIBLE")) attributes |= INVISIBLE; 
        if (other.gameObject.CompareTag("ANTIMAGIC")) attributes &= ~MAGIC; 
        
        if (other.gameObject.CompareTag("MULTIPLE")) attributes |= (INTELLIGENCE | MAGIC | CHARISMA); 
        if (other.gameObject.CompareTag("ANTIMULTIPLE")) attributes &= ~(INTELLIGENCE | MAGIC); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);

        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
