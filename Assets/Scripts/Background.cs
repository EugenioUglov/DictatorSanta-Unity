using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Background : MonoBehaviour
{
    [SerializeField] private BackgroundStruct[] _backgroundStructs;
    // [SerializeField] private SpriteRenderer _background;
    private Image _backgroundImage;

    
    private void Awake()
    {
        _backgroundImage = GetComponent<Image>();
    }


    public void ShowBackgroundByName(string name)
    {
        foreach (BackgroundStruct backgroundStruct in _backgroundStructs)
        {
            if (backgroundStruct.GetName() == name)
            {
                _backgroundImage.sprite = backgroundStruct.GetSprite();
                // _backgroundImage.image = backgroundStruct.GetSprite();
                break;
            }
        }
    }
    
    [Serializable]
    private class BackgroundStruct
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;

        public string GetName() => _name;
        public Sprite GetSprite() => _sprite;
    }
}
