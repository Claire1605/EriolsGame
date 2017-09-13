using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_DadItems : PopUpExtras {

    public GameObject clickItems;
    public MoveThroughScript moveThroughScript;

    public override void Interact()
    {
        clickItems.gameObject.SetActive(true);
        foreach (var item in clickItems.GetComponentsInChildren<Image>())
        {
            item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, false, true, false));
            item.gameObject.GetComponent<ButtonBorder>().doFade = true;
        }
    }

    public override void EndInteract()
    {
        foreach (var item in clickItems.GetComponentsInChildren<Image>())
        {
            if (item.IsActive())
            {
                item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, true, false, false));
                item.gameObject.GetComponent<ButtonBorder>().doFade = false;
            }
        }
    }
}
