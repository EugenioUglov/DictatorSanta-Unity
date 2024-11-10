using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Background : MonoBehaviour
{
    [SerializeField] private BackgroundStruct[] _backgroundStructs;
    [SerializeField] private Sprite[] _randomImages;
    // [SerializeField] private SpriteRenderer _background;
    private Image _backgroundImage;
    private Queue _indexesOfRandomImagesQueue;


    
    private void Awake()
    {
        _backgroundImage = GetComponent<Image>();
        int[] _indexesOfRandomImages = GenerateNonRepeatingRandomNumbers(_randomImages.Length, 0, _randomImages.Length - 1);
        _indexesOfRandomImagesQueue = new Queue(_indexesOfRandomImages);
    }

    public void ShowRandomBackground()
    {
        if (_indexesOfRandomImagesQueue.Count == 0) 
        {
            int[] _indexesOfRandomImages = GenerateNonRepeatingRandomNumbers(_randomImages.Length, 0, _randomImages.Length - 1);
            _indexesOfRandomImagesQueue = new Queue(_indexesOfRandomImages);
        }

        _backgroundImage.sprite = _randomImages[(int)_indexesOfRandomImagesQueue.Dequeue()];
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
   
    private int[] GenerateNonRepeatingRandomNumbers(int arraySize, int minValue, int maxValue)
    {
        if (arraySize > (maxValue - minValue + 1))
        {
            throw new ArgumentException("Array size cannot be greater than the range of random numbers.");
        }

        System.Random random = new System.Random();
        HashSet<int> uniqueNumbers = new HashSet<int>();

        while (uniqueNumbers.Count < arraySize)
        {
            int randomNumber = random.Next(minValue, maxValue + 1);
            uniqueNumbers.Add(randomNumber);
        }

        // Convert HashSet to an array
        int[] randomArray = new int[arraySize];
        uniqueNumbers.CopyTo(randomArray);
        // int[] randomArray = uniqueNumbers.ToArray();

        return randomArray;
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
