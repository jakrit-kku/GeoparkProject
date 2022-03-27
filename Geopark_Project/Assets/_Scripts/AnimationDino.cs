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
    [SerializeField] Color G_enableCol;
    [SerializeField] Color G_disableCol;

    [SerializeField] Color Y_enableCol;
    [SerializeField] Color Y_disableCol;

    [SerializeField] Animator GreenDinoAnimator;
    [SerializeField] Animator YellowDinoAnimator;
    [SerializeField] btnAnimName[] allGreenButton;
    [SerializeField] btnAnimName[] allYellowButton;
    // [SerializeField] Slider SpeedSlider;
    private string nowState;

    private void Start() 
    {

        // SpeedSlider.onValueChanged.AddListener((v) => 
        // {
        //     GreenDinoAnimator.speed = v;
        // });

        foreach(btnAnimName _b in allGreenButton)
        {
            _b.button.onClick.AddListener(delegate{setGreenAnim(_b);});
        }

        foreach(btnAnimName _b in allYellowButton)
        {
            _b.button.onClick.AddListener(delegate{setYellowAnim(_b);});
        }

        setGreenAnim(allGreenButton[0]);
        setYellowAnim(allYellowButton[0]);


    }

    public void resetGreen()
    {
        setGreenAnim(allGreenButton[0]);
    }

    public void resetYellow()
    {
        setYellowAnim(allYellowButton[0]);
    }

    public void setGreenAnim(btnAnimName targetObj)
    {
        foreach (btnAnimName b in allGreenButton)
        {
            b.setSelfCol(G_disableCol);
        }
        changeAnimState(targetObj.targetAnimName, GreenDinoAnimator);
        targetObj.setSelfCol(G_enableCol);
    }

    public void setYellowAnim(btnAnimName targetObj)
    {
        foreach (btnAnimName b in allYellowButton)
        {
            b.setSelfCol(Y_disableCol);
        }

        changeAnimState(targetObj.targetAnimName, YellowDinoAnimator);
        targetObj.setSelfCol(Y_enableCol);
    }

    public void changeAnimState(string newS, Animator _a)
    {
        if(nowState == newS) return;
        _a.Play(newS);
        nowState = newS;
    }



    // public void greenWalk()
    // {
    //     GreenDinoAnimator.SetTrigger("Walk");
    // }


}
