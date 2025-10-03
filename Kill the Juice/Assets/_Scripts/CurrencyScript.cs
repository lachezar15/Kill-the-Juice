using UnityEngine;
using TMPro;

public class CurrencyScript : MonoBehaviour
{
    public TMP_Text coinText;
    private int coinsCollected;

    private void OnCollisionEnter(Collision collision)
    {
        coinsCollected += 10;
        coinText.text = "Coins: " + coinsCollected.ToString();
        Destroy(gameObject);
    }
}
