using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P41 : MonoBehaviour
{
    private Transform p1;
    private Transform p2;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("P41").transform;
        p2 = GameObject.Find("P42").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion revisedP2 = Quaternion.Euler(p1.rotation.eulerAngles * 2);
        p2.rotation = revisedP2;
    }
}
