using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5 : MonoBehaviour
{
    private GameObject p;
    private GameObject c;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Rig");
        c = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //Matrix4x4 Revised
    }
}
