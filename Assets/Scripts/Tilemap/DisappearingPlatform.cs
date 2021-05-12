using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DisappearingPlatform : MonoBehaviour
{
    public ContactPoint2D[] contacts = new ContactPoint2D[10];

    private void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        print("Colliding");
        if(other.collider.CompareTag("Player"))
        {
           

            StartCoroutine(Collapse());
        }
    }

    IEnumerator Collapse()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
