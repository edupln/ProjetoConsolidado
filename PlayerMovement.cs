//O personagem nao se movera ate adicionar o Run no Edit/Project Setting/Input
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
	//criando as variaveis
	public float speed = 5f, originalSpeed, jumpForce = 8f, gravity = 30f;
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
	}

	void Update(){
		Transform t = this.transform;
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
				speed = 0.5f;
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
				moveDir.y=jumpForce;
			}
		}
		else{
			anim.SetBool("isGrounded",false);
		}
		//cair de acordo com a gravidade
		moveDir.y -= gravity*Time.deltaTime;
		//mover-se
		controller.Move(moveDir*Time.deltaTime);
	}
}


//controle2

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class PlayerMovement : MonoBehaviour
//{
//	private float originalSpeed;
//	public static bool running;
//
//	public float Speed = 5f;
//	public float JumpHeight = 2f;
//	public float DashDistance = 7f;
//		
//	private Rigidbody _body;
//	private Vector3 _inputs = Vector3.zero;
//
//	private Collider coll;
//	private Animator anim;
//
//	public static bool onGround;
//
//	void Awake(){
//		anim=GetComponent<Animator>();//controla o animator
//		coll=GetComponent<Collider>();//para checar se esta no chao
//	}
//	
//	void Start()
//	{
//		_body = GetComponent<Rigidbody>();	
//		originalSpeed = Speed;
//	}
//	
//	void Update()
//	{
//		if(PlayerCombat.attacking){
//			Speed = Speed - (Speed - 0.5f);
//		}
//		else{
//			Speed=originalSpeed;
//			running = false;
//			anim.SetBool("Running",false);
//			if (Input.GetButton("Run") && onGround && _inputs != Vector3.zero)
//			{
//				Speed = Speed * 1.5f;
//				running=true;
//				anim.SetBool("Running",true);
//			}
//		}
//
//		if(Grounded()){//para checar se esta no chao
//			onGround=true;
//			anim.SetBool("OnGround",true);
//		}
//		else{
//			onGround=false;
//			anim.SetBool("OnGround",false);
//		}
//
//		anim.SetBool("Move", false);
//
//		_inputs = Vector3.zero;
//		_inputs.x = Input.GetAxis("Horizontal");
//		_inputs.z = Input.GetAxis("Vertical");
//
//		if (_inputs != Vector3.zero){
//			transform.forward = _inputs;//vira o personagem para o lado do movimento
//			anim.SetBool("Move",true);
//		}
//		
//		if (Input.GetButtonDown("Jump") && onGround && !PlayerCombat.attacking)
//		{
//			//_body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
//			_body.AddForce(Vector3.up*JumpHeight , ForceMode.Impulse);
//		}
//
//		if (Input.GetButtonDown("Dash") && onGround)
//		{
//			Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
//			_body.AddForce(dashVelocity, ForceMode.VelocityChange);
//		}
//	}
//		
//	void FixedUpdate()//movimentos ligados a fisica
//	{
//		_inputs = Vector3.ClampMagnitude (_inputs, 1);
//		_body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);//move o personagem
//	}
//
//	bool Grounded(){
//		return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);//checa chao
//	}
//}

//controle1

//public class PlayerMovement : MonoBehaviour {
//	public float moveSpeed=5.0f, gravity=20.0f;
//	private Vector3 moveDirection;
//	private CharacterController controller;
//	private Animator anim;
//
//
//
//	//Inicio: So se quiser que o player olhe para o mouse
////	private Plane ground;
////	private float dist;
//	//Fim: So se quiser que o player olhe para o mouse
//
//
//	void Awake(){
//		controller=GetComponent<CharacterController>();
//		anim=GetComponent<Animator>();
//
//		//Inicio: So se quiser que o player olhe para o mouse
//		//ground=new Plane(Vector3.up,Vector3.zero); 
//		//Fim: So se quiser que o player olhe para o mouse
//	}
//
//	void Start () {
//		
//	}
//
//	void Update () {				
//		anim.SetBool("Move", false);
//
//		if(controller.isGrounded){
//			moveDirection=new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"));
//			moveDirection=transform.TransformDirection(moveDirection);
//			moveDirection *=moveSpeed;
//		
//			//Inicio: So se quiser que o player olhe para o mouse
////			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
////			if(ground.Raycast(ray, out dist)){
////				Vector3 stayPoint = new Vector3(ray.GetPoint(dist).x, transform.position.y, ray.GetPoint(dist).z);
////				transform.LookAt(stayPoint);
////				transform.rotation=Quaternion.Euler(new Vector3(0.0f, transform.rotation.eulerAngles.y,0.0f));
////			}
//			//Fim: So se quiser que o player olhe para o mouse
//		}
//		if(Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f){
//			anim.SetBool("Move",true);
//		}
//		if(PlayerCombat.attacking == false){
//			moveDirection.y -= gravity * Time.deltaTime;//para cair de acordo com gravidade?
//			controller.Move (moveDirection * Time.deltaTime);
//		}
//		else{
//			moveDirection.y -= gravity * Time.deltaTime;//para cair de acordo com gravidade?
//			moveDirection = moveDirection * (moveSpeed - (moveSpeed - 0.05f));
//			controller.Move (moveDirection * Time.deltaTime);
//		}
//	}
//}
