using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
	private Character			a;
	private Character			b;
	public string					scene_name;

	public float					time_first_fall;
	public float					time_second_fall;

	public GameObject			Fase01;
	public GameObject			Fase02;

	void Start()
	{
			a = GameObject.Find("Character_a").GetComponent<Character>();
			b = GameObject.Find("Character_b").GetComponent<Character>();
	}

	// Update is called once per frame
	void Update()
	{
		if (a.lives <= 0 || b.lives <= 0)
			SceneManager.LoadScene(scene_name);
		plataforms_change();
	}




	void plataforms_change()
	{
		if (Time.time > time_first_fall)
			Fase02.SetActive(false);
		if (Time.time > time_second_fall) 
			Fase01.SetActive(false);
	}
}
