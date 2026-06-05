using System.Collections;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    #region Jump and Fall effect
    [Header("Jump and Fall")]
    [SerializeField] private Transform jumpDustSpawnPoint;
    [SerializeField] private Transform fallDustSpawnPoint;
    [Header("Pools")]
    [SerializeField] private ObjectPool jumpDustPool;
    [SerializeField] private ObjectPool landDustPool;
    [Header("Settings")]
    [SerializeField] private float jumpDustDuration = 0.2f;
    [SerializeField] private float landDustDuration = 0.2f;
    #endregion
    public void SpawnJumpDust()
    {
        SpawnDust(jumpDustPool, jumpDustSpawnPoint, jumpDustDuration);
    }

    public void SpawnLandDust()
    {
        SpawnDust(landDustPool, fallDustSpawnPoint, landDustDuration);
    }

    private void SpawnDust(ObjectPool dustPool, Transform dustSpawnPoint, float duration)
    {
        if (dustPool == null) return;
        Vector3 spawnPosition = dustSpawnPoint != null ? dustSpawnPoint.position : transform.position;
        GameObject dust = dustPool.GetFromPool();
        dust.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        StartCoroutine(ReturnDustToPool(dustPool, dust, duration));
    }

    private IEnumerator ReturnDustToPool(ObjectPool dustPool, GameObject dust, float duration)
    {
        yield return new WaitForSeconds(duration);

        dustPool.ReturnToPool(dust);
    }
}
