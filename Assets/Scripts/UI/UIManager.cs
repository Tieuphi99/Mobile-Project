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

    public Text gemCountText;
    public Image selectionImage;

    public void UpdateSelectionItem(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition =
            new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int gemCount)
    {
        gemCountText.text = $"{gemCount.ToString()}G";
    }

    private void Awake()
    {
        _instance = this;
    }
}