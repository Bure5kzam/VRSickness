using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c2P21 : MonoBehaviour
{

    Transform p21;
    Transform p22;
    Transform c21;

    // Start is called before the first frame update
    void Start()
    {
        p21 = GameObject.Find("P21").transform;
        p22 = GameObject.Find("P22").transform;
        c21 = GameObject.Find("C21").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        var C21Mat = c21.transform.parent.parent.worldToLocalMatrix * c21.transform.localToWorldMatrix;
        transform.position = new Vector3(C21Mat[0, 3], C21Mat[1, 3], C21Mat[2, 3]);
        transform.rotation = C21Mat.rotation;
        */

        var P22Mat = c21.transform.parent.parent.worldToLocalMatrix * c21.transform.parent.localToWorldMatrix;
        transform.position = new Vector3(P22Mat[0, 3], P22Mat[1, 3], P22Mat[2, 3]);
        transform.rotation = P22Mat.rotation;

    }
}
