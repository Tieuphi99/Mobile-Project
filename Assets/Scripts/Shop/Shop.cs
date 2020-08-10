using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    private int _currentSelectedItem;
    private int _currentSelectedItemPrice;
    private Player _player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamond);
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
                _currentSelectedItem = 0;
                _currentSelectedItemPrice = 200;
                break;
            case 1:
                UIManager.Instance.UpdateSelectionItem(-16);
                _currentSelectedItem = 1;
                _currentSelectedItemPrice = 400;
                break;
            case 2:
                UIManager.Instance.UpdateSelectionItem(-124);
                _currentSelectedItem = 2;
                _currentSelectedItemPrice = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.diamond >= _currentSelectedItemPrice)
        {
            // buy
            if (_currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamond -= _currentSelectedItemPrice;
            shopPanel.SetActive(false);
        }
        else
        {
            // no buy
            shopPanel.SetActive(false);
        }
    }
}
