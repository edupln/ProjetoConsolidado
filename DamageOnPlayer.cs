using UnityEngine;

public class DamageOnPlayer : MonoBehaviour{
	private bool canAttack;
	private float attackCounter;
	public float attackTime=2.0f;
	public int weaponStrength;//dano da arma
	public Animator enemyAnimator;
	
	void Start (){
		weaponStrength = 5;
	}
	
	void Update (){	
		if(!canAttack){
			attackCounter += Time.deltaTime;
			if(attackCounter>attackTime){
				attackCounter=0.0f;
				canAttack=true;
			}
		}
	}
	
	void OnTriggerStay(Collider collider){
		if(collider.gameObject.tag == "Player" && canAttack){		
			canAttack=false;
			enemyAnimator.SetTrigger("Attack");
			GameObject objectCollided = collider.gameObject;  // Get a reference to the object hit
			PlayerStats damageableComponent = objectCollided.GetComponent<PlayerStats>();		
			if (damageableComponent){
				damageableComponent.DamageReceived(weaponStrength+EnemyStats.enemyAttack);//era DoDamage
			}
		}
	}
}
