using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class CharacterScript : MonoBehaviour
{
    public float moveSpeed = 10;
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    private BoxCollider2D bc;
    [SerializeField]
    private int jumpForce = 5;
    public LayerMask GroundType;

    public AudioClip[] audioClips;

    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(IsGrounded());
        BasicMovement();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
            audioSrc.clip = audioClips[0];
            Debug.Log(audioSrc.clip);
            audioSrc.Play();
        }
    }



    private void BasicMovement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }


    private void Jump()
    {
        //if the space bar is pressed the player gets moved up by the set variable "jumpForce" 

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //The request to jump is no longer true and thus the player can no longer jump
    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 1f, GroundType);
        return raycastHit.collider != null;
    }
}
