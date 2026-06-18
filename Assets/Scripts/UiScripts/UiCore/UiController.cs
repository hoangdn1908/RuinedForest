using UnityEngine;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    public CoinUi coinUi;
    public PlayerHealthBarUI playerHealthBarUI;
    public GameObject pausePanel;
    public GameObject losePanel;
    public GameObject winPanel;


    private void Awake()
    {
        SetSingleTon();
    }

    private void SetSingleTon() 
    {
        Instance = this;
    }

    public void SetPausePanelActive(bool value) 
    {
        pausePanel.SetActive(value);
    }

    public void SetLosePanelActive(bool value) 
    {
        losePanel.SetActive(value);
    }

    public void SetWinPanelActive(bool value) 
    {
        winPanel.SetActive(value);
    }
}
