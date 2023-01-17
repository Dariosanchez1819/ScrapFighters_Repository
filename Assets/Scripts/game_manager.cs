using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
	private Character				a;
	private Character				b;
	public string					scene_name;

	public float					time_first_fall;
	public float					time_second_fall;

	public GameObject				Fase01;
	public GameObject				Fase02;


	//Handle Characters

	public GameObject				Character_A_p1;
	public GameObject				Character_B_p1;
	public GameObject				Character_C_p1;

	public GameObject				Character_A_p2;
	public GameObject				Character_B_p2;
	public GameObject				Character_C_p2;

	//Handle Portraits

	public GameObject				Portrait_A_p1;
	public GameObject				Portrait_B_p1;
	public GameObject				Portrait_C_p1;

	public GameObject				Portrait_A_p2;
	public GameObject				Portrait_B_p2;
	public GameObject				Portrait_C_p2;

	
	void Start()
	{
		time_first_fall += Time.time;
		time_second_fall += Time.time;

		if (menu_select_character.position_p1 == 'A')
		{
			Portrait_A_p1.SetActive(true);
			Character_A_p1.SetActive(true);
		}
		else if (menu_select_character.position_p1 == 'B')
		{
			Portrait_B_p1.SetActive(true);
			Character_B_p1.SetActive(true);
		}
		else if (menu_select_character.position_p1 == 'C')
		{
			Portrait_C_p1.SetActive(true);
			Character_C_p1.SetActive(true);
		}



		if (menu_select_character.position_p2 == 'A')
		{
			Portrait_A_p2.SetActive(true);
			Character_A_p2.SetActive(true);
		}
		else if (menu_select_character.position_p2 == 'B')
		{
			Portrait_B_p2.SetActive(true);
			Character_B_p2.SetActive(true);
		}
		else if (menu_select_character.position_p2 == 'C')
		{
			Portrait_C_p2.SetActive(true);
			Character_C_p2.SetActive(true);			
		}

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
		{
			Fase02.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-1,0);
		}
		if (Time.time > time_second_fall) 
			Fase01.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-1,0);
	}
}
