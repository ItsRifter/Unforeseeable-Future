using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private float waitRespawnTime = 1.5f;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            print("Player has fallen down here");
            Destroy(other.gameObject);
            StartCoroutine("PlayerDeath");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private IEnumerator PlayerDeath()
    {
        anim.SetTrigger("Player_Dead");
        Debug.Log("Player fell off and died");
        yield return new WaitForSeconds(waitRespawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
