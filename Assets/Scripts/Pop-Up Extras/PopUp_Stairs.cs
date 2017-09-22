using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Stairs : PopUpExtras {

    public override void Interact()
    {
        nextButton.SetActive(true);
        StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, false, true, false));
    }

    public override void EndInteract()
    {
        nextButton.SetActive(true);
        StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, false, true, false));
    }
}
