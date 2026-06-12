using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Idle")]
    public float idleDuration;
    [Header("Move")]
    public float moveSpeed;
    [Header("Patrol")]
    public float patrolDistance;
    [Header("Dectection")]
    public float detectionRange;
    [Header("Attack")]
    public float attackRange;
    public float attackDuration;
    [Header("Health")]
    public float maxHealth;
}
