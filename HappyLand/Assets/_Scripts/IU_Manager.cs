using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IU_Manager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textAmmoText;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        coin.SetActive(false);
    }

    public void UpdateAmmo(int count)
    { 
       _textAmmoText.text = "Ammo: " + count; 
    }

    public void CollectCoin()
    {
        coin.SetActive(true);
    }

    public void PaywithCoin()
    {
        coin.SetActive(false);
    }
}
