using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public GameObject block;
    
    
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("player") && collision.contacts[0].normal.y > 0.5f)
        {
            
            Destroy(gameObject);
        }
    }
}
