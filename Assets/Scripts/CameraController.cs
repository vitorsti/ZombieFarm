using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX;
    public float sensitivityY;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    public static CameraController instance;
    void Awake()
    {
        instance = this;

        SetSensitivity();
    }
    public void SetSensitivity()
    {
        sensitivityX = 0.0f;
        sensitivityY = 0.0f;

        sensitivityX = PlayerPrefs.GetFloat("Sensitivity", 15f);
        sensitivityY = PlayerPrefs.GetFloat("Sensitivity", 15f);
    }
    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseXAndY:
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                //float rotationX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                break;

            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                break;

            case RotationAxes.MouseY:
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
                break;
        }

        /*if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}*/

        // sensitivityX = PlayerPrefs.GetFloat("Sensitivity");
        // sensitivityY = PlayerPrefs.GetFloat("Sensitivity");
    }


}
