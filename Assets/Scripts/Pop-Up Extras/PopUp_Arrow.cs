using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Arrow : PopUpExtras
{
    [SerializeField]
    private GameObject dragChair;

    private Vector3 startMousePos = new Vector3(0, 0);
    private Vector3 chairPos = new Vector3(0, 0);
    private Vector3 arrowPos = new Vector3(0, 0);

    void Start()
    {
        chairPos = dragChair.transform.position;
        arrowPos =transform.localPosition;
    }

    public override void Interact()
    {
        base.Interact();
    }

    public override void EndInteract()
    {
        base.EndInteract();
    }

    public void BeginDragChair()
    {
        arrowPos = transform.localPosition;
        chairPos = dragChair.transform.localPosition;
        startMousePos = Input.mousePosition;
    }

    public void DragChair()
    {
        Debug.Log(GetComponent<RectTransform>().localPosition.x);
        Vector3 currentPos = Input.mousePosition;
        Vector3 diff = (currentPos/1.3f) - startMousePos;
        Vector3 pos = arrowPos + diff;
        Vector3 posC = chairPos + diff;
        if (transform.localPosition.x < pos.x &&
            GetComponent<RectTransform>().localPosition.x < Screen.width/2 - 75)
        {
            transform.localPosition = new Vector3(pos.x, arrowPos.y, 0);
            dragChair.transform.localPosition = new Vector3(posC.x, chairPos.y, 0);
        }
    }
}
