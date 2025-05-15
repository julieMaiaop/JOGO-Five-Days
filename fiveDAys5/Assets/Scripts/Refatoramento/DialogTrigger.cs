using UnityEngine;
using Yarn.Unity;

public class DialogTrigger : MonoBehaviour
{
    //RaycastHit2D HitInfo;
    [SerializeField] DialogueRunner dialogRunner;
    [SerializeField] string nameDialog;

    void Update()
    {
        /*if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit HitInfo))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogRunner.StartDialogue(nameDialog);
            }
        }*/
    }
}