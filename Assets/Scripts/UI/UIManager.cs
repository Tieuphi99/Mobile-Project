using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                Debug.LogError("UI Manager is Null!");
            }

            return _instance;
        }
    }

    public Text shopGemCountText;
    public Text hUDGemCountText;
    public Image selectionImage;
    public List<Image> lifeUnitImages;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateSelectionItem(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition =
            new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int gemCount)
    {
        shopGemCountText.text = $"{gemCount}G";
    }

    public void UpdateGemCount(int gem)
    {
        hUDGemCountText.text = $"{gem}";
    }

    public void UpdateLives(int lifeUnitIndex)
    {
        if (lifeUnitIndex < 0)
        {
            return;
        }

        lifeUnitImages[lifeUnitIndex].enabled = false;
    }
}