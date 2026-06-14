using UnityEngine;

public class EnemyBombThrower : MonoBehaviour
{
    [SerializeField] private ObjectPool bombPool;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform player;

    public void ThrowBomb()
    {
        BombController bomb = bombPool.GetFromPool().GetComponent<BombController>();
        bomb.Initialize(startPos.position, player.position, bombPool);
    }
}
