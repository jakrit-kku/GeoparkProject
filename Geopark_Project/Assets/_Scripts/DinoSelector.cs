using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dinosour
{
    public GameObject dinoPref;
    public string dinoName;
    [TextArea(15,20)]
    public string dinoDes;
    public Vector3 offsetValue;

    public void disableDino()
    {
        dinoPref.SetActive(false);
    }

    public void enableDino()
    {
        dinoPref.SetActive(true);
    }
}

public class DinoSelector : MonoBehaviour
{
    public Dinosour[] allDino;
    [SerializeField] TMP_Text dinoNameText;
    [SerializeField] TMP_Text dinoDesText;
    [SerializeField] MouseRotate mouseRotScpt;


    public void selectDino(string dinoName)
    {
        // hide all dino first
        foreach (Dinosour dinoClass in allDino)
        {
            if (dinoClass.dinoName == dinoName)
            {
                dinoClass.enableDino();
                dinoNameText.text = dinoClass.dinoName;
                dinoDesText.text = dinoClass.dinoDes;
                mouseRotScpt.setNewOffset(dinoClass.offsetValue);
            }
            else
            {
                dinoClass.disableDino();
            }
            
        }


    }

}
