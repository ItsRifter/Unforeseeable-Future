using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : MonoBehaviour
{
    private float waitRespawnTime = 1f;
    public AudioSource audioSrc;
    public AudioClip soundClip;
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D col2D)
    {
        if (col2D.gameObject.CompareTag("Player"))
        {
            StartCoroutine("PlayerDeath");
            audioSrc.clip = soundClip;
            audioSrc.Play();
            Destroy(col2D.gameObject);
        }
    }
    
    private IEnumerator PlayerDeath()
    {
        anim.SetTrigger("Player_Dead");
        Debug.Log("Player died");
        yield return new WaitForSeconds(waitRespawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
