using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "ScriptableObject/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string dialogID;
    [TextArea(3, 10)]
    public string[] textMessages;

    public string GetMessage(int index)
    {
        if (index >= 0 && index < textMessages.Length)
        {
            return textMessages[index];
        }   
        return "Index out of range.";
    }
}