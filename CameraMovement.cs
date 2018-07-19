using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private Vector3 targetPos;
	private GameObject target;
	public float moveSpeed=5.0f;
	public float distY=5, distZ=10;

	void Awake(){
		target=GameObject.FindGameObjectWithTag("Player");
	}

	void Start () {
		
	}

	void LateUpdate () {
		targetPos = new Vector3(target.transform.position.x, target.transform.position.y + distY, target.transform.position.z - distZ);
		transform.position=Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}
