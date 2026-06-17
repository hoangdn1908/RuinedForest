using UnityEngine;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    /*public CoinUi coinUi {  get; private set; }*/
    //public PlayerHealthBarUI playerHealthBarUI { get; private set; }
    public GameObject pausePanel;


    private void Awake()
    {
        SetSingleTon();
        InitializeUI();
    }

    private void InitializeUI() 
    {
        //coinUi = GetComponentInChildren<CoinUi>();
        //playerHealthBarUI = GetComponentInChildren<PlayerHealthBarUI>();
    }

    private void SetSingleTon() 
    {
        Instance = this;
    }

    public void SetPausePanelActive(bool value) 
    {
        pausePanel.SetActive(value);
    }
}
