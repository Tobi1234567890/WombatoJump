using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform GroundDetection;

    public float Speed;
    public float Distance;


    void Update()
    {
        MoveInDirection();
    }

    private void MoveInDirection()
    {
        transform.Translate(Vector2.right * (Speed * Time.deltaTime));
    }

    private void ChangeDirection()
    {
        transform.eulerAngles = new Vector3
        {
            y = transform.eulerAngles.y == 0 ? 180 : 0
        };
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            ChangeDirection();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Dead");
        }
    }
}
