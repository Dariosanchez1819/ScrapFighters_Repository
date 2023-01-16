using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu_select_character : MonoBehaviour
{
	public static char             position_p1;
	public static char             position_p2;

	public char						player_selecting;

	public GameObject				p1_portrait_a;
	public GameObject				p1_portrait_b;
	public GameObject				p1_portrait_c;

	public GameObject				p2_portrait_a;
	public GameObject				p2_portrait_b;
	public GameObject				p2_portrait_c;

	// Start is called before the first frame update
	void Start()
	{
		position_p1 = 'A';
		position_p2 = 'A';
		player_selecting = 'A';


		p1_portrait_a = GameObject.Find("Boton01_Player1_chosen");
		p1_portrait_b = GameObject.Find("Boton02_Player1_chosen");
		p1_portrait_c = GameObject.Find("Boton03_Player1_chosen");

		p2_portrait_a = GameObject.Find("Boton01_Player2_chosen");
		p2_portrait_b = GameObject.Find("Boton02_Player2_chosen");
		p2_portrait_c = GameObject.Find("Boton03_Player2_chosen");

		p1_portrait_b.SetActive(false);
		p1_portrait_c.SetActive(false);

		p2_portrait_a.SetActive(false);
		p2_portrait_b.SetActive(false);
		p2_portrait_c.SetActive(false);


	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (player_selecting == 'A')
			{
				p1_portrait_a.SetActive(false);
				p1_portrait_b.SetActive(false);
				p1_portrait_c.SetActive(false);

				p2_portrait_a.SetActive(true);

				player_selecting = 'B';
			}
			else
				SceneManager.LoadScene("Map_1");
		}






		if (player_selecting == 'A')
		{
			if (Input.GetKeyDown(KeyCode.D))
			{
				if (position_p1 == 'A')
				{
					p1_portrait_a.SetActive(false);
					p1_portrait_b.SetActive(true);
					position_p1 = 'B';
				}
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				if (position_p1 == 'B')
				{
					p1_portrait_a.SetActive(true);
					p1_portrait_b.SetActive(false);
					position_p1 = 'A';
				}
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				if (position_p1 == 'A')
				{
					p1_portrait_a.SetActive(false);
					p1_portrait_c.SetActive(true);
					position_p1 = 'C';
				}
			}
			if (Input.GetKeyDown(KeyCode.W))
			{
				if (position_p1 == 'C')
				{
					p1_portrait_c.SetActive(false);
					p1_portrait_a.SetActive(true);
					position_p1 = 'A';
				}
			}
		}




		if (player_selecting == 'B')
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (position_p2 == 'A')
				{	
					p2_portrait_a.SetActive(false);
					p2_portrait_b.SetActive(true);
					position_p2 = 'B';
				}
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (position_p2 == 'B')
				{
					p2_portrait_a.SetActive(true);
					p2_portrait_b.SetActive(false);
					position_p2 = 'A';
				}
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (position_p2 == 'A')
				{
					p2_portrait_a.SetActive(false);
					p2_portrait_c.SetActive(true);
					position_p2 = 'C';
				}
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (position_p2 == 'C')
				{
					p2_portrait_c.SetActive(false);
					p2_portrait_a.SetActive(true);
					position_p2 = 'A';
				}
			}
		}
	}
}
