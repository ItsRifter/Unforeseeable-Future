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
    private bool facingRight;
    public AudioClip[] audioClips;
    private float direction;

    private SpriteRenderer spriteRender;

    private AudioSource audioSrc;

    [SerializeField]
    public Tilemap tilemap;


    public Animator Animations;

    

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        facingRight = true;
        audioSrc = gameObject.GetComponentInChildren<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        Animations = GetComponent<Animator>();




    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(IsGrounded());
        Animations.SetBool("Grounded", IsGrounded()); 
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
        direction = (Input.GetAxis("Horizontal"));

        float HorizontalMovement = movement.x;
        Animations.SetFloat("Speed", Mathf.Abs(HorizontalMovement));

        if(direction > 0 && !facingRight)
        {
            Flip();
        }
        else if(direction < 0 && facingRight)
        {
            Flip();
        }
        transform.position += movement * Time.deltaTime * moveSpeed;
    }


    private void Jump()
    {
        //if the space bar is pressed the player gets moved up by the set variable "jumpForce" 

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //The request to jump is no longer true and thus the player can no longer jump
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaling = transform.localScale;
        scaling.x *= -1;
        transform.localScale = scaling;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size/2, 0f, Vector2.down, 1f, GroundType);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiles"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                //Debug.Log(hit.point);
                hitPosition.x = hit.point.x - 0.1f;
                hitPosition.y = hit.point.y - 0.1f;

            }
            
            StartCoroutine(Collapse(hitPosition));
        }

    }

    IEnumerator Collapse(Vector3 hitPosition)
    {
        yield return new WaitForSeconds(.3f);

        tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
    }


  

}
