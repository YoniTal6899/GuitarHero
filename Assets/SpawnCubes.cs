using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private GameObject[] cubePrefab; // Reference to the cube prefab
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine for random dropping
        StartCoroutine(RandomDropCoroutine());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to randomly drop a new cube
    private IEnumerator RandomDropCoroutine()
    {
        while (true)
        {
            int randIndex;
            // Wait for a random amount of time
            float randomDelay = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(randomDelay);
            // Instantiate a new cube
            randIndex=(int)Random.Range(0f,3f);
            GameObject newCube = Instantiate(cubePrefab[randIndex], GetRandomPosition(), Quaternion.identity);
        }
    }

    // Method to get a random position for the new cube
    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-5f, 5f);
        float yPosition = 8f;
        return new Vector3(randomX, yPosition, 0f);
    }
}
