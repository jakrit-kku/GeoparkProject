using UnityEngine;


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

            if(dinoClass.dinoName == "Green")
            {
                AnimScpt.resetGreen();
            }

            if(dinoClass.dinoName == "Yellow")
            {
                AnimScpt.resetYellow();
            }

            
        }
    }

  
}
