using UnityEngine;

// Is extended for MonoBehaviour
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 1;
    [SerializeField] private int damage = 1;
        
    public int GetDamage() { return damage; }

    public void SetDamage(int damage) { this.damage = Mathf.Abs(damage); }
}
