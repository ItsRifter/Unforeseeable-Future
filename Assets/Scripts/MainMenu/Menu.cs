using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Player Quit");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
        OverallCoinCount.coincount = 0;
    }

    private void Start()
    {
        try
        {
            CoinText.text = "On your adventures you have collected : " + OverallCoinCount.coincount.ToString() + " shreds";
        }
        catch
        {
            print("Not correct scene to update cointext");
        }
        try
        {

            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        }
        catch
        {
            Debug.Log("Music Manager doesnt exist here");
        }
    }
}
