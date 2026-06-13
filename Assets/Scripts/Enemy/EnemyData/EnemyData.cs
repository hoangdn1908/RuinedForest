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
    public bool canPatrol;
    [Header("Chase")]
    public bool canChase;
    [Header("Dectection")]
    public float detectionRange;
    [Header("Attack")]
    public float attackRange;
    public float attackDuration;
    public float attackDamage;
    [Header("Health")]
    public float maxHealth;
}
