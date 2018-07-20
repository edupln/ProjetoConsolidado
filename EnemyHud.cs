using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHud : MonoBehaviour {
	public Text enemyLevelText;
	public Slider enemyLifeSlider;

//	private EnemyStats enemyObject = new gameObject<EnemyStats>();

	void Start () {
		
	}
	
	void Update () {//lembra de checar enemystas ou null no if caso bugar

//		enemyObject = GetComponent<EnemyStats>();
//		enemyLevelText.text=enemyObject.gameObject.GetComponent<EnemyStats>().level.ToString();
//		enemyLifeSlider.maxValue=enemyObject.gameObject.GetComponent<EnemyStats>().maxHP;
//		enemyLifeSlider.value=enemyObject.gameObject.GetComponent<EnemyStats>().currentHP;
	}
}
//remover