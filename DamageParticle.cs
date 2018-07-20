using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParticle : MonoBehaviour{
	public float DestroyTime = 0.1f;
	public Vector3 Offset = new Vector3(0,1,0);
	//public Vector3 RandomizeIntensity = new Vector3(05, 0, 0);
	
	void Start () {
		Destroy(gameObject, DestroyTime);
		
		//para mudar a altura do texto instanciado, tive que lançar 8 no y no inspector
		transform.localPosition += Offset;
		//para randomizar a posicao
		//		transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
		//		Random.Range (-RandomizeIntensity.y, RandomizeIntensity.y),
		//		Random.Range(-RandomizeIntensity.z,RandomizeIntensity.z));
	}
}