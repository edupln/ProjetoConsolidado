using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenus : MonoBehaviour {

	public GameObject statsWindow;

	void Start () {
		statsWindow.SetActive(false);		
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			if(statsWindow.activeSelf==false){
				statsWindow.SetActive(true);
				//Time.timeScale=0;//pra pausar o tempo quando abrir a tela de status
			}

			else{
				statsWindow.SetActive(false);
				//Time.timeScale=1;//pra rodar o tempo quando sair da tela de status
			}
		}
		
	}
}
