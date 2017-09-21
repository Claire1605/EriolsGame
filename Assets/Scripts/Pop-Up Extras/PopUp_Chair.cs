using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Chair : PopUpExtras {

    [SerializeField]
    private GameObject arrowObj;
 //   [SerializeField]
    //private MoveThroughScript moveThroughScript;

    public override void Interact()
    {
        arrowObj.SetActive(true);
        arrowObj.GetComponentInChildren<ButtonBorder>().doFade = true;
        StartCoroutine(moveThroughScript.FadeImage(arrowObj.GetComponent<Image>(), arrowObj.GetComponent<Image>().sprite, false, true, false));
        StartCoroutine(moveThroughScript.FadeOtherText(arrowObj.GetComponentInChildren<Text>(), false, true));
    }

    public override void EndInteract()
    {
        arrowObj.GetComponentInChildren<ButtonBorder>().doFade = false;
        StartCoroutine(moveThroughScript.FadeImage(arrowObj.GetComponent<Image>(), arrowObj.GetComponent<Image>().sprite, true, false, false));
        StartCoroutine(moveThroughScript.FadeOtherText(arrowObj.GetComponentInChildren<Text>(), true, false));
    }

}
