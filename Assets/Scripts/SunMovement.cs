using UnityEngine;
using System.Collections;

public class SunMovement : MonoBehaviour {

	public GameObject sun;
	private int pastseconds;

// Use this for initialization
	void Start () {
		//put sun on start position
		sun.transform.Rotate(Vector3.right, System.DateTime.Now.Hour * 3600 * Time.deltaTime);
		pastseconds = System.DateTime.Now.Second;
	}
	
	// Update is called once per frame
	void Update () {
		if (System.DateTime.Now.Second - pastseconds > 0) {
			sun.transform.Rotate(Vector3.right, Time.deltaTime);
			pastseconds = System.DateTime.Now.Second;
		}
	}
}
