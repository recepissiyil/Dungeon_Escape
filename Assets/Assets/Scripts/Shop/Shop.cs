using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;
    private Player _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag== "Player")
        {
           _player =other.GetComponent<Player>();
            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }
            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }
    public void SelectItem(int item)
    {
        //Debug.Log(item+". Item was selected");
        switch (item)
        {
            case 0://sword
                UIManager.Instance.UpdateShopSelection(92);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1://Boots
                UIManager.Instance.UpdateShopSelection(-14);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2: //Key
                UIManager.Instance.UpdateShopSelection(-95);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }
    public void BuyItem()
    {   
        if (_player.diamonds>=currentItemCost)
        {
            //3.Butona basarsan GameManager'deki HasKeyToCastle değerini true olarak değiştir
            if (currentSelectedItem==2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamonds -= currentItemCost;
            Debug.Log("Seçtiğin Item" + currentSelectedItem);
            Debug.Log("Kalan Altın="+_player.diamonds);
           
        }
        else
        {
            Debug.Log("You do not have enough gem .Closing Shop");
            shopPanel.SetActive(false);
           
        }
    }
}
