using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Run")]
    public float runSpeed = 5f;
    [Header("Jump")]
    public float jumpForce = 12f;
}
