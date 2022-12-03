using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    public Character a;
    public Character b;

    public string scene_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a.lives <= 0 || b.lives <= 0)
            SceneManager.LoadScene(scene_name);
    }
}
