using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {

    public int itemCount = 0;
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

        // verifica se o personagem ja capturou todos os objetos necessarios pra escapar da ilha
        // 5 foi apenas um palpite!
        if( itemCount == 5 )
        {
            // Zerou o jogo! Mostrar tela de fim-do-jogo
            itemCount = 0;
        }
	}

    // Metodo que exibe na tela quantas caixas o nosso personagem ja pegou na ilha
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 150, 50), "Items grabbed:  " + itemCount);
    }

    void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Crate") {
			crate.Respaw();
			animator.SetFloat("Walk",0);

            //Toda vez que personagem colide com caixa, incrementa contador.
            itemCount++;
		}
	}
}
