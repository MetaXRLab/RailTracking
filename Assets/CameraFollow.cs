using UnityEngine;
/// <summary>
/// 摄像机跟随类
/// 从某一个可以调节的观察角度，一直看着物体Target，同时跟随target物体移动。
/// </summary>
public class CameraFollow : MonoBehaviour
{
    //跟随的目标物体
    public Transform target;
    //跟随的平滑速度
    public float smoothSpeed = 0.125f;
    //固定的摄像机观察角度，可以调节
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}