using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject objPrefab;
    
    void Start()
    {
        var obj = Instantiate(objPrefab, new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), objPrefab.transform.position.z), Quaternion.identity);
        Debug.Log($"Fuel location: {obj.transform.position}");
    }
    
    void Update()
    {
        
    }
}
