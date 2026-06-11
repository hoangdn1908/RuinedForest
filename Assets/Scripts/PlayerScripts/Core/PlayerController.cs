using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    #region Data
    public PlayerData PlayerData;
    #endregion

    #region Component
    public PlayerMovement playerMovement {  get; private set; }
    public PlayerInput playerInput { get; private set; }
    public PlayerAnimation playerAnimation {  get; private set; }
    public PlayerGroundDetector playerGroundDetector { get; private set; }
    public PlayerEffects playerEffects { get; private set; }
    public PlayerHealth playerHealth { get; private set; }
    #endregion

    #region State Machine
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState playerIdleState {  get; private set; }
    public PlayerRunState playerRunState { get; private set; }
    public PlayerJumpState playerJumpState { get; private set; }
    public PlayerFallState playerFallState { get; private set; }
    public PlayerAttackState playerAttackState { get; private set; }
    public PlayerDeathState  PlayerDeathState { get; private set; }
    #endregion

    private void Awake()
    {
        InitializeComponent();
        InitializeStateMachine();
        playerHealth.SetCurrentHealth(PlayerData.maxHealth);
    }

    private void Start()
    {
        InitialieIdleState();
    }
    private void Update()
    {
        ReadInput();
        UpdateStateLogic();
    }

    private void FixedUpdate()
    {
        UpdateStatePhysic();
    }

    private void InitializeComponent() 
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInput = GetComponent<PlayerInput>();
        playerGroundDetector = GetComponent<PlayerGroundDetector>();
        playerEffects = GetComponent<PlayerEffects>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void InitializeStateMachine() 
    {
        playerStateMachine = new PlayerStateMachine();
        playerIdleState = new PlayerIdleState(this, playerStateMachine);
        playerRunState = new PlayerRunState(this, playerStateMachine);
        playerJumpState = new PlayerJumpState(this, playerStateMachine);
        playerFallState = new PlayerFallState(this, playerStateMachine);
        playerAttackState = new PlayerAttackState(this, playerStateMachine);
        PlayerDeathState = new PlayerDeathState(this, playerStateMachine);
    }

    private void InitialieIdleState() 
    {
        playerStateMachine.InitializeState(playerIdleState);
    }

    private void UpdateStateLogic() 
    {
        playerStateMachine.currentState.LogicUpdate();
    }

    private void ReadInput() 
    {
        playerInput.ReadInput();
        playerStateMachine.currentState.HandleInput();
    }

    private void UpdateStatePhysic() 
    {
        playerStateMachine.currentState.PhysicUpdate();
    }
}
