
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class movements : MonoBehaviour
{
    public float moveSpeed; //to control ball speed 
    public float jumpForce; //for jumping
    public bool onfloor = true;
    private Rigidbody ball;
    int score;
    public uimanager ui;
    public TextMeshProUGUI Count;
    int pickkey;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Football";
        ball = GetComponent<Rigidbody>(); //establishing connection

        setCount();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {                                                       // A & D movement
            ball.AddForce(Vector3.right * moveSpeed);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            ball.AddForce(-Vector3.right * moveSpeed);
        }

        if (Input.GetAxis("Vertical") > 0)
        {                                                      // W & S movement                    
            ball.AddForce(Vector3.forward * moveSpeed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            ball.AddForce(-Vector3.forward * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onfloor)        // jump movement
        {
            ball.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onfloor = false;
        }

        if (transform.position.y <= -5f)
        {
            ui.gameover();

        }

    }

    void setCount()                                    //score display
    {
        Count.text = "SCORE: " + score.ToString();
    }

    private void OnCollisionEnter(Collision collision)      //jump only when ball touches ground
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            onfloor = true;
        }

        if (collision.gameObject.CompareTag("enemy"))              //when ball collide with an enemy object,
        {                                                         // the ball gets destroyed, and the 'Game over' text is displayed
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            ui.gameover();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")  //coin collection
        {                                    
            score++;
            other.gameObject.SetActive(false);
            setCount();
        }

   
        if (other.tag == "key")       //we have to collect 2 keys for winning the game
        {
            pickkey++;                                         
            other.gameObject.SetActive(false);
        }
        
        if (pickkey ==2 )            //winning condition
        {
            ui.win();
        }

    }

    
}
  