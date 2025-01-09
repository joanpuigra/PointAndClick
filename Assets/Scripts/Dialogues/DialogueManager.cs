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

    void Start()
    {
        textMeshPro.text = "";
    }

    public void ShowMessage(int id, string dialogType)
    {
        Dialogue[] dialogues = null;

        switch (dialogType)
        {
            case "Look":
                dialogues = dialogueData.Look;
                break;
            case "Use":
                dialogues = dialogueData.Use;
                break;
            case "Take":
                dialogues = dialogueData.Take;
                break;
            case "Interaction":
                dialogues = dialogueData.Interaction;
                break;
            default:
                Debug.LogError("Invalid dialog type: " + dialogType);
                return;
        }

        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.dialogID == id)
            {
                try
                {
                    message = dialogue.dialogMessage;
                    StartDialogue();
                    return;
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Message index out of range: " + ex.Message);
                }
            }
        }

        Debug.LogError("Dialog ID not found: " + id);
    }

    private void StartDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeDialogue());
    }

    private IEnumerator TypeDialogue()
    {
        textMeshPro.text = "";
        foreach (char letter in message.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}
