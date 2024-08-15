using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPanelEventPointWin : MonoBehaviour
{
    public Animator EventUIPanelAnim;

    public bool launchNewRewardPanelAnimBool = false;
    public bool launchPointWinPanelAnimBool = false;

    public bool lockToMainAnim = false;

    IEnumerator WaitForAnimation(float f)
    {

        EventUIPanelAnim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(f);
        EventUIPanelAnim.SetBool("IsOpen", false);
        lockToMainAnim = false;
    }

    private void Update()
    {
        if ((launchPointWinPanelAnimBool == true) && (lockToMainAnim ==false))
        {
            StopAllCoroutines();
            launchPointWinPanelAnimBool = false;
            EventUIPanelAnim.SetBool("IsOpen", false);
            StartCoroutine(WaitForAnimation(1.5f)); 
        }

        if ((launchNewRewardPanelAnimBool == true) && (lockToMainAnim == true))
        {
            StopAllCoroutines();
            launchNewRewardPanelAnimBool = false;
            EventUIPanelAnim.SetBool("IsOpen", false);
            StartCoroutine(WaitForAnimation(2.5f));
        }
    }
}
