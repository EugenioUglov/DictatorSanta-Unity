using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Employees : MonoBehaviour
{
    [SerializeField] private TMP_Text _happinessValueTextMeshPro;
    [SerializeField] private TMP_Text _countEmployeesTextMeshPro;
    [SerializeField] private ValueChangerView _valueChangerView;

    private int _happinessValue = 0;
    private int _countEmployees = 10;
    private int _countGoldToPayForOneEmployee = 100;
    private bool _isEffectValueChangerInProgress = false;

    public int GetHappinessValue() => _happinessValue;
    public int GetCountEmployees() => _countEmployees;

    private void Awake()
    {
        _happinessValueTextMeshPro.text = _happinessValue.ToString();
        _countEmployeesTextMeshPro.text = _countEmployees.ToString();
    }

    public int AddHappinessValueAsync(int additionalHappinessValue, Action onEnd = null)
    {
        _happinessValue += additionalHappinessValue;
        _isEffectValueChangerInProgress = true;

        _valueChangerView.AddValueAsync
        (
            element: _happinessValueTextMeshPro, 
            increaserValue: additionalHappinessValue, 
            onEnd: () => {
                _isEffectValueChangerInProgress = false;
                _happinessValueTextMeshPro.text = _happinessValue.ToString();

                onEnd?.Invoke();
            }
        );


        return _happinessValue;
    }

    public int DecreaseHappinessValueAsync(int decreaserValue, Action onEnd = null)
    {
        _happinessValue -= decreaserValue;
        _isEffectValueChangerInProgress = true;

        _valueChangerView.DecreaseValueAsync
        (
            element: _happinessValueTextMeshPro, 
            decreaserValue: decreaserValue, 
            onEnd: () => {
                _isEffectValueChangerInProgress = false;

                _happinessValueTextMeshPro.text = _happinessValue.ToString();

                onEnd?.Invoke();
            }
        );

        return _happinessValue;
    }
    
    public int AddCountOfEmployees(int additionalCountEmployees)
    {
        _countEmployees += additionalCountEmployees;

        if (_countEmployees < 0) _countEmployees = 0;

        _countEmployeesTextMeshPro.text = _countEmployees.ToString();

        return _countEmployees;
    }

    public int AddCountGoldToPayForOneEmployee(int additionalGold)
    {
        _countGoldToPayForOneEmployee += additionalGold;

        return _countGoldToPayForOneEmployee;
    }

    public void SkipEffectValueChanger()
    {
        if (_isEffectValueChangerInProgress)
        {
            _valueChangerView.SkipEffect();
        }
    }

    public int GetCountGoldToPayForOneEmployee()
    {
        return _countGoldToPayForOneEmployee;
    }

    public bool IsEffectValueChangerInProgress() 
    {
        return _isEffectValueChangerInProgress;
    }
}
