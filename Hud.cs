using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
	public Text levelText;
	public Slider lifeSlider, magicSlider, xpSlider;

	void Start () {
		
	}

	void Update () {
		levelText.text=PlayerStats.level.ToString();

		lifeSlider.maxValue=PlayerStats.totalLife;
		lifeSlider.value=PlayerStats.life;
		magicSlider.maxValue=PlayerStats.totalMagic;
		magicSlider.value=PlayerStats.magic;
		xpSlider.maxValue=PlayerStats.xpToLevel;
		xpSlider.value=PlayerStats.xp;
	}
}
