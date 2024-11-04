using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public DialogueData dialogueData;
    public TextMeshProUGUI textMeshPro;
    public string message;
    public float letterDelay = 0.08f;
    private Coroutine typingCoroutine;

    public void ShowMessage(string id, string dialogType)
    {
        if (dialogType == "Look")
        {
            foreach (Dialogue dialogue in dialogueData.Look)
            {
                if (dialogue.dialogID == id)
                {
                    try
                    {
                        message = dialogue.dialogMessage;
                        StartDialogue();
                    }
                    catch (System.ArgumentOutOfRangeException e)
                    {
                        Debug.LogError("Message index out of range: " + e.Message);
                    }
                }
            }
        }
        else if (dialogType == "Use")
        {
            foreach (Dialogue dialogue in dialogueData.Use)
            {
                if (dialogue.dialogID == id)
                {
                    try
                    {
                        message = dialogue.dialogMessage;
                        StartDialogue();
                    }
                    catch (System.ArgumentOutOfRangeException e)
                    {
                        Debug.LogError("Message index out of range: " + e.Message);
                    }
                }
            }
        }
        else if (dialogType == "Take")
        {
            foreach (Dialogue dialogue in dialogueData.Take)
            {
                if (dialogue.dialogID == id)
                {
                    try
                    {
                        message = dialogue.dialogMessage;
                        StartDialogue();
                    }
                    catch (System.ArgumentOutOfRangeException e)
                    {
                        Debug.LogError("Message index out of range: " + e.Message);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Invalid dialog type: " + dialogType);
        }
    }

    public void StartDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        textMeshPro.text = "";
        foreach (char letter in message)
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
