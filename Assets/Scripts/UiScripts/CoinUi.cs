using TMPro;
using UnityEngine;

public class CoinUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coinCount = 0;

    private void OnEnable()
    {
        CoinController.OnCoinSelected += AddCoin;
    }

    private void OnDisable()
    {
        CoinController.OnCoinSelected -= AddCoin;
    }
    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount) 
    {
        coinCount += amount;
        UpdateUI();
    }

    private void UpdateUI() 
    {
        coinText.text = coinCount.ToString();
    }
}
