using UnityEngine;

public class Phuwiangosaurus_Animation : MonoBehaviour
{
    private Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.W))
        {
            return;
        }
        else
        {
            mAnimator.SetTrigger("Walk");
        }
    }
}
