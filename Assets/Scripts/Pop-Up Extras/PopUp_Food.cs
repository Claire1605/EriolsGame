using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_Food : PopUpExtras {

    public override void Interact()
    {
        Application.OpenURL("http://unity3d.com/"); // :O
    }

    public override void EndInteract()
    {
        base.EndInteract();
    }
}
