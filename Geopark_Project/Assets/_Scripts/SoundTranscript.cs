using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonAndSoundName
{
    public string targetSoundName;
    public Button button;

    public void changeImage(Sprite _sprite, Color _col)
    {
        button.transform.GetChild(0).GetComponent<Image>().sprite = _sprite;
        button.image.color = _col;
    }

}

public class SoundTranscript : MonoBehaviour
{
    [SerializeField] Sprite imgPlaying;
    [SerializeField] Sprite imgStop;
    [SerializeField] ButtonAndSoundName[] allSoundButton;
    [SerializeField] Color originalCol;
    [SerializeField] Color playingCol;

    AudioManager _aud;

    string previousPlay;


    private void Start() 
    {

        _aud = FindObjectOfType<AudioManager>();

        foreach (ButtonAndSoundName _b in allSoundButton)
        {
            _b.button.onClick.AddListener(delegate{playSoundChangeImage(_b.targetSoundName, _b);});
        }

    }

    public void playSoundChangeImage(string _name, ButtonAndSoundName _nowBut)
    {
        // reclick 
        StopAllAudio();
        if(previousPlay == _name)
        {
            // reset name
            previousPlay = "";
            return;
        }
        else
        {
            _aud.Play(_name);
            _nowBut.changeImage(imgPlaying, playingCol);
        }

        previousPlay = _name;
    }

    void StopAllAudio() 
    {
        // เปลี่ยนภาพ เหลือเปลี่ยนการกดได้?
        foreach (ButtonAndSoundName _b in allSoundButton)
        {
            _b.changeImage(imgStop, originalCol);
        }
        _aud.stopAll();        
    }



}
