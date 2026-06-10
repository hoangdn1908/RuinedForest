using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Data
    public EnemyData EnemyData;
    #endregion

    #region Component
    public EnemyMovement enemyMovement {  get; private set; }
    public EnemyAnimation  enemyAnimation { get; private set; }
    public EnemyDetection enemyDetection { get; private set; }
    #endregion

    #region State machine
    public EnemyStateMachine enemyStateMachine { get; private set; }
    public EnemyIdleState enemyIdleState { get; private set; }
    public EnemyPatrolState enemyPatrolState { get; private set; }
    public EnemyChaseState enemyChaseState { get; private set; }
    public EnemyAttackState enemyAttackState { get; set; }
    #endregion

    private void Awake()
    {
        InitializeComponet();
        IninializeStateMachine();
    }

    private void Start()
    {
        enemyMovement.SetStartPos(transform.position);
        enemyStateMachine.InitializeState(enemyIdleState);
    }

    private void Update()
    {
        UpdateStateLogic();
    }

    private void FixedUpdate()
    {
        UpdateStatePhysic();
    }

    private void InitializeComponet() 
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        enemyDetection = GetComponent<EnemyDetection>();
    }

    public virtual void IninializeStateMachine() 
    {
        enemyStateMachine = new EnemyStateMachine();
        enemyIdleState = new EnemyIdleState(this, enemyStateMachine);
        enemyPatrolState = new EnemyPatrolState(this,enemyStateMachine);
        enemyChaseState = new EnemyChaseState(this,enemyStateMachine);
    }

    private void UpdateStateLogic()
    {
        enemyStateMachine.currentState.LogicUpdate();    
    }

    private void UpdateStatePhysic() 
    {
        enemyStateMachine.currentState.PhysicUpdate();
    }
}
