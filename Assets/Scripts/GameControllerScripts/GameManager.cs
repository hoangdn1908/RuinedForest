using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public GameStates currentState {  get; private set; }

    private void Awake()
    {
        SetSingleTon();
    }

    private void Start()
    {
        ChangeGameState(GameStates.Playing);
    }

    private void Update()
    {
        HandlePauseInput();
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += HandlePlayerDeath;
        FinishedPointController.OnReachedPoint += HandlePlayerReachedFinishedPoint;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= HandlePlayerDeath;
        FinishedPointController.OnReachedPoint -= HandlePlayerReachedFinishedPoint;
    }
    private void SetSingleTon() 
    {
        Instance = this;
    }

    public void ChangeGameState(GameStates state) 
    {
        currentState = state;
        switch (currentState) 
        {
            case GameStates.Playing:
                EnterPlayingState();
                break;
            case GameStates.Pause:
                EnterPauseState();
                break;
            case GameStates.Lose:
                EnterLoseState();
                break;
            case GameStates.Win:
                EnterWinState();
                break;
        }
    }

    #region Enter game State
    public void EnterPlayingState() 
    {
        Time.timeScale = 1.0f;
        UiController.Instance.SetPausePanelActive(false);
        UiController.Instance.SetLosePanelActive(false);
        UiController.Instance.SetWinPanelActive(false);
    }

    private void EnterPauseState() 
    {
        Time.timeScale = 0f;
        UiController.Instance.SetPausePanelActive(true);
        UiController.Instance.SetLosePanelActive(false);
        UiController.Instance.SetWinPanelActive(false);
    }

    private void EnterLoseState() 
    {
       StartCoroutine(DelayLoseState());
    }

    private IEnumerator DelayLoseState() 
    {
        Time.timeScale = 1f; 
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        UiController.Instance.SetPausePanelActive(false);
        UiController.Instance.SetLosePanelActive(true);
        UiController.Instance.SetWinPanelActive(false);
    }

    private void EnterWinState()
    {
        Time.timeScale = 0f;
        UiController.Instance.SetPausePanelActive(false);
        UiController.Instance.SetLosePanelActive(false);
        UiController.Instance.SetWinPanelActive(true);
    }
    #endregion

    #region Handle game state
    private void HandlePlayerDeath()
    {
        ChangeGameState(GameStates.Lose);
    }

    private void HandlePauseInput() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ChangeGameState(GameStates.Pause);
        }
    }

    private void HandlePlayerReachedFinishedPoint() 
    {
        ChangeGameState(GameStates.Win);
    }
    #endregion

}
