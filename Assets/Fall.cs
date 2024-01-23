using UnityEngine;
using System.Collections;

public class FallingCubes : MonoBehaviour
{
    public float fallSpeed = 5;
    public KeyCode associatedKey=KeyCode.Space; // The key associated with this cube
    public float timeToPress = 0.5f; // Time in seconds to press the correct input
    private GameManager gameManage;
    private bool hasBeenPressed = false;
    void Start()
    {
        // Find the GameManager in the scene
        gameManage = GameObject.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom Boarder") && !hasBeenPressed)
        {
            // Start the coroutine to check for input within the time window
            StartCoroutine(CheckInputCoroutine());
        }
    }

    private IEnumerator CheckInputCoroutine()
    {
        float timer = 0f;

        while (timer < timeToPress)
        {
            // Check if the associated key is pressed using Unity's Input class
            if (Input.GetKeyDown(associatedKey))
            {
                hasBeenPressed = true;
                gameManage.IncreaseHits();
                break; // Exit the loop if correct input is detected
            }

            timer += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        if (!hasBeenPressed)
        {
            gameManage.LoseLife();
        }
        hasBeenPressed=false;
        
    }
}
