using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_DadItems : PopUpExtras {

    public GameObject clickItems;
    public MoveThroughScript moveThroughScript;

    private int counter = -1;

    public override void Interact()
    {
        counter *= -1;

        if (counter > 0)
        {
            clickItems.gameObject.SetActive(true);

            for (int i = 0; i < clickItems.transform.childCount; i++)
            {
                clickItems.transform.GetChild(i).gameObject.SetActive(true);
            }
            foreach (var item in clickItems.GetComponentsInChildren<Image>())
            {
                item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, false, true, false));
                item.gameObject.GetComponent<ButtonBorder>().doFade = true;
            }
        }
        else
        {
            EndInteract();
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
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        clickItems.gameObject.SetActive(false);
    }
}
