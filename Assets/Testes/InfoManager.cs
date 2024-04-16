using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour {

	public bool profetas = true;
	public bool ativo = true;

	private GameObject infoMenu = null;
	private GameObject pergaminho = null;
	private GameObject descricao = null;
	private GameObject historia = null;

	private GameObject aMostra = null;

	// Use this for initialization
	void Start () {
		// Inicializa o painel de informativos
		infoMenu = transform.parent.Find ("InfoSample").gameObject;
		infoMenu.SetActive (ativo);

		// Referencia a descrição, história e pergaminho (Sala dos Profetas)
		descricao = infoMenu.transform.Find ("Canvas").Find ("Descricao").gameObject;
		historia = infoMenu.transform.Find ("Canvas").Find ("Historia").gameObject;
		if (profetas) {
			pergaminho = infoMenu.transform.Find ("Canvas").Find ("Pergaminho").gameObject;
			pergaminho.SetActive (false);
		}

		if (ativo) {
			aMostra = descricao;
		}
		descricao.SetActive (ativo);
		historia.SetActive(false);
	}

	public void Reset()
	{
		if (aMostra) {
			aMostra.SetActive (false);
		}
		if (ativo) {
			aMostra = descricao;
			aMostra.SetActive (true);
		}
	}

	public void BotaoDescricao()
	{
		if (aMostra) {
			aMostra.SetActive (false);
		}
		aMostra = descricao;
		aMostra.SetActive (true);
	}

	public void BotaoHistoria()
	{
		if (aMostra) {
			aMostra.SetActive (false);
		}
		aMostra = historia;
		aMostra.SetActive (true);
	}


	public void BotaoPergaminho()
	{
		if (aMostra) {
			aMostra.SetActive (false);
		}
		aMostra = pergaminho;
		aMostra.SetActive (true);
	}

	public void ShowInfo()
	{
		ativo = !ativo;
		infoMenu.SetActive (ativo);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
