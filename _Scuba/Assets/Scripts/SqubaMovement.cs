using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SqubaMovement : MonoBehaviour
{
    private const float maxSpeed = 4f;
    private const float minSpeed = .3f;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float currentSpeed;
    [SerializeField] private bool isSlowDown;

    [SerializeField] private float amplitude;
    [SerializeField] private float distance;
    [SerializeField] private float offset;

    private bool one;
    private bool two;
    private bool three;
    private bool four;

    [SerializeField] private Text healthText;
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = maxSpeed - minSpeed;
        currentHealth = maxHealth;
        healthText = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
    }
    private void Update()
    {
        healthText.text = "Live's - " + currentHealth.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moveforward();
        WaterPipe();
    }

    public void SlowInputDown()
    {
        isSlowDown = true;
    }
    public void SlowInputUP()
    {
        isSlowDown = false;
    }

    void Moveforward()
    {
        if (!isSlowDown)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, minSpeed, deceleration * Time.deltaTime);
        }

        Vector3 move = transform.right * currentSpeed * Time.deltaTime;
        transform.position += move;
        float y = Mathf.Sin(Time.time + distance) * offset * amplitude;
        transform.position += transform.up * y;
    }



    void WaterPipe()
    {
        if (transform.position.x > 34.5f && transform.position.x < 34.6f)
        {
            SoundManager.PlaySound("Blah", true);
        }

        if (transform.position.x > 55f && !one)
        {
            SoundManager.PlaySound("Blah", true);
            transform.position = new Vector3(-35f, 7f, transform.position.z);
            one = true;
        }
        else if (transform.position.x > 55f && !two && one)
        {
            SoundManager.PlaySound("Blah", true);
            transform.position = new Vector3(-35f, -2.5f, transform.position.z);
            two = true;
        }
        else if (transform.position.x > 55f && !three && two)
        {
            SoundManager.PlaySound("Blah", true);
            transform.position = new Vector3(-35f, -12.5f, transform.position.z);
            three = true;
        }
        else if (transform.position.x > 45f && !four && three)
        {
            SoundManager.PlaySound("Win", true);
            GetComponent<SqubaMovement>().enabled = false;
            four = true;
        }

    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GetComponent<SqubaMovement>().enabled = false;
            SoundManager.PlaySound("Out", true);
        }
    }

}
