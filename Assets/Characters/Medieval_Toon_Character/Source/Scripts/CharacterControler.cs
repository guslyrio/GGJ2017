using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {

	public GameObject target;
	public CrateBehavior crate;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//If space key was pressed, not walking already and got a target.
		if (Input.GetKeyDown("space") && 
		   (animator.GetFloat("Walk") < 1) && 
			(target != null))
		{
			animator.SetFloat("Walk",1);
		}
		//If walking, move
		if (animator.GetFloat("Walk") > 0)
		{
			transform.LookAt(crate.transform.position);
			transform.position = Vector3.MoveTowards(transform.position, crate.transform.position, Time.deltaTime);					
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Crate") {
			crate.Respaw();
			animator.SetFloat("Walk",0);
		}
	}
}
