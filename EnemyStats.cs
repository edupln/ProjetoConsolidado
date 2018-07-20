using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
	public static string enemyName = "Esqueleto";
	public static int enemyLevel=1, enemyAttack, enemyDefense, xpToPlayer=10, enemyTotalLife, enemyMagic, enemyTotalMagic;
	public int enemyLife;

	private int damageToFloatingText, occursOnlyOnce=1;
	public bool inCollision;
	public float attackCounter;
	public GameObject FloatingTextPrefab, damageParticle;
	public Animator enemyAnimator;//variavel que controla a animaçao do inimigo
	
	void Start (){
		Recalculation();		
	}
	
	void Update (){	
		respectPlayerCombatAttackTime();

		if(enemyLife<0)
			enemyLife=0;
		
		if(enemyMagic<0)
			enemyMagic=0;
	}
	
	public void Recalculation(){
		enemyAttack=5*enemyLevel;
		enemyDefense=5*enemyLevel;
		enemyTotalLife=100*enemyLevel;
		enemyTotalMagic=10*enemyLevel;
		enemyLife=enemyTotalLife;
		enemyMagic=enemyTotalMagic;
	}

	public void DamageReceived(int damage)
			{
				if(!inCollision){
					attackCounter=0f;
					damageToFloatingText = damage-enemyDefense;
					if(FloatingTextPrefab && enemyLife > 0){//so se houver o GameObject FloatingTextPrefab e hp maior que 0
						ShowFloatingText();
					}
					inCollision=true;
					enemyLife -= (damage-enemyDefense);
					//animatorClip = enemyAnimator.GetCurrentAnimatorClipInfo(0);//clipe em execuçao no layer zero
					if (enemyLife <= 0){
						if(occursOnlyOnce>0){
							Instantiate(damageParticle, transform.position, transform.rotation);
							PlayerStats.AddXp(xpToPlayer);
							enemyAnimator.SetBool("Dead",true);
							PlayerCombat.enemyHud.SetActive(false);
							Invoke("DestroyObject", 3f);
						}
						occursOnlyOnce--;
					}
					else{
						PlayerCombat.enemyHud.SetActive(true);
						Instantiate(damageParticle, transform.position, transform.rotation);
		//				if(animatorClip[0].clip.name != "Attack1" && enemyLife>0)		
		//					enemyAnimator.SetTrigger("Hit");
					}
				}
			}

		void DestroyObject(){
			Destroy(gameObject);
		}
	
		void respectPlayerCombatAttackTime(){
			attackCounter += Time.deltaTime;
			if(attackCounter>PlayerCombat.attackTime){
				attackCounter=0.0f;
				inCollision=false;
			}
		}
		//instanciar o texto flutuante na cabeça do inimigo
		void ShowFloatingText(){
			var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
			go.GetComponent<TextMesh>().text = damageToFloatingText.ToString();
	//		go.GetComponent<TextMesh>().text = currentHP.ToString();
		}
		
	public void MagicConsume(int magicConsume){
		enemyMagic-=magicConsume;
	}
}


// Original abaixo

//using System.Collections;
//using UnityEngine;
//
//public class EnemyStats : MonoBehaviour {
//	public string name = "Esqueleto";
//	public int attack=5, defense=2, xpGived=10, level=1, maxHP=50, currentHP;
//	private int damageToFloatingText, occursOnlyOnce=1;
//	public bool inCollision;
//	public float attackCounter;
//	public GameObject FloatingTextPrefab, damageParticle;
//	public Animator enemyAnimator;//variavel que controla a animaçao do inimigo
//	//public AnimatorClipInfo[] animatorClip;//variavel que pega o clipe em execuçao do inimigo
//	//private GameObject enemyObject;
//
//	void Awake()
//	{
//		currentHP = maxHP;
//	}
//
//	void Update () {
//		respectPlayerCombatAttackTime();
//	}
//
//	public void doDamage(int damage)
//	{
//		if(!inCollision){
//			attackCounter=0f;
//			damageToFloatingText = damage-defense;
//			if(FloatingTextPrefab && currentHP > 0){//so se houver o GameObject FloatingTextPrefab e hp maior que 0
//				ShowFloatingText();
//			}
//			inCollision=true;
//			currentHP -= (damage-defense);
//			//animatorClip = enemyAnimator.GetCurrentAnimatorClipInfo(0);//clipe em execuçao no layer zero
//			if (currentHP <= 0){
//				if(occursOnlyOnce>0){
//					Instantiate(damageParticle, transform.position, transform.rotation);
//					PlayerStats.AddXp(xpGived);
//					enemyAnimator.SetBool("Dead",true);
//					PlayerCombat.enemyHud.SetActive(false);
//					Invoke("DestroyObject", 3f);
//				}
//				occursOnlyOnce--;
//			}
//			else{
//				PlayerCombat.enemyHud.SetActive(true);
//				Instantiate(damageParticle, transform.position, transform.rotation);
////				if(animatorClip[0].clip.name != "Attack1" && enemyLife>0)		
////					enemyAnimator.SetTrigger("Hit");
//			}
//		}
//	}
//
//	void DestroyObject(){
//		Destroy(gameObject);
//	}
//
//	void respectPlayerCombatAttackTime(){
//		attackCounter += Time.deltaTime;
//		if(attackCounter>PlayerCombat.attackTime){
//			attackCounter=0.0f;
//			inCollision=false;
//		}
//	}
//	//instanciar o texto flutuante na cabeça do inimigo
//	void ShowFloatingText(){
//		var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
//		go.GetComponent<TextMesh>().text = damageToFloatingText.ToString();
////		go.GetComponent<TextMesh>().text = currentHP.ToString();
//	}
//}