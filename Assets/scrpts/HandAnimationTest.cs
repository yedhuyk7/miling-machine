using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationTest : MonoBehaviour
{
     public Animator handAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            handAnimator.SetTrigger("Grab");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            handAnimator.SetTrigger("Place");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            handAnimator.SetTrigger("PressButton");
        }
    }
}
