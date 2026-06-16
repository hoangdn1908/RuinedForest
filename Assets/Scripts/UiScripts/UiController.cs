using UnityEngine;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    public CoinUi coinUi {  get; private set; }


    private void Awake()
    {
        SetSingleTon();
        InitializeUI();
    }

    private void InitializeUI() 
    {
        coinUi = GetComponentInChildren<CoinUi>();
    }

    private void SetSingleTon() 
    {
        Instance = this;
    }
}
