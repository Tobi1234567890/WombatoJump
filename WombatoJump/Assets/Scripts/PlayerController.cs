using Assets.Scripts;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Rigidbody2D rig;

    public float MoveSpeed;
    public float JumpBoostMultiplier;

    void Start()
    {
        Instance = this;

        #region Mulitply Float Values

        MoveSpeed *= 100;

        #endregion
    }

    void FixedUpdate()
    {
        InputHandler();

        if (transform.position.y < PlatformSpawner.PlatformListSortedByVerticalPosition.First().transform.position.y - 10)
        {
            DeathManager.Instance.OnPlayerDeath();
        }
    }

    public void InputHandler()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 newPos = new Vector2(MoveSpeed * Time.deltaTime * horizontal, rig.velocity.y);
        rig.velocity = newPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && rig.velocity.y <= 0)
        {
            LeapPlayer(collision.gameObject.GetComponent<PlatformScript>().PlatformType);
        }
    }

    private void LeapPlayer(PlatformTypes platformType)
    {
        Vector2 velocityToLeap = Vector2.up * ((int)platformType * JumpBoostMultiplier * Time.deltaTime);
        rig.velocity.Set(velocityToLeap.x, Mathf.Min(rig.velocity.y, 50));
        rig.velocity = velocityToLeap;
    }
}
