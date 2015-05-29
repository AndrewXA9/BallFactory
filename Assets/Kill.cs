using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	
	void Update () {
		if(this.transform.position.y < -50){
			Manager.pool.Add(this.gameObject);
			this.gameObject.SetActive(false);
		}
	}
	
}
