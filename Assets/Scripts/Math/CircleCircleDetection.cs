using UnityEngine;

public class CircleCircleDetection : MonoBehaviour
{
    public GameObject circle1;
    public GameObject circle2;

    void Update()
    {
        // Get positions and radii
        Vector2 position1 = circle1.transform.position;
        Vector2 position2 = circle2.transform.position;
        float radius1 = circle1.transform.localScale.x * 0.5f; 
        float radius2 = circle2.transform.localScale.x * 0.5f;

        // Collision check and response
        Vector2 mtv;
        bool collision = CheckCollisionCircles(position1, radius1, position2, radius2, out mtv);
        if (collision)
        {
            circle1.transform.position += new Vector3(mtv.x, mtv.y, 0.0f);
            SetCircleColors(Color.green);
        }
        else
        {
            SetCircleColors(Color.red);
        }
    }

    bool CheckCollisionCircles(Vector2 position1, float radius1, Vector2 position2, float radius2, out Vector2 mtv)
    {
        float distance = Vector2.Distance(position1, position2);
        float radiiSum = radius1 + radius2;
        bool collision = distance <= radiiSum;

        if (collision)
        {
            Vector2 direction = (position2 - position1).normalized;
            float penetrationDepth = radiiSum - distance;
            mtv = direction * penetrationDepth;
        }
        else
        {
            mtv = Vector2.zero;
        }
        return collision;
    }

    void SetCircleColors(Color color)
    {
        circle1.GetComponent<SpriteRenderer>().color = color;
        circle2.GetComponent<SpriteRenderer>().color = color;
    }
}
