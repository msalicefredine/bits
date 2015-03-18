using UnityEngine;


public class CameraFacingBillboard : MonoBehaviour
{
	public Camera camera;

    void LateUpdate()
    {

	transform.LookAt(Camera.main.transform,transform.up);
    }
}