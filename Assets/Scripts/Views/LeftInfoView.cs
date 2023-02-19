using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LeftInfoView : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TMP_Text _infoTextMeshPro;

    private IEnumerator _positionChangerCoroutine = null;

    private Action _onEndPanelEffect = null;

    private Vector2 _outCameraViewPositionOfPanel = new Vector2(-200, 135);

    private bool _isEffectOfPanelInProgress = false;


    public void ShowInfoAsync(string newText, Action onEnd = null)
    {
        _infoTextMeshPro.text = newText;
        _onEndPanelEffect = onEnd;
        _isEffectOfPanelInProgress = true;

        _positionChangerCoroutine = ChangePositionInfo(onEnd: () => 
        { 
            onEnd?.Invoke();
        });

        StartCoroutine(_positionChangerCoroutine);
    }

    public void SkipPanelEffect()
    {
        if (_isEffectOfPanelInProgress)
        {
            _isEffectOfPanelInProgress = false;

            StopCoroutine(_positionChangerCoroutine);
            _infoPanel.GetComponent<RectTransform>().anchoredPosition = _outCameraViewPositionOfPanel;
            _onEndPanelEffect?.Invoke();
            _onEndPanelEffect = null;
        }
    }

    public bool IsEffectOfPanelInProgress()
    {
        return _isEffectOfPanelInProgress;
    }


    private IEnumerator ChangePositionInfo(Action onEnd = null){
        int secondsOfPanelTranslation = 1;
        int secondsHoldInfo = 3;

        int yPosition = 135;
        Vector2 outCameraViewPositionOfPanel = new Vector2(-200, yPosition);
        Vector2 inCameraViewPositionOfPanel = new Vector2(213, yPosition);

        for (float t = 0; t < 1; t += Time.deltaTime / secondsOfPanelTranslation)
        {
            _infoPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(outCameraViewPositionOfPanel, inCameraViewPositionOfPanel, t);
            yield return null;
        }

        yield return new WaitForSeconds(secondsHoldInfo);

        for (float t = 0; t < 1; t += Time.deltaTime / secondsOfPanelTranslation)
        {
            _infoPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(inCameraViewPositionOfPanel, outCameraViewPositionOfPanel, t);
            yield return null;
        }
        
        _isEffectOfPanelInProgress = false;

        _onEndPanelEffect?.Invoke();
    }

    private IEnumerator ChangePositionInfoOld()
    {
        int secondsHoldInfo = 2;
        int yPosition = 165;
        Vector2 startPositionOfPanel = new Vector2(-200, yPosition);
        Vector2 endPositionOfPanel = new Vector2(213, yPosition);

        int secondsOfEffect = 1;
        float secondsWaitForNewIteration = 0.02f;
        float countIterations = secondsOfEffect / secondsWaitForNewIteration;
        float xPositionForOneIteration = (Math.Abs(startPositionOfPanel.x) + endPositionOfPanel.x) / countIterations;

        _infoPanel.GetComponent<RectTransform>().anchoredPosition = startPositionOfPanel;

        float restIterations = countIterations;

        while (restIterations > 0)
        {
            _infoPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2 (_infoPanel.GetComponent<RectTransform>().anchoredPosition.x + xPositionForOneIteration, yPosition);
            // _infoPanel.transform.localPosition = endPositionOfPanel;
            restIterations--;

            yield return new WaitForSeconds(secondsWaitForNewIteration);
        }

        yield return new WaitForSeconds(secondsHoldInfo);

        restIterations = countIterations;

        while (restIterations > 0)
        {
            _infoPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2 (_infoPanel.GetComponent<RectTransform>().anchoredPosition.x - xPositionForOneIteration, yPosition);
            // _infoPanel.transform.localPosition = endPositionOfPanel;
            restIterations--;

            yield return new WaitForSeconds(secondsWaitForNewIteration);
        }
    }
}
