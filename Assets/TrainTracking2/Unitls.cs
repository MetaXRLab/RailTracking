using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Unitls
{
    /// <summary>
    /// 计算直线与平面的交点
    /// </summary>
    /// <param name="point">直线上某一点</param>
    /// <param name="direct">直线的方向</param>
    /// <param name="planeNormal">垂直于平面的的向量</param>
    /// <param name="planePoint">平面上的任意一点</param>
    /// <returns></returns>
    public static Vector3 GetIntersectWithLineAndPlane(Vector3 point, Vector3 direct, Vector3 planeNormal, Vector3 planePoint)
    {
        float d = Vector3.Dot(planePoint - point, planeNormal) / Vector3.Dot(direct.normalized, planeNormal);

        return d * direct.normalized + point;

    }

    /// <summary>
    /// 获取一个点关于一个面的镜面对称点。
    /// </summary>
    /// <param name="point"></param>
    /// <param name="plane"></param>
    /// <returns></returns>
    public static Vector3 GetSymmetryPointByPlane(Vector3 point, Plane plane)
    {
        Vector3 symmetryPoint;
        float symmetryDistance = plane.GetSide(point) ? -plane.GetDistanceToPoint(point) : plane.GetDistanceToPoint(point);
        symmetryPoint = new Vector3(point.x, point.y, -symmetryDistance);
        return symmetryPoint;
    }

}
