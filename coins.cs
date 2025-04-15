using UnityEngine;

public class coin : MonoBehaviour
{

    private float Speed=3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, Speed, 0);                        //coin rotation
    }
}
