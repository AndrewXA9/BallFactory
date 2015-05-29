using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	
	public static Material[] colors;
	public Color[] colorList = {Color.red,new Color(1.0f,0.5f,0.0f),Color.yellow,Color.green,Color.blue,Color.magenta};
	
	public static List<GameObject> pool;
	
	public float spawnDelay = 1f;
	private float timer = 0;
	public GameObject ball;
	
	void Awake() {
		colors = new Material[6];
		Shader s = Shader.Find("Standard");
		for(int i=0; i<colorList.Length; i++){
			colors[i] = new Material(s);
			colors[i].color = colorList[i];
			
		}
		pool = new List<GameObject>();
	}
	
	void Update () {
		if(timer < spawnDelay){
			timer+= Time.deltaTime;
		}
		else{
			timer -= spawnDelay;
			GameObject b;
			if(pool.Count > 0){
				b = pool[0];
				b.SetActive(true);
				pool.Remove(b);
			}
			else{
				b = Instantiate(ball) as GameObject;
			}
			b.GetComponent<Renderer>().material = colors[Random.Range(0,colorList.Length)];
			b.transform.position = this.transform.position;
			b.transform.rotation = Quaternion.identity;
		}
		
	}
}
