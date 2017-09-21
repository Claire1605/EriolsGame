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
    [HideInInspector]
    public bool popUpTextActive = false;

    public override void Interact()
    {
        closeButton.SetActive(true);
        if (!popUpTextActive)
        {
            closeButton.GetComponent<CloseMoreInfo>().popUp = GetComponent<PopUp_MoreInfo>();
            textBgrd.SetActive(true);
            StartCoroutine(moveThroughScript.FadeImage(textBgrd.GetComponent<Image>(), textBgrd.GetComponent<Image>().sprite, false, true, false));
            StartCoroutine(moveThroughScript.FadeImage(closeButton.GetComponent<Image>(), closeButton.GetComponent<Image>().sprite, false, true, false));
            foreach (var item in texts)
            {
                item.SetActive(true);
                StartCoroutine(moveThroughScript.FadeOtherText(item.GetComponent<Text>(), false, true));
            }
        }
        else if (popUpTextActive) //if you have clicked on a MoreInfo button but not closed the last one
        {
            //foreach (var item in texts) //will this catch the old ones?
            //{
            //    StartCoroutine(moveThroughScipt.FadeOtherText(item.GetComponent<Text>(), true, false));
            //}
            //foreach (var item in texts) //and cycle through the new ones?
            //{
            //    item.SetActive(true);
            //    StartCoroutine(moveThroughScipt.FadeOtherText(item.GetComponent<Text>(), false, true));
            //}
        }


            PopUp_MoreInfo[] activePopUps = FindObjectsOfType(typeof(PopUp_MoreInfo)) as PopUp_MoreInfo[];
            foreach (var item in activePopUps)
            {
                item.popUpTextActive = true;
            }

       
    }

    public override void EndInteract()
    {
        StartCoroutine(moveThroughScript.FadeImage(textBgrd.GetComponent<Image>(), textBgrd.GetComponent<Image>().sprite, true, false, false));
        foreach (var item in texts)
        {
            StartCoroutine(moveThroughScript.FadeOtherText(item.GetComponent<Text>(), true, false));
        }
    }
}
