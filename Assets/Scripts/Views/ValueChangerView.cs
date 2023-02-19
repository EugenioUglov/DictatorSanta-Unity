using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class ValueChangerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _additionalValueTextMeshPro;

    private IEnumerator _additionalValueDiactivatorCoroutine;
    private Action _onEndEffect = null;


    private void Awake() {
        _additionalValueTextMeshPro.enabled = false;
    }


    public string AddValueAsync(TMP_Text element, int increaserValue, Action onEnd = null)
    {
        // int newValue = int.Parse(element.text) + increaserValue;
        Color32 greenColor = new Color32(112, 200, 106, 255);
        string textOfEffect = "+" + increaserValue.ToString();
        _onEndEffect = onEnd;

        ValueChangerAsync(element: element, textOfEffect: textOfEffect, textColor: greenColor, onEnd: onEnd);
        
        return _additionalValueTextMeshPro.text;
    }
    
    public string DecreaseValueAsync(TMP_Text element, int decreaserValue, Action onEnd = null)
    {
        Color32 redColor = new Color32(222, 41, 22, 255);
        string textOfEffect = "-" + decreaserValue.ToString();
        _onEndEffect = onEnd;


        ValueChangerAsync(element: element, textOfEffect: textOfEffect, textColor: redColor, onEnd: onEnd);

        return _additionalValueTextMeshPro.text;
    }

    public void SkipEffect()
    {
        StopCoroutine(_additionalValueDiactivatorCoroutine);
        _additionalValueTextMeshPro.enabled = false;
        _onEndEffect?.Invoke();
    }


    private string ValueChangerAsync(TMP_Text element, string textOfEffect, Color32 textColor, Action onEnd = null)
    {
        // float xOffset = LayoutUtility.GetPreferredWidth(element.rectTransform) / 2;
        // float yOffset = LayoutUtility.GetPreferredHeight(element.rectTransform) / 2;
        
        float xOffset = (Screen.width - element.transform.position.x) / 30;
        float yOffset = (Screen.height - element.transform.position.y) / 7;

        // int newValue = int.Parse(element.text) - decreaserValue;

        _additionalValueTextMeshPro.color = textColor;
        _additionalValueTextMeshPro.text = textOfEffect;
        _additionalValueTextMeshPro.transform.position = new Vector2(element.transform.position.x + xOffset, element.transform.position.y + yOffset);
        // _additionalValueTextMeshPro.GetComponent<RectTransform>().anchoredPosition = new Vector2(element.transform.position.x + xOffset, element.transform.position.y + yOffset);
        _additionalValueDiactivatorCoroutine = DeactivateAdditionalValueCoroutine(
            textColor: textColor,
            endPosition: element.transform.position,
            onEnd: () => {
                onEnd?.Invoke();
            }
        );

        StartCoroutine(_additionalValueDiactivatorCoroutine);

        return _additionalValueTextMeshPro.text;
    }

    private IEnumerator DeactivateAdditionalValueCoroutine(Color32 textColor, Vector2 endPosition, Action onEnd = null)
    {
        int xOffset = 40;
        float currentTransparence = 255;
        float secondsOfEffect = 0.5f;
        int secondsHoldOnActiveText = 1;
        float secondsWaitForNewIteration = 0.02f;
        float secondsForAppearingText = 1f;
        float countIterations = secondsOfEffect / secondsWaitForNewIteration;
        float transparenceDecreaser = currentTransparence / countIterations;
        float positionXAdditionalPerFrame = (endPosition.x - _additionalValueTextMeshPro.transform.position.x) / countIterations;
        float positionYAdditionalPerFrame = (endPosition.y - _additionalValueTextMeshPro.transform.position.y) / countIterations;

        _additionalValueTextMeshPro.enabled = true;

        for (float t = 0; t < 1; t += Time.deltaTime / secondsForAppearingText)
        {
            _additionalValueTextMeshPro.color = new Color32(textColor.r, textColor.g, textColor.b, (byte)(t * 255));
            yield return null;
        }

        yield return new WaitForSeconds(secondsHoldOnActiveText);


        while (countIterations > 0) {
            _additionalValueTextMeshPro.transform.position = new Vector2
            (
                _additionalValueTextMeshPro.transform.position.x + positionXAdditionalPerFrame, 
                _additionalValueTextMeshPro.transform.position.y + positionYAdditionalPerFrame
            );

            currentTransparence -= transparenceDecreaser;

            _additionalValueTextMeshPro.color = new Color32(textColor.r, textColor.g, textColor.b, (byte)currentTransparence);

            countIterations--;

            yield return new WaitForSeconds(secondsWaitForNewIteration);
        }

        _additionalValueTextMeshPro.enabled = false;

        onEnd?.Invoke();
    } 
}
