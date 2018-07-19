using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class StatsWindow : MonoBehaviour {
	public Text level, xp, life, magic, attack, defense;

	void Start () {
		
	}

	void Update () {
		level.text="Nv: "+PlayerStats.level;
		xp.text="Exp: "+PlayerStats.xp + " / " + "Exp Prox Nv: "+PlayerStats.xpToLevel;
		life.text="Vida: "+PlayerStats.life + " / " +PlayerStats.totalLife;
		magic.text="Mana: "+PlayerStats.magic + " / " +PlayerStats.totalMagic;
		attack.text="Ataque: "+PlayerStats.attack;
		defense.text="Defesa: "+PlayerStats.defense;
	}
}
