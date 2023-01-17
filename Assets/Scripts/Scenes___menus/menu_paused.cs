using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_paused : MonoBehaviour
{
    public static bool				game_is_paused = false;
	public GameObject				menu_ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (game_is_paused == false)
			{
                ft_pause();
			}
			else
			{
                ft_resume();
			}
		}
    }

    public void ft_resume()
    {
		menu_ui.SetActive(false);
		game_is_paused = false;
		Time.timeScale = 1f;
    }
    
    public void ft_pause()
    {
        menu_ui.SetActive(true);
		game_is_paused = true;
		Time.timeScale = 0f;
    }
}
