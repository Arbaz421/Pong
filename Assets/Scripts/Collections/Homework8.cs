using UnityEngine;

public class Homework8 : MonoBehaviour
{
    public GameObject[] gameObjects; // Array to hold game objects
    float speed = 10.0f;

    // Moves the object in a given direction at the specified speed
    Vector3 MoveObject(Vector3 direction, float speed)
    {
        return direction * speed * Time.deltaTime;
    }

    void Update()
    {
        // Loop through the array of game objects
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                // Call MoveObject on each element
                gameObjects[i].transform.position += MoveObject(Vector3.right, speed); // Move to the right
            }
        }
    }
}
