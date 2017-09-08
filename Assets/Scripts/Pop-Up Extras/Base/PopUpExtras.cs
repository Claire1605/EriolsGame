using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PopUpExtras : MonoBehaviour {

	public virtual void Interact()
    {
        Debug.Log("The button worked");
    }
}
