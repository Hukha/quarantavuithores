using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public void ResetLevel () {
        GameController.ResetLevel ();
    }

    public void GoToMenu () {
        GameController.GoToMenu ();
    }
}