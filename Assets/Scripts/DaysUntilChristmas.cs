using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DaysUntilChristmas : MonoBehaviour
{
    [SerializeField] private TMP_Text _daysUntilChristmasTextMeshPro;

    private int _daysUntilChristmas = 20;

    private void Awake()
    {
        _daysUntilChristmasTextMeshPro.text = _daysUntilChristmas.ToString();
    }


    public int GetDaysUntilChristmasValue()
    {
        return _daysUntilChristmas;
    }

    public int Decrease(int countDaysToDecrease = 1)
    {
        _daysUntilChristmas = _daysUntilChristmas - countDaysToDecrease;

        if (_daysUntilChristmas < 0) _daysUntilChristmas = 0;
        
        _daysUntilChristmasTextMeshPro.text = _daysUntilChristmas.ToString();

        return _daysUntilChristmas;
    }
}
