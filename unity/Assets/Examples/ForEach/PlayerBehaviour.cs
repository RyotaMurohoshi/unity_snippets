using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    PlayerEvent onDead;
    public PlayerEvent OnDead { get { return onDead; } }

    int currentHp;
    Player player;

    public void SetData(Player player)
    {
        this.player = player;
        this.currentHp = player.MaxHp;
    }

    public void AddDamage(int damageAmount)
    {
        this.currentHp -= damageAmount;
        if(this.currentHp <= 0)
        {
            onDead.Invoke(this.player);
        }
    }
}
