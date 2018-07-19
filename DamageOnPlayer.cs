using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnPlayer : MonoBehaviour {
	public int damage;
	public bool inAttack;
	private float attackCounter;
	public float attackTime=3.0f;

	public Animator enemyAnimator;

	void Start () {
		inAttack = false;		
	}

	void Update () {
		if(inAttack==true){
			attackCounter += Time.deltaTime;
			if(attackCounter>attackTime){
				attackCounter=0.0f;
				inAttack=false;
			}
		}
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player" && inAttack == false){
			inAttack=true;
			enemyAnimator.SetTrigger("Attack");
			//damage=gameObject.GetComponent<EnemyStats>().attack-PlayerStats.defense;
			other.gameObject.GetComponent<PlayerStats>().DamageReceived (damage);
		}
	}
}