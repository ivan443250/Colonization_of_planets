using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTrigger : MonoBehaviour
{
   public dialog dialog;
   public void Triggerdialog()
   {
        FindObjectOfType<dialogManager>().Startdialog(dialog);
   }
}
