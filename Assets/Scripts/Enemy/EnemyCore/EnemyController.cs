using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Data
    public EnemyData EnemyData;
    #endregion

    #region Component
    public EnemyMovement enemyMovement {  get; private set; }
    public EnemyAnimation  enemyAnimation { get; private set; }
    #endregion

    #region State machine
    public EnemyStateMachine enemyStateMachine { get; private set; }
    #endregion

    private void Awake()
    {
        InitializeComponet();
        IninializeStateMachine();
    }

    private void Start()
    {
        enemyMovement.SetStartPos(transform.position);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void InitializeComponet() 
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void IninializeStateMachine() 
    {
        enemyStateMachine = new EnemyStateMachine();
    }
}
