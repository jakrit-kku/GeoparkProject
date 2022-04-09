using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotate : MonoBehaviour
{
    public float speed;
    public bool DoRotate = true;
    [SerializeField] float multiply;
    [SerializeField] Slider mainSlider;

    [SerializeField] TMP_Text wordText;
    [SerializeField] Image btnImg;
    [SerializeField] Color offCol;
    [SerializeField] Color onCol;


    void Update()
    {
        if (DoRotate)
        {
            transform.Rotate(0, speed * multiply *Time.deltaTime, 0);
        }
    }

    private void Start() {
        mainSlider.onValueChanged.AddListener((v) => 
        {
            speed = v;
        });

        setRotSpeed();

    }

    public void doSwitchRotate()
    {
        if (DoRotate)
        {
            DoRotate = !DoRotate;
            btnImg.color = offCol;
            wordText.SetText("Start Rotation");
        }
        else
        {
            DoRotate = !DoRotate;
            btnImg.color = onCol;
            wordText.SetText("Stop Rotation");
        }
    }

    public void setRotSpeed()
    {
        speed = mainSlider.value;
    }
}
