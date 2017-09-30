using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour {

	float minFov = 15f;
	float maxFov = 90f;
	private Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
	}

	public void ZoomIn(){
		float fov =cam.fieldOfView;
		fov -= 10;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		cam.fieldOfView = fov;
	}

	public void ZoomOut(){
		float fov =cam.fieldOfView;
		fov += 10;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		cam.fieldOfView = fov;
	}
}
