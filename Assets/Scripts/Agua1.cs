using UnityEngine;
using System.Collections;

public class Agua1 : MonoBehaviour {
	
	public float scrollSpeed = 0.1f;
	public float dir = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float offset = Time.time * scrollSpeed;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(-offset, dir));
	
	}
}
