using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]

    public TextMeshProUGUI CoinText;
    int coin;

    private void Awake()
    {
        if (this.gameObject != null)
        {
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();


    }

    public void UpdateScore(int _coin)
    {
        coin += _coin;
        OverallCoinCount.coincount += 1;
        CoinText.text = "Coins: " + coin.ToString();
    }

    
    


}


    

    


