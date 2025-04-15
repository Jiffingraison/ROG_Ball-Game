using TMPro;
using UnityEngine;

public class basketball : MonoBehaviour
{
    public float moveSpeed; //to control ball speed 
    public float jumpForce; //for jumping
    public bool onfloor = true;
    private Rigidbody ball;
    int score;
    public uimanager ui;
    public TextMeshProUGUI Count;
    int pickkey;


    void Start()
    {
        gameObject.name = "Basketball";
        ball = GetComponent<Rigidbody>(); //establishing connection

        setCount();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {                                                                   // A & D movement
            ball.AddForce(Vector3.right * moveSpeed);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            ball.AddForce(-Vector3.right * moveSpeed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {                                                               // W & S movement                    
            ball.AddForce(Vector3.forward * moveSpeed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            ball.AddForce(-Vector3.forward * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onfloor)                    // jump movement
        {
            ball.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onfloor = false;
        }

        if (transform.position.y <= -5f)
        {
            ui.gameover();

        }

    }

    void setCount()                                   //score display
    {
        Count.text = "SCORE: " + score.ToString();
    }

    private void OnCollisionEnter(Collision collision)          //jump only when it is on ground
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            onfloor = false;
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            ui.gameover();
        }
    }

    private void OnTriggerEnter(Collider other)          //coin collecting
    {
        if (other.tag == "coin")
        {
            score++;
            other.gameObject.SetActive(false);
            setCount();
        }


        if (other.tag == "key")                       //key collecting
        { 
            pickkey++;
            other.gameObject.SetActive(false);
        }

        if (pickkey == 2)                   //condition for winning the game
        {
            ui.winTxt();
        }

    }

}
