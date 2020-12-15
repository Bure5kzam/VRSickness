using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigRotation : MonoBehaviour
{
    public float rotationScale;
    public float eyeHeight;

    Transform rig;
    Transform cam;

    Quaternion initQuat;
    Quaternion prevCamQuat;

    // Start is called before the first frame update
    void Start()
    {
        rig = GameObject.Find("Rig").transform;
        cam = GameObject.Find("Camera").transform;

        initQuat = new Quaternion(0, 0, 0, 1);
        prevCamQuat = cam.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        var camMat = new Matrix4x4();
        camMat.SetTRS(cam.localPosition, cam.localRotation, cam.localScale); //camera�� ���� ��Ʈ����
        var camQuatDelta = cam.localRotation * Quaternion.Inverse(prevCamQuat); //1�����ӵ��� ī�޶� ȸ���� ��Ÿ�Ͼ� ��ġ
        var camQuatDeltaItp = Quaternion.SlerpUnclamped(initQuat, camQuatDelta, rotationScale); // 1�����ӵ��� ȸ���� ��Ÿ�Ͼ��� rotationScale ��ʰ�

        Debug.Log(string.Format("CamQuatDelta : {0}, CamQuatDeltaItp : {1}", camQuatDelta, camQuatDeltaItp));

        var TargetCamMat = Matrix4x4.TRS(new Vector3(camMat[0, 3], camMat[1, 3], camMat[2, 3]), camQuatDeltaItp * prevCamQuat, cam.localScale); //��ǥ���ϴ� camera ������Ʈ�� ���� ��Ʈ����
        var TargetCamMat_Rig = rig.parent.worldToLocalMatrix * rig.localToWorldMatrix * TargetCamMat; //��ǥ�� �ϴ� Rig �����̽� �󿡼� camera ��Ʈ���� (����)
        var revisedRigMatrix = TargetCamMat_Rig * camMat.inverse; // ������ Rig ������Ʈ�� ���� ��Ʈ���� (���� �ڿ� Camera ���� ��Ʈ������ ������� ����)
        revisedRigMatrix[1, 3] = eyeHeight;
        rig.localPosition = new Vector3(revisedRigMatrix[0, 3], revisedRigMatrix[1, 3], revisedRigMatrix[2, 3]);
        rig.localRotation = revisedRigMatrix.rotation;
        prevCamQuat = cam.localRotation;
        Debug.Log("������?");
    }
}
