using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [Header("Spawn Point")]
    [SerializeField] private Transform jumpDustSpawnPoint;
    [SerializeField] private Transform fallDustSpawnPoint;

    [Header("Prefabs")]
    [SerializeField] private GameObject jumpDustPrefab;
    [SerializeField] private GameObject landDustPrefab;

    [Header("Settings")]
    [SerializeField] private float destroyDelay = 2f;

    public void SpawnJumpDust()
    {
        SpawnDust(jumpDustPrefab);
    }

    public void SpawnLandDust()
    {
        SpawnDust(landDustPrefab);
    }

    private void SpawnDust(GameObject dustPrefab)
    {
        if (dustPrefab == null) return;

        Vector3 spawnPosition = dustSpawnPoint != null ? dustSpawnPoint.position : transform.position;
        GameObject dust = Instantiate(dustPrefab, spawnPosition, Quaternion.identity);
        Destroy(dust, destroyDelay);
    }
}
