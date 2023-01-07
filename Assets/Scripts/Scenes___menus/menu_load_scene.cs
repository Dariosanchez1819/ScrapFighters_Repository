using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu_load_scene : MonoBehaviour
{

    public string name_next_scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ft_next_scene()
    {
      SceneManager.LoadScene(name_next_scene);
    }
}
