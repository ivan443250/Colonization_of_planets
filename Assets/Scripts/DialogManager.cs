using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private Dialog[] _dialog;

    [SerializeField]
    private float _timeBetweenPrint;

    [SerializeField]
    private GameObject _dialogPanel;

    [SerializeField]
    private TextMeshProUGUI _dialogWindowText;

    private UnityEvent _startDialog;
    private UnityEvent _endDialog;

    private int _currentDialogWindowTextIndex;
    private int _currentDialog;

    private bool _isDialogManagerFree;

    public void Initialize(out UnityEvent startDialog, out UnityEvent endDialog)
    {
        _isDialogManagerFree = true;

        _startDialog = new UnityEvent();
        _endDialog = new UnityEvent();

        startDialog = _startDialog;
        endDialog = _endDialog;
    }

    public void ChangeDialogWindowText()
    {
        if (_isDialogManagerFree == true)
            return;

        _currentDialogWindowTextIndex++;

        if (_currentDialogWindowTextIndex >= _dialog[_currentDialog].DialogLines.Length)
        {
            _dialogPanel.SetActive(false);
            _isDialogManagerFree = true;
            _endDialog.Invoke();
            return;
        }

        StartCoroutine(ShowDialogText());
    }

    public void StartDialog(int dialogIndex)
    {
        if (_isDialogManagerFree == false)
            return;

        _startDialog.Invoke();
        _currentDialog = dialogIndex;
        _currentDialogWindowTextIndex = 0;
        _dialogPanel.SetActive(true);
        StartCoroutine(ShowDialogText());
        _isDialogManagerFree = false;
    }

    private System.Collections.IEnumerator ShowDialogText()
    {
        char[] currentWindowChars = _dialog[_currentDialog].DialogLines[_currentDialogWindowTextIndex].ToCharArray();
        string showText = "";
        for (int i = 0; i < currentWindowChars.Length; i++)
        {
            showText += currentWindowChars[i];
            _dialogWindowText.text = showText;
            yield return new WaitForSeconds(_timeBetweenPrint);
        }
    }
}
