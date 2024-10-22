using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] dialogues;
    public float letterDelay = 0.05f; // Letter delay
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        typingCoroutine = StartCoroutine(TypeDialogue()); // Start coroutine
    }

    IEnumerator TypeDialogue()
    {
        foreach(string dialogue in dialogues)
        {
            textMeshPro.text = "";

            foreach (char letter in dialogue)
            {
                textMeshPro.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }
        }
    }
}
