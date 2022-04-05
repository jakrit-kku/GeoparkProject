using UnityEngine;

public class AudioCall : MonoBehaviour
{
    // ใช้กะพวกปุ่มที่เชื่อม audio manage ตรงจาก scene ไม่ได้ 
    // ในกรณีที่ scene เปลี่ยนมาจาก mainmenu แล้ว audio manager reset
    [SerializeField] string startPlayName;
    AudioManager _aud;
    [SerializeField] string[] audioNameList;


    private void Start() 
    {
        _aud = FindObjectOfType<AudioManager>();

        if (startPlayName == "")
        {
            return;
        }
        else
        {
            playSound(startPlayName);
        }
    }

    public void playSound(string _name)
    {
        _aud.Play(_name);
    }

    public void PlayRandom(string[] _name)
    {
        int a = Random.Range(0, _name.Length);
        playSound(_name[a]);
    }

    public void AnimationRandomSound()
    {
        PlayRandom(audioNameList);
    }
}
