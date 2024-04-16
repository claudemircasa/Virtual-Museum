using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

	private bool principal, esquerda, frente, direita, corredor;
	private GameObject Sprincipal, Sesquerda, Sfrente, Sdireita, Scorredor;

	public GameObject ObjetoControle;
	private Vector3 pos;
	private Vector2 tupla;




	// Use this for initialization
	void Start () {
		principal = true;
		esquerda = false;
		frente = false;
		direita = false;
		corredor = false;

		Sprincipal = transform.Find ("Principal").gameObject;
		Sesquerda = transform.Find ("Esquerda").gameObject;
		Sfrente = transform.Find ("Frente").gameObject;
		Sdireita = transform.Find ("Direita").gameObject;
		Scorredor = transform.Find ("LuzesCorredor").gameObject;

		Sprincipal.SetActive (principal);
		Sesquerda.SetActive (esquerda);
		Sfrente.SetActive (frente);
		Sdireita.SetActive (direita);
		Scorredor.SetActive (corredor);
	}

/*
	void OnCollisionEnter (Collision col) {
		Debug.Log (col.gameObject.name + " entrou em " + gameObject.name);
		if(col.gameObject.name == "[CameraRig]") {
			Debug.Log ("Acende as luzes de " + gameObject.name);
		}
	}

	void OnCollisionExit (Collision col) {
		Debug.Log (col.gameObject.name + " saiu de " + gameObject.name);
		if(col.gameObject.name == "[CameraRig]") {
			Debug.Log ("Apaga as luzes de " + gameObject.name);
		}
	}


	public void SalaPrincipal (){
		principal = !principal;
		Sprincipal.SetActive (principal);
	}

	public void SalaEsquerda (){
		esquerda = !esquerda;
		Sesquerda.SetActive (esquerda);
	}
		
	public void SalaFrente (){
		frente = !frente;
		Sfrente.SetActive (frente);
	}

	public void SalaDireita (){
		direita = !direita;
		Sdireita.SetActive (direita);
	}
*/
	// Update is called once per frame
	void Update () {
		// Posicão da camera/ObjControle
		tupla.x = ObjetoControle.transform.localPosition.x;
		tupla.y = ObjetoControle.transform.localPosition.z;

		principal = false;
		esquerda = false;
		frente = false;
		direita = false;
		corredor = false;

		if (tupla.x >= -16.1f && tupla.x <= 0.6f &&
			tupla.y <= 19.1f && tupla.y >= 3.5f) {
			// Está na sala da Esquerda
			esquerda = true;
		} else if (tupla.x >= 4.91f && tupla.x <= 17.6f &&
			tupla.y <= 7.8f && tupla.y >= -22.2f) {
			// Está na sala da Frente
			frente = true;
		} else if (tupla.x >= -21.9f && tupla.x <= 4.9f &&
			tupla.y <= -17.8f && tupla.y >= -37.1f) {
			// Está na Sala das Outras obras
			direita = true;
		} else {
			// Está na Sala Principal
			principal = true;
		}

		if (tupla.x >= -5.75f && tupla.x <= 5.6f &&
			tupla.y <= 3.21f && tupla.y >= -17.69f) {
			corredor = true;
		}

		Sprincipal.SetActive (principal);
		Sesquerda.SetActive (esquerda);
		Sfrente.SetActive (frente);
		Sdireita.SetActive (direita);
		Scorredor.SetActive (corredor);
	}
}
