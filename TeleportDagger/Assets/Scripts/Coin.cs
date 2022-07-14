using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] private Text coinText;
    public int coin;

    private void Start()
    {
        coinText.text = "" + 0;
        coin = 0;
    }

    public void PickUpCoin()
    {
        coin++;
        coinText.text = "" + coin;
    }
}
