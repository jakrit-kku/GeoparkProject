using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class btnAnimName
{
    public string targetAnimName;
    public Button button;

    public void setSelfCol(Color _newCol)
    {
        button.image.color = _newCol;
    }

}

public class AnimationDino : MonoBehaviour
{
    [SerializeField] Color enableCol;
    [SerializeField] Color disableCol;

    [SerializeField] Animator GreenDinoAnimator;
    [SerializeField] Animator YellowDinoAnimator;
    [SerializeField] btnAnimName[] allGreenButton;
    [SerializeField] btnAnimName[] allYellowButton;
    [SerializeField] Slider SpeedSlider;
    private string nowState;

    private void Start() 
    {

        SpeedSlider.onValueChanged.AddListener((v) => 
        {
            GreenDinoAnimator.speed = v;
        });

        foreach(btnAnimName _b in allGreenButton)
        {
            _b.button.onClick.AddListener(delegate{setGreenAnim(_b);});
        }

        foreach(btnAnimName _b in allYellowButton)
        {
            _b.button.onClick.AddListener(delegate{setYellowAnim(_b);});
        }
    }


    public void setGreenAnim(btnAnimName targetObj)
    {
        foreach (btnAnimName b in allGreenButton)
        {
            b.setSelfCol(disableCol);
        }
        changeAnimState(targetObj.targetAnimName, GreenDinoAnimator);

        // GreenDinoAnimator.SetTrigger(targetObj.targetAnimName);

        targetObj.setSelfCol(enableCol);
    }

    public void setYellowAnim(btnAnimName targetObj)
    {
        foreach (btnAnimName b in allYellowButton)
        {
            b.button.interactable = false;
        }

        changeAnimState(targetObj.targetAnimName, YellowDinoAnimator);

        // YellowDinoAnimator.SetTrigger(targetObj.targetAnimName);
        targetObj.setSelfCol(enableCol);
    }

    public void changeAnimState(string newS, Animator _a)
    {
        if(nowState == newS) return;
        Debug.Log(newS);
        _a.Play(newS);
        nowState = newS;
    }



    // public void greenWalk()
    // {
    //     GreenDinoAnimator.SetTrigger("Walk");
    // }


}
