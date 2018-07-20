//O personagem nao se movera ate adicionar o Run no Edit/Project Setting/Input
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
	//criando as variaveis
	public float speed = 5f, jumpForce = 8f, gravity = 30f;
	private float originalSpeed;
	private Vector3 moveDir = Vector3.zero;
	private CharacterController controller;
	private Animator anim;

	void Awake(){
		originalSpeed = speed;
	}

	void Start(){
		//instanciando as variaveis
		controller = gameObject.GetComponent<CharacterController>();
		anim=GetComponent<Animator>();
		anim.SetBool("isGrounded",true);
	}

	void Update(){
		//Transform t = this.transform;
		//so realizar as açoes se estiver no chao
		if(controller.isGrounded){
			//chama animacao parado na terra
			anim.SetBool("isGrounded",true);
			anim.SetBool("Move",false);
			anim.SetBool("Running",false);
			//capturar direçao precionada no axis
			moveDir=new Vector3(Input.GetAxis ("Horizontal"),0,Input.GetAxis ("Vertical"));
			//olhar para a direçao capturada
			if(moveDir != Vector3.zero){
				transform.rotation = Quaternion.LookRotation(moveDir);
				anim.SetBool("Move",true);
			}
			//normalizar movimentos diagonais
			moveDir = Vector3.ClampMagnitude (moveDir, 1);

			if(PlayerCombat.attacking){
				speed = 0f;//aqui era 0.5f
			}
			else{
				speed = originalSpeed;
			}

			if(Input.GetAxis ("Horizontal")!=0f || Input.GetAxis ("Vertical") !=0){				
				if(Input.GetButton("Run")){
					moveDir = moveDir*(speed*1.5f);
					anim.SetBool("Running",true);
				}
				else{
				//aplicar a speed escolhida
				moveDir*=speed;			
				}
				
			}
			//pular
			if(Input.GetButtonDown ("Jump")){
				anim.SetBool("isGrounded",false);
				moveDir.y=jumpForce;
			}
		}
//		else{
//			anim.SetBool("isGrounded",false);
//		}
		//cair de acordo com a gravidade
		moveDir.y -= gravity*Time.deltaTime;
		//mover-se
		controller.Move(moveDir*Time.deltaTime);
	}
}
