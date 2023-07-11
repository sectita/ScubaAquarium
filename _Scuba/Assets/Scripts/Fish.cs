using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 5.5f;
    [SerializeField] private Text scoreText;


    private Transform target;
    private SpriteRenderer spriteRenderer;
    private bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        target = pointA;
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Moveforward();
    }
    public float radius;
    private float Score;

    private void FixedUpdate()
    {
        

        if (Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Squba")))
        {
            Score++;
            scoreText.text = "Score - " + Mathf.RoundToInt(Score).ToString();
            
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }

    void Moveforward()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            if (target == pointA)
            {
                target = pointB;
            }
            else
            {
                target = pointA;
            }

            right = !right;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Squba")
        {
            SqubaMovement squbaMovement = collision.gameObject.GetComponent<SqubaMovement>();
            if (squbaMovement != null)
            {
                SoundManager.PlaySound("Hurt", true);
                squbaMovement.Damage(1);
            }
        }
    }
    
}
