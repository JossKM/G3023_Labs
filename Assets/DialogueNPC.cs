using UnityEngine;
using Yarn.Unity;

public class DialogueNPC : MonoBehaviour
{
    DialogueRunner dialogueRunner;
    public string StartNode;

    private void Start()
    {
        dialogueRunner = FindAnyObjectByType<DialogueRunner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement2D playermovement = collision.GetComponent<Movement2D>();
        if (playermovement != null && playermovement.gameObject.tag == "Player")
        {
            dialogueRunner.StartDialogue(StartNode);
        }
    }
}
