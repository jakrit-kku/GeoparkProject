using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DinoWithSky
{
    public GameObject dinoPref;
    public string dinoName;
    public Material skyboxMat;
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


public class AnimDinoSelectorNew : MonoBehaviour
{
    [SerializeField] DinoWithSky[] allDino;
    [SerializeField] MouseRotate mouseRotScpt;
    [SerializeField] AnimationDino AnimScpt;
    [SerializeField] Image greenBtn;
    [SerializeField] Image YellowBtn;
    [SerializeField] Color enableCol;
    [SerializeField] Color disableCol;

    private void Start() 
    {
        selectDino("Green");
    }


    public void selectDino(string dinoName)
    {
        // hide all dino first
        foreach (DinoWithSky dinoClass in allDino)
        {
            if (dinoClass.dinoName == dinoName)
            {
                RenderSettings.skybox = dinoClass.skyboxMat;
                dinoClass.enableDino();
                // mouseRotScpt.setNewOffset(dinoClass.offsetValue);
            }
            else
            {
                dinoClass.disableDino();
            }
            
        }
        if(dinoName == "Green")
        {
            AnimScpt.resetGreen();
            greenBtn.color = enableCol;
            YellowBtn.color = disableCol;
        }
        else if(dinoName == "Yellow")
        {
            AnimScpt.resetYellow();
            YellowBtn.color = enableCol;
            greenBtn.color = disableCol;
        }
    }

  
}
