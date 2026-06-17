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
        CheckPauseInput();
    }

    private void SetSingleTon() 
    {
        Instance = this;
    }

    private void ChangeGameState(GameStates state) 
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
        }
    }

    public void EnterPlayingState() 
    {
        Time.timeScale = 1.0f;
        UiController.Instance.SetPausePanelActive(false);
    }

    private void EnterPauseState() 
    {
        Time.timeScale = 0f;
        UiController.Instance.SetPausePanelActive(true);
    }

    private void CheckPauseInput() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ChangeGameState(GameStates.Pause);
        }
    }
}
