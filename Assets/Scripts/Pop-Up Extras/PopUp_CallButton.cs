using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_CallButton : PopUpExtras {

    [SerializeField]
    private GameObject phone;
    [SerializeField]
    private GameObject hand;
  //  [SerializeField]
  //  private MoveThroughScript moveThroughScript;

    public void Start()
    {
        GetComponent<Button>().interactable = false;
        GetComponent<ButtonBorder>().doFade = false;
    }

    public override void Interact()
    {
        EndInteract();
    }

    public override void EndInteract()
    {
        foreach (var item in phone.GetComponentsInChildren<Image>())
        {
            if (item.IsActive())
            {
                item.StartCoroutine(moveThroughScript.FadeImage(item, item.sprite, true, false, false));
                item.gameObject.GetComponent<ButtonBorder>().doFade = false;
            }
        }
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        hand.SetActive(false);
    }
}
