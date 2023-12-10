using GameOnPlanet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialogTrigger : MonoBehaviour
{
    [SerializeField]
    private int _dialogIndex;

    [SerializeField]
    private DialogManager _dialogManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController) && DataHolder.GameData.EducationDialogsIndexes[_dialogIndex] == false)
        {
            _dialogManager.StartDialog(_dialogIndex);
        }
    }
}
