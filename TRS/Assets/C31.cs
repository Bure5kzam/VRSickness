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
    }

    // Update is called once per frame
    void Update()
    {

        p = GameObject.Find("P31").transform;
        c = GameObject.Find("C31").transform;
        Matrix4x4 revisedCamMat = new Matrix4x4();
        Matrix4x4 CamMatrix_World = new Matrix4x4();
        Quaternion rotC31Quat = Quaternion.Euler(1f, 0, 0);
        Matrix4x4 rotMat_C31 = new Matrix4x4();
        Matrix4x4 rotMat_P31 = new Matrix4x4();

        CamMatrix_World.SetTRS(c.position, c.rotation, c.lossyScale); // C31의 월드 매트릭스
        rotMat_C31.SetTRS(Vector3.zero, rotC31Quat, Vector3.one); 
            //Rotation Matrix for make child object's rotation offseted 
            //자식 오브젝트의 회전을 상쇄시키기 위한 회전행렬
        rotMat_P31.SetTRS(Vector3.zero, Quaternion.Inverse(rotC31Quat), Vector3.one); 
            //Rotation Matrix for make parent object rotated
            //부모 오브젝트를 회전시키기 위한 회전 행렬
        revisedCamMat = c.parent.localToWorldMatrix * rotMat_P31 * c.parent.worldToLocalMatrix * CamMatrix_World * rotMat_C31;

        c.position = new Vector3(revisedCamMat[0, 3], revisedCamMat[1, 3], revisedCamMat[2, 3]);
        c.rotation = revisedCamMat.rotation;
    }
}
