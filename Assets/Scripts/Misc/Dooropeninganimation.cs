using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropeninganimation : MonoBehaviour
{
  
    
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && GameObject.Find("Key") == null)
        {
            transform.parent.GetComponent<LevelTransition>().CollisionDetected(this);

        }
    }
}
