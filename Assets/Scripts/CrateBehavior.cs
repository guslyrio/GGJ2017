using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour {

	public GameObject island;
	public GameObject splash;
	public uint minLifetime = 5;
	public uint maxLifetime = 10;
	private float lifetime;
	private Vector3 originalPos  = new Vector3(14.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		transform.position = originalPos;
		transform.RotateAround(island.transform.position, Vector3.up, Random.value * 359);
		lifetime = Random.Range(minLifetime, maxLifetime);
		splash.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (lifetime < 0) {
			Start();
		}
		if ((transform.position - island.transform.position).magnitude > 7) {
			//Attrack crate to island.
			transform.position = Vector3.MoveTowards(transform.position, island.transform.position, Time.deltaTime);			
		}
		
		lifetime -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject == island) {
			splash.SetActive(false);
		}
	}

	public void Respaw() {
		transform.position = originalPos;
	}
}
