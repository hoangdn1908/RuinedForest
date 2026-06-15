using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [Header("Trajectory")]
    [SerializeField] private float travelTime = 1f;
    [SerializeField] private float arcHeight = 2f;
    [SerializeField] private float explosionDuration = 0.2f;
    [SerializeField] private Animator animator;
    private ObjectPool pool;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float timer;
    public bool isExploding {  get; private set; }

    #region Initial
    public void Initialize(Vector3 startPos, Vector3 targetPos, ObjectPool pool)
    {
        this.startPos = startPos;
        this.targetPos = targetPos;
        this.pool = pool;
        ResetBomb();
    }

    public void ResetBomb()
    {
        timer = 0f;
        isExploding = false;
        animator.SetBool("isExploding", false);
        transform.position = startPos;
    }
    #endregion

    private void Update()
    {
        if (isExploding) return;

        UpdateTimer();
        if (HasReachTarget())
        {
            Explosion();
            return;
        }
        MoveAlongTrajectory();
    }

    #region Logic
    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    private float GetNormalizedTime()
    {
        return timer / travelTime;
    }

    private bool HasReachTarget()
    {
        return GetNormalizedTime() >= 2f;
    }

    private Vector3 CalculateHorizontalPosition(float direction)
    {
        return Vector3.Lerp(startPos, targetPos, direction);
    }

    private float CalculateVerticalPosition(float direction)
    {
        return 4f * arcHeight * direction * (1f - direction);
    }

    private Vector3 CalculatePosition()
    {
        float direction = GetNormalizedTime();
        Vector3 position = CalculateHorizontalPosition(direction);
        position.y = CalculateVerticalPosition(direction);
        return position;
    }

    private void MoveAlongTrajectory()
    {
        transform.position = CalculatePosition();
    }
    #endregion

    #region Explosion
    public void Explosion()
    {
        if (isExploding) return;
        isExploding = true;
        animator.SetBool("isExploding", true);
        StartCoroutine(WaitAndReturnToPool());
    }

    private IEnumerator WaitAndReturnToPool()
    {
        yield return new WaitForSeconds(explosionDuration);
        pool.ReturnToPool(gameObject);
    }

    #endregion
}
