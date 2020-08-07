using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamond);
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

    public void SelectItem(int index)
    {
        switch (index)
        {
            case 0:
                UIManager.Instance.UpdateSelectionItem(92);
                break;
            case 1:
                UIManager.Instance.UpdateSelectionItem(-16);
                break;
            case 2:
                UIManager.Instance.UpdateSelectionItem(-124);
                break;
        }
    }
}
