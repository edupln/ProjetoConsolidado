using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DamageOnEnemy : MonoBehaviour 
{
	private bool inAttack;
	public GameObject weapon;
	private float attackCounter;
	public int weaponStrength;//dano da arma

	void Start () {
		weapon.GetComponent<MeleeWeaponTrail>().Emit = false;
		weaponStrength = 10;
	}

	void Update (){	
		if(!PlayerCombat.attacking){
			inAttack = false;
			weapon.GetComponent<MeleeWeaponTrail>().Emit = false;
		}
		else{
			inAttack=true;
			weapon.GetComponent<MeleeWeaponTrail>().Emit = true;
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if(inAttack){
			//Debug.Log ("DamageOnEnemy Triggers");
			GameObject objectCollided = collider.gameObject;  // Get a reference to the object hit
			EnemyStats damageableComponent = objectCollided.GetComponent<EnemyStats>();		
			if (damageableComponent){
				damageableComponent.DamageReceived(weaponStrength+PlayerStats.attack);//era DoDamage
			}
		}
	}
}