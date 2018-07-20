using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int level=1, nextLevel, xp=0, xpToLevel, xpDiff, life, totalLife, magic, totalMagic, attack, defense;//caso eu abra coop, preciso tirar life do static

	void Start (){
		Recalculation();		
	}

	void Update (){
		nextLevel=level+1;
		xpToLevel=50*nextLevel*level;

		if(xp>=xpToLevel){
			xpDiff=xp-xpToLevel;
			LevelUp();
		}

		if(life<0)
			life=0;

		if(magic<0)
			magic=0;
	}

	public void Recalculation(){
		attack=5*level;
		defense=5*level;
		totalLife=100*level;
		totalMagic=10*level;
		life=totalLife;
		magic=totalMagic;
	}

	public static void AddXp(int newXP){
		xp+=newXP;
	}

	public void LevelUp(){
		level++;
		xp=0+xpDiff;
		Recalculation();
	}

	public void DamageReceived(int damage){
		life=life-(damage-defense);
	}

	public void MagicConsume(int magicConsume){
		magic-=magicConsume;
	}
}
