using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P31 : MonoBehaviour
{
    Transform p;
    Transform c;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("P31").transform;
        c = GameObject.Find("C31").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Matrix4x4 rotMat = new Matrix4x4();
        rotMat.SetTRS(Vector3.zero, Quaternion.Euler(10, 0, 0), Vector3.one);

        Matrix4x4 revisedCam = c.parent.localToWorldMatrix* rotMat * c.parent.worldToLocalMatrix * c.localToWorldMatrix;

        c.position = new Vector3(revisedCam[0, 3], revisedCam[1, 3], revisedCam[2, 3]);
        c.rotation = revisedCam.rotation;
        */
        
        Matrix4x4 rotMat = new Matrix4x4();
        rotMat.SetTRS(Vector3.zero, Quaternion.Euler(10, 0, 0), Vector3.one);

        Quaternion.Inverse(c.rotation);

        Matrix4x4 revisedCam = c.parent.localToWorldMatrix * rotMat * c.parent.worldToLocalMatrix * c.localToWorldMatrix;

        c.position = new Vector3(revisedCam[0, 3], revisedCam[1, 3], revisedCam[2, 3]);
        c.rotation = revisedCam.rotation;
        
    }
}
