using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/DialogueData", order = 0)]
public class DialogueData : ScriptableObject
{
    public Dialogue[] Look;
    public Dialogue[] Use;
    public Dialogue[] Take;
    public Dialogue[] Interaction;
}
