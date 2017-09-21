using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PopUpExtras : MonoBehaviour {

    public GameObject nextButton;
    public MoveThroughScript moveThroughScript;

    public virtual void Interact()
    {
        Debug.Log("The button worked");
    }

    public virtual void EndInteract()
    {
        Debug.Log("End Interaction");
        nextButton.SetActive(true);
        StartCoroutine(moveThroughScript.FadeImage(nextButton.GetComponent<Image>(), nextButton.GetComponent<Image>().sprite, false, true, false));
    }

    public virtual void PointerEnter()
    {
        Debug.Log("Mouse-over object worked");
        gameObject.transform.SetAsLastSibling();
    }
}
