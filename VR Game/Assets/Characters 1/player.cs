using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    public NPC npc;
    [SerializeField] private AudioSource teacherGreeting;

    bool isTalking = false;
   // float curResponceTraker = 0;

    public GameObject playerO;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    //public Text playerResponce;
    
    private GameObject triggeringNpc;
    private bool triggering;

  
    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);

    }
    void Update()
    {
        if (triggering)
        {
            print("Player is triggering with" + triggeringNpc);
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.CompareTag("Player") && isTalking == false)
        {
            StartConversation();
            GetComponent<Animator> ().Play("Waving");
            teacherGreeting.Play();
        } else if(other.CompareTag("Player") && isTalking == true)
        {
            EndConversation();
        }
        
        void OnMouseUp()
        {
            npcDialogueBox.text = npc.dialogue[1];
        }
        

    }

    void StartConversation()
    {
        isTalking = true;
        //curResponceTraker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndConversation()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
    void OnTriggerExit(Collider other)
    {
        EndConversation();
    }
}
