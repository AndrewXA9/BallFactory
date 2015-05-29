using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public float speed;
	public float zoomSpeed;
	private float zoom = 10;
	
	void Update () {
		this.transform.position += new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f)*Time.deltaTime*speed;
		this.transform.position += new Vector3(0f,0f,(zoom-this.transform.position.z));
		zoom += Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
		zoom = zoom/2f;
	}
	
	void OnDrawGizmos(){
		Gizmos.DrawSphere(new Vector3(this.transform.position.x,this.transform.position.y,zoom),0.25f);
	}
	
}
