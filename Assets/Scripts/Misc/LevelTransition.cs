using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition : MonoBehaviour
{
    public Animator Animations;

    private void Awake()
    {
        Animations = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If this object collides with the tag "Player" then the if statement executes
        if (other.CompareTag("Player") && GameObject.Find("Key") == null)
        {
            //Using Scene Manager the player will be transported to the next scene specified by the value of the variable next level edited in the editor (probably can be automated)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void CollisionDetected(Dooropeninganimation door)
    {
        print("Player has entered the door");
        Animations.SetBool("Unlocked", true);
        
    }
}
