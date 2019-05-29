using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimation()
    {

    }

    public void ChangeParameter(string parameterName, int nNum)
    {
        playerAnimator.SetInteger(parameterName, nNum);
    }

    public void ChangeParameter(string parameterName, float fNum)
    {
        playerAnimator.SetFloat(parameterName, fNum);
    }
}
