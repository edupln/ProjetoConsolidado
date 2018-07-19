using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float moveSpeed = 5.0f, waitTime, moveTime;
	private float waitCounter, moveCounter;
	public float agroRange = 10;

	public float keepDistance = 0.5f;
	public float currentDistance;

	public GameObject target;
	public Rigidbody rb;
	private bool isMoving;

	private Vector3 moveDirection;
	public Animator enemyAnimator;

	public Vector3 dir;

	void Awake(){
		rb=GetComponent<Rigidbody>();
	}

	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");

		RandomWaitCounter();
		RandomMoveCounter();

		//EnemyStats enemyStats = GetComponent<EnemyStats>();
		//enemyStats.life = 10.0f;
	}

	void Update () {
		EnemyStats enemyStats = GetComponent<EnemyStats>();

		currentDistance = Vector3.Distance(transform.position,target.transform.position);

		transform.LookAt(target.transform.position);//olhar para o target

		if(currentDistance > agroRange && enemyStats.currentHP>0){
			if(isMoving){
				moveCounter-=Time.deltaTime;
				rb.velocity=moveDirection;

				if(moveCounter<0.0f){
					isMoving=false;
					enemyAnimator.SetBool("Move",false);
					RandomWaitCounter();
				}
			}
			else{
				waitCounter-=Time.deltaTime;
				rb.velocity=Vector3.zero;

				if(waitCounter<0.0f  && enemyStats.currentHP>0){
					isMoving=true;
					enemyAnimator.SetBool("Move",true);
					RandomMoveCounter();
					moveDirection=new Vector3(Random.Range(-1.0f,1.0f)*moveSpeed,0.0f,Random.Range(-1.0f,1.0f));
					transform.forward = moveDirection;
				}
			}
		}
		//distancia dentro do agro range e mantendo distancia do player
		if(currentDistance <= agroRange && currentDistance >= keepDistance && enemyStats.currentHP>0){

			dir=target.transform.position-transform.position;
			dir.Normalize();
			transform.forward = dir;//olhar p o target (player)

			enemyAnimator.SetBool("Move",true);
			transform.position+=dir*moveTime*Time.deltaTime;
		}
		else if(currentDistance<=agroRange && currentDistance < keepDistance){
			enemyAnimator.SetBool("Move",false);
		}
	}

	public void RandomWaitCounter(){
		waitCounter=Random.Range(moveTime*0.75f,waitTime*1.25f);
	}

	public void RandomMoveCounter(){
		moveCounter=Random.Range(moveTime*0.75f,moveTime*1.25f);
	}
}
