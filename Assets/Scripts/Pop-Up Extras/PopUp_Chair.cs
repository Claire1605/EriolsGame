using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Chair : PopUpExtras {

    [SerializeField]
    private GameObject arrowObj;
    [SerializeField]
    private MoveThroughScript moveThroughScript;

    public override void Interact()
    {
        arrowObj.SetActive(true);
        arrowObj.GetComponentInChildren<ButtonBorder>().doFade = true;
        StartCoroutine(moveThroughScript.FadeImage(arrowObj.GetComponentInChildren<Image>(), arrowObj.GetComponentInChildren<Image>().sprite, false, true, false));
    }

    public override void EndInteract()
    {
        arrowObj.GetComponentInChildren<ButtonBorder>().doFade = false;
        StartCoroutine(moveThroughScript.FadeImage(arrowObj.GetComponentInChildren<Image>(), arrowObj.GetComponentInChildren<Image>().sprite, true, false, false));
    }
}
