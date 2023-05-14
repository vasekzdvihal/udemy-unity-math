using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBits : MonoBehaviour
{
    private const int bSequence = 8 + 1 + 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Convert.ToString(bSequence, 2));
    }

    // Update is called once per frame
    void Update()
    {
        this.ShiftEx1();
        this.ShiftEx2();
    }

    public void ShiftEx1()
    {
        string A = "110111";
        string B = "10001";
        string C = "1101";
        int aBits = Convert.ToInt32(A, 2);
        int bBits = Convert.ToInt32(B, 2);
        int cBits = Convert.ToInt32(C, 2);

        int packet = 0;

        // Integer have 32 bits
        packet = packet | (aBits << 26); // 32 - 6(length of A string) = 26 
        packet = packet | (bBits << 21); // 26(result of above) - 5 = 21 
        packet = packet | (cBits << 17); // 21 - 4 = 17
        
        Debug.Log(Convert.ToString(packet, 2).PadLeft(32, '0'));
    }

    public void ShiftEx2()
    {
        string A = "1111";
        string B = "101";
        string C = "11011";
        int aBits = Convert.ToInt32(A, 2);
        int bBits = Convert.ToInt32(B, 2);
        int cBits = Convert.ToInt32(C, 2);

        int packet = 0;

        // Integer have 32 bits
        packet = packet | (aBits << 28); // 32 - 4 = 28
        packet = packet | (bBits << 25); // 28 - 3 = 25 
        packet = packet | (cBits << 20); // 25 - 5 = 20
        
        Debug.Log(Convert.ToString(packet, 2).PadLeft(32, '0'));
    }
}

// 