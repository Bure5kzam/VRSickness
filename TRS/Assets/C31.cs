using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C31 : MonoBehaviour
{
    Transform p;
    Transform c;
    // Start is called before the first frame update
    void Start()
    {
        /*
        p = GameObject.Find("P31").transform;
        c = GameObject.Find("C31").transform;
        Matrix4x4 m = c.parent.parent.worldToLocalMatrix * c.localToWorldMatrix;
        var revisedCPos = new Vector3(m[0, 3], m[1, 3], m[2, 3]);
        var revisedCRot = m.rotation * Quaternion.EulerAngles(90, 0, 0);
        m.SetTRS(revisedCPos, revisedCRot, Vector3.one);
        //m =  .parent.worldToLocalMatrix * m;
        //m = c.parent.parent.localToWorldMatrix* c.parent.worldToLocalMatrix* m;

        transform.parent.position = new Vector3(m[0, 3], m[1, 3], m[2, 3]);
        transform.parent.rotation = m.rotation;
        */

        

    }

    // Update is called once per frame
    void Update()
    {
        /*
        p = GameObject.Find("P31").transform;
        c = GameObject.Find("C31").transform;

        var rotaionMatrix = new Matrix4x4();
        rotaionMatrix.SetTRS(Vector3.zero, Quaternion.Euler(10, 0, 0), Vector3.one);
        
        var m = new Matrix4x4();
        m = rotaionMatrix * c.localToWorldMatrix;

        c.position = new Vector3(m[0, 3], m[1, 3], m[2, 3]);
        c.rotation = m.rotation;
        */
        /*
        p = GameObject.Find("P31").transform;
        c = GameObject.Find("C31").transform;

        Matrix4x4 m = c.parent.worldToLocalMatrix * c.localToWorldMatrix;
        Matrix4x4 rotMat = new Matrix4x4();
        rotMat.SetTRS(Vector3.zero, Quaternion.Euler(10, 0, 0), Vector3.one);

        Matrix4x4 camWorld = c.parent.localToWorldMatrix * rotMat * m;
        c.position = new Vector3(camWorld[0, 3], camWorld[1, 3], camWorld[2, 3]);
        c.rotation = m.rotation;
        */
        p = GameObject.Find("P31").transform;
        c = GameObject.Find("C31").transform;
        Matrix4x4 revisedCamMat = new Matrix4x4();
        Matrix4x4 CamMatrix = new Matrix4x4();
        Quaternion rotC31Quat = Quaternion.Euler(10, 0, 0);
        Matrix4x4 rotMatrix = new Matrix4x4();
        Matrix4x4 rotP31Matrix = new Matrix4x4();

        //revisedCamMat.SetTRS(c.position, c.rotation * rotC31Quat, c.localScale);//1

        /*
        CamMatrix.SetTRS(c.position, c.rotation, c.lossyScale);
        rotMatrix.SetTRS(Vector3.zero, rotC31Quat, Vector3.one);
        revisedCamMat = CamMatrix * rotMatrix;
        */
        CamMatrix.SetTRS(c.position, c.rotation, c.lossyScale);
        rotMatrix.SetTRS(Vector3.zero, rotC31Quat, Vector3.one);
        rotP31Matrix.SetTRS(Vector3.zero, Quaternion.Inverse(rotC31Quat), Vector3.one);
        revisedCamMat = c.parent.localToWorldMatrix * rotP31Matrix * c.parent.worldToLocalMatrix * CamMatrix * rotMatrix;


        c.position = new Vector3(revisedCamMat[0, 3], revisedCamMat[1, 3], revisedCamMat[2, 3]);
        c.rotation = revisedCamMat.rotation;
    }
}
