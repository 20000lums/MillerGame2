using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxScript : MonoBehaviour
{
    private DialogScript Dialog;
    [SerializeField]
    public List<ScriptLine> ThingsThatAreSaid = new List<ScriptLine>();

    void Start()
    {
        Dialog = GameObject.FindGameObjectWithTag("DialogLogic").GetComponent<DialogScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Dialog.StartDialog(ThingsThatAreSaid);
        Destroy(gameObject);
    }
}
