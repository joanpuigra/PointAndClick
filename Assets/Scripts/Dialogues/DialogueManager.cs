using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // public Dialogue[] dialogues;

    public void ShowMessage(string id, int messageIndex)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.dialogID == id) {
                Debug.Log(dialogue.GetMessage(messageIndex));
                return;
            }
        }
        Debug.LogWarning("Dialog not found on that ID: " + id);
    }
}

// region OLD SYSTEM
// using System.Collections;
// using TMPro;
// using UnityEngine;

// public class DialogueManager : MonoBehaviour
// {
//     public TextMeshProUGUI textMeshPro;
//     public Dialogue[] dialogues;
//     public float letterDelay = 0.05f; // Letter delay
//     private Coroutine typingCoroutine;

//     // Start is called before the first frame update
//     void Start()
//     {
//         StartDialogue();
//     }

//     public void StartDialogue()
//     {
//         typingCoroutine = StartCoroutine(TypeDialogue()); // Start coroutine
//     }

//     IEnumerator TypeDialogue()
//     {
//         foreach(Dialogue dialogue in dialogues)
//         {
//             textMeshPro.text = "";
//             foreach (char letter in dialogues)
//             {
//                 textMeshPro.text += letter;
//                 yield return new WaitForSeconds(letterDelay);
//             }
//         }
//     }
// }
// endregion
