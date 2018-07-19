//O controle do Hud tem de ficar aqui e posso so desativar sem destruir caso a busca pelo enemy seja null
//tempos de movimento de ataque e animaçoes ficam aqui
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour {

	public static bool attacking;
	public static float attackTime = 0.7f; //aqui e 0.7f
	private float attackCounter;
	public Animator playerAnimator;
	public static GameObject enemyHud;

	void Awake(){
		enemyHud = GameObject.Find ("EnemyHud");	
	}

	void Start(){
		attacking = false;
		enemyHud.SetActive(false);
	}

	void Update (){					
		if(!attacking){
			if(Input.GetButtonDown("Fire1")){
				attacking = true;
				playerAnimator.SetTrigger("Attack");
			}
		}
		else{	
			attackCounter += Time.deltaTime;
			if(attackCounter>attackTime){
				attackCounter=0.0f;
				attacking=false;
			}
		}
	}
}
