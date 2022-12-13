using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_destructible : MonoBehaviour
{
    public int                      lifes;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }


	private void OnTriggerEnter2D(Collider2D other)
    {
        if (lifes <= 0)
        {
            lifes--;
            Destroy(gameObject);
        }
    }
}
