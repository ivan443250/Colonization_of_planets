using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogAnimator : MonoBehaviour
{
  public Animator startAim;
  public dialogManager dm;


  private void OnTriggerEnter2D(Collider2D other)
        {
            startAim.SetBool("startOpen", true);
        }

 private void OnTriggerExir2D(Collider2D other)
        {
            startAim.SetBool("startOpen", false);
            dm.EndDialog();
        }
}
