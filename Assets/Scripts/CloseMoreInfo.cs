using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMoreInfo : MonoBehaviour {

    [SerializeField]
    private MoveThroughScript moveThroughScript;
    [SerializeField]
    private GameObject nextButton;
    [HideInInspector]
    public PopUp_MoreInfo popUp;
    public Image moreInfoBgrd;
    private GameObject popUpParent;

    public void closePanel()
    {
        if (moveThroughScript.canClickAgain)
        {
            moveThroughScript.popUpTextActive = false;
            popUpParent.SetActive(true);
            PopUp_MoreInfo[] activePopUps = FindObjectsOfType(typeof(PopUp_MoreInfo)) as PopUp_MoreInfo[];
            foreach (var item in activePopUps)
            {
                item.EndInteract();
            }
            StartCoroutine(moveThroughScript.FadeImage(GetComponent<Image>(), GetComponent<Image>().sprite, true, false, false));
            popUpParent.GetComponent<Button>().interactable = true;
            popUpParent.GetComponent<PopUpExtras>().EndInteract();
            StartCoroutine(moveThroughScript.FadeImage(popUpParent.GetComponent<Image>(), popUpParent.GetComponent<Image>().sprite, false, true, false));
            nextButton.SetActive(true);
            StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, false, true, false));
            StartCoroutine(moveThroughScript.FadeImage(moreInfoBgrd, moreInfoBgrd.sprite, true, false, false));
        }
    }

    public void setPopUpParent(GameObject gO)
    {
        popUpParent = gO;
    }
}
