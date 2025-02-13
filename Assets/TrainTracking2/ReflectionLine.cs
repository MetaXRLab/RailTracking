﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionLine : MonoBehaviour
{
    public Transform lineStart;
    public Transform lineMid;
    public Transform lineEnd;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 3;

    public Plane reflectPlane;
    public Vector3 symmetryPoint;
    public Vector3 reflectPoint;

    // Start is called before the first frame update
    void Start()
    {
        reflectPlane = new Plane(Vector3.forward, new Vector3(12, 33, 40));

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var t = Time.time;
        //for (int i = 0; i < lengthOfLineRenderer; i++)
        //{
        //    lineRenderer.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
        //}

      

        symmetryPoint = Unitls.GetSymmetryPointByPlane(lineEnd.position, reflectPlane);

        reflectPoint = Unitls.GetIntersectWithLineAndPlane(lineStart.position, symmetryPoint - lineStart.position, Vector3.forward, new Vector3(12, 33, 40));

        lineMid.position = reflectPoint;

        lineRenderer.SetPosition(0, lineStart.position);
        lineRenderer.SetPosition(1, lineMid.position);
        lineRenderer.SetPosition(2, lineEnd.position);

    }
}
