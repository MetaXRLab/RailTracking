using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackInfoPanel : MonoBehaviour
{
    public Text trainAxis;
    public Text satelliteAxis;
    public Toggle cameraToggle;

    public Transform train;
    public Transform satellite;

    public Camera mainCam;
    //public Camera topCam;
    Vector3 initPosition;
    Quaternion initQuaternion;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = mainCam.transform.position;
        initQuaternion = mainCam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        trainAxis.text = string.Format("X:{0} Y:{1} Z:{2}", System.Convert.ToInt32(train.position.x), System.Convert.ToInt32(train.position.y), System.Convert.ToInt32(train.position.z));
        satelliteAxis.text = string.Format("X:{0} Y:{1} Z:{2}", System.Convert.ToInt32(satellite.position.x), System.Convert.ToInt32(satellite.position.y), System.Convert.ToInt32(satellite.position.z));
    }

    public void OnToggleClick(bool toggle)
    {
        mainCam.GetComponent<CameraFollow>().enabled = toggle;
        if (!toggle)
        {
            mainCam.transform.position = initPosition;
            mainCam.transform.rotation = initQuaternion;
        }
    }
}
