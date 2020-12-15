using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P61 : MonoBehaviour
{
    private Transform p1;
    private Transform p2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("P61").transform;
        p2 = GameObject.Find("P62").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotP2Quat = Quaternion.Euler(0.2f, 0, 0);
        p2.rotation = p2.rotation * rotP2Quat;

        
    }
}
