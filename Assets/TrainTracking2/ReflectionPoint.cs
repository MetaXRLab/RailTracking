using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionPoint : MonoBehaviour
{
    //output
    public Vector3 positionRP = Vector3.zero;

    //middle output---diagonal---a line consist of 2 point----

    Vector3 positionDefaultRP;
    Vector3 positionDiagonalP;

    //if conditions: 
    //1 the diagonal line is perpendicular to the building Plane or 
    //2 Coincidence and the normal line of the reflective point  
    //then outcome:
    //the positionRP

    Vector3 sateltrainMidP = Vector3.zero;

    public Transform lineStart;
    public Transform lineMid;
    public Transform lineEnd;

    //input
    float P = 0.0f;
    float L1 = 0.0f;
    float L2 = 0.0f;
    float L3 = 0.0f;

    float angle = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

   

    /// <summary>
    /// get innercenter of tirangle
    /// </summary>
    /// <returns></returns>
    public Vector3 CenterHeart()
    {
        L1 = Vector3.Distance(lineStart.position, lineEnd.position);
        L2 = Vector3.Distance(lineEnd.position, lineMid.position);
        L3 = Vector3.Distance(lineMid.position, lineStart.position);
        P = L1 + L2 + L3;
        sateltrainMidP = new Vector3(L1 / P, L2 / P, L3 / P); 
        return sateltrainMidP;
    }

}
