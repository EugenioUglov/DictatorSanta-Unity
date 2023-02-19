using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldTextMeshPro;
    [SerializeField] private ValueChangerView _valueChangerView;

    private int _countGold = 25000;

    private bool _isEffectValueChangerInProgress = false;

    private IEnumerator _valueChangerCoroutine = null;
    
   
    public int AddGold(int additionalGold, Action onEnd = null)
    {
        _countGold += additionalGold;
            
        _goldTextMeshPro.text = _countGold.ToString();
        _isEffectValueChangerInProgress = true;

        _valueChangerView.AddValueAsync(
            element: _goldTextMeshPro,
            increaserValue: additionalGold,
            onEnd: () => {
                _isEffectValueChangerInProgress = false;
                _goldTextMeshPro.text = _countGold.ToString();
            
                onEnd?.Invoke();
            }
        );
        
        return _countGold;
    }

    public int DecreaseGold(int decreaserValue, Action onEnd = null)
    {
        _countGold -= decreaserValue;
        if (_countGold < 0) _countGold = 0;
        _isEffectValueChangerInProgress = true;

        _valueChangerView.DecreaseValueAsync(
            element: _goldTextMeshPro, 
            decreaserValue: decreaserValue, 
            onEnd: () => {
                _isEffectValueChangerInProgress = false;
                _goldTextMeshPro.text = _countGold.ToString();
            
                onEnd?.Invoke();
            }
        );

        return _countGold;
    }

    public void SkipEffectValueChanger()
    {
        if (_isEffectValueChangerInProgress)
        {
            _valueChangerView.SkipEffect();
        }
    }



    public int GetCountGold()
    {
        return _countGold;
    }

    public bool IsEffectValueChangerInProgress() 
    {
        return _isEffectValueChangerInProgress;
    }
}
