using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour{
	// When added to an object, draws colored rays from the
	// transform position.
	public int lineCount = 100;
	public float radius = 3.0f;
	
	private Vector3 initLocation = Vector3.zero;
	private Vector3 currLocation = Vector3.zero;
	
	
	static Material lineMaterial;
	
	static void CreateLineMaterial(){
		if (!lineMaterial){
			// Unity has a built-in shader that is useful for drawing
			// simple colored things.
			Shader shader = Shader.Find ("Unlit/Texture");
			lineMaterial = new Material (shader);
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			// Turn on alpha blending
			lineMaterial.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			lineMaterial.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			// Turn backface culling off
			lineMaterial.SetInt ("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
			// Turn off depth writes
			lineMaterial.SetInt ("_ZWrite", 0);
			lineMaterial.color = Color.black;
		}
	}
	
	public void Update(){
		if(Input.GetMouseButtonDown(0)){
			RaycastHit ray;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray)){
				initLocation = Input.mousePosition;
			}
		}
		if(Input.GetMouseButton(0) && initLocation != Vector3.zero){
			currLocation = Input.mousePosition;
		}
		if(Input.GetMouseButtonUp(0)){
			currLocation = initLocation = Vector3.zero;
		}
	}
	
	// Will be called after all regular rendering is done
	public void OnPostRender(){
		CreateLineMaterial ();
		// Apply the line material
		lineMaterial.SetPass (0);
		
		GL.PushMatrix ();
		// Set transformation matrix for drawing to
		// match our transform
		GL.MultMatrix (transform.localToWorldMatrix);
		
		if(initLocation != Vector3.zero){
			Debug.Log("init"+initLocation.ToString());
			Debug.Log("curr"+currLocation.ToString());
		}
		
		
		// Draw lines
		/*GL.Begin (GL.LINES);
		for (int i = 0; i < lineCount; ++i){
			float a = i / (float)lineCount;
			float angle = a * Mathf.PI * 2;
			// Vertex colors change from red to green
			GL.Color (new Color (a, 1-a, 0, 0.8F));
			// One vertex at transform position
			GL.Vertex3 (0, 0, 10);
			// Another vertex at edge of circle
			GL.Vertex3 (Mathf.Cos (angle) * radius, Mathf.Sin (angle) * radius, 10);
		}
		GL.End ();
		*/
		GL.PopMatrix ();
	}
}