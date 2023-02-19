using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOk : Dialogue
{
    [SerializeField] protected GameObject _buttonOk;
    
    private DialogueStruct _currentDialogueStruct;
    

    public void ShowDialogue(string name, string content, Action onClickButtonOk = null)
    {
        _currentDialogueStruct = new DialogueStruct(name, content, onClickButtonOk);

        _contentTextMeshPro.text = content;
        
        _buttonOk.SetActive(true);
    }
    
    public void OnClickButtonOk()
    {
        _contentTextMeshPro.text = "";
        _buttonOk.SetActive(false);
        _currentDialogueStruct.OnClickButtonOk();
    }
    
    
    private struct DialogueStruct
    {
        private string _name;
        [TextArea(3, 10)]
        private string _content;
        private Action _onClickButtonOk;

        
        public string GetName() => _name;
        public string GetContent() => _content;
        public Action OnClickButtonOk => _onClickButtonOk;
        
        public DialogueStruct(string name, string content, Action onClickButtonOk = null)
        {
            _name = name;
            _content = content;
            _onClickButtonOk = onClickButtonOk;
        }
    }
}
