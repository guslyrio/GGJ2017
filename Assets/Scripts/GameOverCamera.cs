using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCamera : MonoBehaviour {
	public Texture screenTexture;

	// Use this for initialization
	void Start () {
	}

	void OnGUI () {
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), screenTexture);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
			SceneManager.LoadScene("StartScene");
	}
}
