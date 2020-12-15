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
        camMat.SetTRS(cam.localPosition, cam.localRotation, cam.localScale); //camera의 로컬 메트릭스
        var camQuatDelta = cam.localRotation * Quaternion.Inverse(prevCamQuat); //1프레임동안 카메라가 회전한 코타니언 수치
        var camQuatDeltaItp = Quaternion.SlerpUnclamped(initQuat, camQuatDelta, rotationScale); // 1프레임동안 회전한 코타니언의 rotationScale 비례값

        Debug.Log(string.Format("CamQuatDelta : {0}, CamQuatDeltaItp : {1}", camQuatDelta, camQuatDeltaItp));

        var TargetCamMat = Matrix4x4.TRS(new Vector3(camMat[0, 3], camMat[1, 3], camMat[2, 3]), camQuatDeltaItp * prevCamQuat, cam.localScale); //목표로하는 camera 오브젝트의 로컬 메트릭스
        var TargetCamMat_Rig = rig.parent.worldToLocalMatrix * rig.localToWorldMatrix * TargetCamMat; //목표로 하는 Rig 스페이스 상에서 camera 메트릭스 (좌항)
        var revisedRigMatrix = TargetCamMat_Rig * camMat.inverse; // 수정된 Rig 오브젝트의 로컬 메트릭스 (좌항 뒤에 Camera 로컬 매트릭스의 역행렬을 곱셈)
        revisedRigMatrix[1, 3] = eyeHeight;
        rig.localPosition = new Vector3(revisedRigMatrix[0, 3], revisedRigMatrix[1, 3], revisedRigMatrix[2, 3]);
        rig.localRotation = revisedRigMatrix.rotation;
        prevCamQuat = cam.localRotation;
        Debug.Log("설마또?");
    }
}
