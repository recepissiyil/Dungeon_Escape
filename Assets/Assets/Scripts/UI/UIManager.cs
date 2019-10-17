using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is null");
            }
            return _instance;
        }
    }
    public Text playerGemCountText;
    public Image selectionImg;
    public Text gemCountText;
    public Image[] healthBars;
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = ""+gemCount+"G";

    }
    private void Awake()
    {
        _instance = this;
    }
    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }
    public void UpdateGemCount(int count)
    {
        gemCountText.text =""+ count;
    }
    //livesRemainig Player scriptinde Health olarak atandı
    //Player Start'a Health'ı 4 olarak atadık
    // döngü 4 sefer dönecek
    //Düşmanın her bir vuruşunda canı 1 eksilecek ve barlardan biri eksilecek
    public void UpdateLives(int livesRemaning)
    {
        for(int i=0; i <= livesRemaning; i++)
        {
            if (i == livesRemaning)
            {
                healthBars[i].enabled = false;
            }
        }
    }

}
