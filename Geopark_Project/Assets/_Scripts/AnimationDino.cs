using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class btnAnimName
{
    public string targetAnimName;
    public string SoundPlayName;
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

    AudioSource[] allAudioSources;
    AudioManager _aud;

    private string nowState;
    string previousPlay;


    private void Start() 
    {

        // SpeedSlider.onValueChanged.AddListener((v) => 
        // {
        //     GreenDinoAnimator.speed = v;
        // });


        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        _aud = FindObjectOfType<AudioManager>();


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

        doPlayAud(targetObj);


    }

    public void setYellowAnim(btnAnimName targetObj)
    {
        foreach (btnAnimName b in allYellowButton)
        {
            b.setSelfCol(Y_disableCol);
        }

        changeAnimState(targetObj.targetAnimName, YellowDinoAnimator);
        targetObj.setSelfCol(Y_enableCol);

        doPlayAud(targetObj);

    }

    public void doPlayAud(btnAnimName _a)
    {
        // reclick 
        StopAllAudio();
        if(previousPlay == _a.SoundPlayName)
        {
            // reset name
            previousPlay = "";
            return;
        }
        else
        {
            _aud.Play(_a.SoundPlayName);
        }
        previousPlay = _a.SoundPlayName;
    }

    public void changeAnimState(string newS, Animator _a)
    {
        if(nowState == newS) return;
        _a.Play(newS);
        nowState = newS;
    }

    void StopAllAudio() 
    {
        foreach( AudioSource audioS in allAudioSources) 
        {
            audioS.Stop();
        }
    }



    // public void greenWalk()
    // {
    //     GreenDinoAnimator.SetTrigger("Walk");
    // }


}
