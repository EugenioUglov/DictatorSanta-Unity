using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    private bool _isTypingText = false;
    private IEnumerator _typeTextCoroutine;
    private string _textToShow = "";
    private TMP_Text _textMeshProToShowText;
    private Action _onTextShowed = null;

    public void StartType(string inputText, TMP_Text textMeshProToShowText, Action onTextShowed = null)
    {
        textMeshProToShowText.text = "";
        _textToShow = inputText;
        _textMeshProToShowText = textMeshProToShowText;
        _onTextShowed = onTextShowed;

        _typeTextCoroutine = TypeTextCoroutine(
            inputText, 
            textMeshProToShowText, 
            onTextShowed
        );

        StartCoroutine(_typeTextCoroutine);
    }

    private IEnumerator TypeTextCoroutine(string inputText, TMP_Text textMeshProToShowText, Action onTextShowed = null)
    {
        _isTypingText = true;


        foreach (char letter in inputText.ToCharArray())
        {
            textMeshProToShowText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        
        onTextShowed?.Invoke();
        _isTypingText = false;        
    }

    public void SkipTypingText()
    {
        StopCoroutine(_typeTextCoroutine);

        _textMeshProToShowText.text = _textToShow;
        _onTextShowed?.Invoke();
    }
    
    // public void ShowText(string inputText, TMP_Text textMeshProToShowText)
    // {
    //     StopCoroutine(_typeTextCoroutine);
    //     textMeshProToShowText.text = inputText;

    //     _isTypingText = false;
    // }
}
