using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ScreenTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f / 0.75f;

    //Plays only the start of the given animation
    public void StartTransition(string direction)
    {
        StartCoroutine(StartAnimation(direction));
    }

    //Plays only the end of the given animation
    public void EndTransition(string direction)
    {
        StartCoroutine(EndAnimation(direction));
    }

    //Plays the entire animation given
    public void PlayTransition(string direction)
    {
        StartTransition(direction);
        EndTransition(direction);
    }

    private IEnumerator StartAnimation(string animation)
    {
        //transition.ResetTrigger(animation + "End");
        transition.SetTrigger(animation + "Start");

        yield return null;
    }

    private IEnumerator EndAnimation(string animation)
    {
        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger(animation + "End");
    }
}
