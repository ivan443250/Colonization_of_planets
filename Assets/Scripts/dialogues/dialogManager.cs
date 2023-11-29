using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.  UI;

public class dialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    
    public Animator boxAim;
    public Animator startAim;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void Startdialog(dialog dialog)
    {
        boxAim.SetBool("dialog", true);
        startAim.SetBool("Startdialog", false);

        nameText.text = dialog.name;
        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text  = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        boxAim.SetBool("boxOpen", false);
    }
}
