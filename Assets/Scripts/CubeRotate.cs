using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour {

	public Vector3 rotation;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotation * speed * Time.deltaTime);
	}
}
