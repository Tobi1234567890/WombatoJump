using UnityEngine;


public enum EnemeyType
{
    Archer,
    Fighter
}
public abstract class Enemy : MonoBehaviour
{
    public int Health;
    public int MovementSpeed;

}
