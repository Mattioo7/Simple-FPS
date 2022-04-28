using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	public Transform playerBody;
	float xRotation = 0f;

	PhotonView view;
	public Camera myCamera;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		view = GetComponentInParent<PhotonView>();

		//myCamera = Camera.main;
		if (view.IsMine == false)
        {
			myCamera.enabled = false;
        }

		//myCamera = GetComponentInChildren<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		if (view.IsMine)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

			
	}
}
