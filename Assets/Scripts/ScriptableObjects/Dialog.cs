using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DialogCopy", menuName = "ScriptableObjects/Dialog")]
public class Dialog : ScriptableObject
{
    [TextArea][SerializeField]
    private string[] _dialogLines;
    public string[] DialogLines => _dialogLines;
}
