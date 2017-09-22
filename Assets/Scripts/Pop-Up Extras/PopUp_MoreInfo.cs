using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_MoreInfo : PopUpExtras {

    [SerializeField]
    private GameObject closeButton;
    [SerializeField]
    private GameObject textBgrd;
    [SerializeField]
    private List<GameObject> texts = new List<GameObject>();

    public override void Interact()
    {
        if (moveThroughScript.canClickAgain)
        {
            closeButton.SetActive(true);
            if (!moveThroughScript.popUpTextActive)
            {
                moveThroughScript.popUpTextActive = true;
                closeButton.GetComponent<CloseMoreInfo>().popUp = GetComponent<PopUp_MoreInfo>();
                StartCoroutine(moveThroughScript.FadeImage(closeButton.GetComponent<Image>(), closeButton.GetComponent<Image>().sprite, false, true, false));
                foreach (var item in texts)
                {
                    item.SetActive(true);
                    StartCoroutine(moveThroughScript.FadeOtherText(item.GetComponent<Text>(), false, true));
                }
            }
            else if (moveThroughScript.popUpTextActive) //if you have clicked on a MoreInfo button but not closed the last one
            {
                foreach (var item in GameObject.FindGameObjectsWithTag("MoreInfo"))
                {
                    if (item.GetComponent<Text>())
                    {
                        StartCoroutine(moveThroughScript.FadeOtherText(item.GetComponent<Text>(), true, false));
                    }

                }
                foreach (var item in texts)
                {
                    item.SetActive(true);
                    StartCoroutine(moveThroughScript.FadeOtherText(item.GetComponent<Text>(), false, true));
                }
            }
        }
       
    }

    public override void EndInteract()
    {
        foreach (var item in texts)
        {
            if (item.GetComponent<Text>().color.a > 0)
            {
                StartCoroutine(moveThroughScript.FadeOtherText(item.GetComponent<Text>(), true, false));
            }
        }
    }
}
