using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
	public string name = "Esqueleto";
	public int attack=5, defense=2, xpGived=10, level=1, maxHP=50, currentHP;
	private int damageToFloatingText, occursOnlyOnce=1;
	public bool inCollision;
	public float attackCounter;
	public GameObject FloatingTextPrefab, damageParticle;
	public Animator enemyAnimator;//variavel que controla a animaçao do inimigo
	//public AnimatorClipInfo[] animatorClip;//variavel que pega o clipe em execuçao do inimigo
	//private GameObject enemyObject;

	void Awake()
	{
		currentHP = maxHP;
	}

	void Update () {
		respectPlayerCombatAttackTime();
	}

	public void doDamage(int damage)
	{
		if(!inCollision){
			attackCounter=0f;
			if(FloatingTextPrefab && currentHP > 0){//so se houver o GameObject FloatingTextPrefab e hp maior que 0
				ShowFloatingText();
			}
			inCollision=true;
			currentHP -= (damage-defense);
			//animatorClip = enemyAnimator.GetCurrentAnimatorClipInfo(0);//clipe em execuçao no layer zero
			damageToFloatingText = damage-defense;
			if (currentHP <= 0){
				if(occursOnlyOnce>0){
					Instantiate(damageParticle, transform.position, transform.rotation);
					PlayerStats.AddXp(xpGived);
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
}