using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class TranScriptObj
{
    [SerializeField] Transform panel;

    [SerializeField] Button btnScpt;
    [SerializeField] Image btnImg;


    void setSelf(bool _btn, Color _newCol)
    {
        panel.gameObject.SetActive(_btn);
        btnImg.color = _newCol;
    }

    public void enableSelf(Color _col)
    {
        setSelf(true, _col);
    }

    public void disableSelf(Color _col)
    {
        setSelf(false, _col);
    }

}


public class TranscriptButton : MonoBehaviour
{

    [SerializeField] TranScriptObj greenT;
    [SerializeField] TranScriptObj yellowT;

    [SerializeField] Color enableCol;
    [SerializeField] Color disableCol;

    private void Start() 
    {
        greenSet(true);
        yellowSet(false);
    }

    public void greenSet(bool _state)
    {
        if(_state)
        {
            greenT.enableSelf(enableCol);
        }
        else
        {
            greenT.disableSelf(disableCol);
        }
    }

    public void yellowSet(bool _state)
    {
        if(_state)
        {
            yellowT.enableSelf(enableCol);
        }
        else
        {
            yellowT.disableSelf(disableCol);
        }
    }



}
