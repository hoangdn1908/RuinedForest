using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    #region Jump and Fall effect
    [Header("Jump and Fall")]
    [SerializeField] private Transform jumpDustSpawnPoint;
    [SerializeField] private Transform fallDustSpawnPoint;
    [Header("Prefabs")]
    [SerializeField] private GameObject jumpDustPrefab;
    [SerializeField] private GameObject landDustPrefab;
    [Header("Settings")]
    [SerializeField] private float destroyDelay = 2f;
    #endregion
    public void SpawnJumpDust()
    {
        SpawnDust(jumpDustPrefab, jumpDustSpawnPoint);
    }

    public void SpawnLandDust()
    {
        SpawnDust(landDustPrefab, fallDustSpawnPoint);
    }

    private void SpawnDust(GameObject dustPrefab, Transform dustSpawnPoint)
    {
        if (dustPrefab == null) return;

        Vector3 spawnPosition = dustSpawnPoint != null ? dustSpawnPoint.position : transform.position;
        GameObject dust = Instantiate(dustPrefab, spawnPosition, Quaternion.identity);
        Destroy(dust, destroyDelay);
    }
}
