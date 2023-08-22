using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTrigger : MonoBehaviour
{
    public TMP_Text messageBox;
    public GameObject endCamera;
    public GameObject playerCamera;
    public CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        messageBox.enabled = true;
        messageBox.text = "You Win!!";
        playerController.enabled = false;
        StartCoroutine(SwitchCamera());

    }

    IEnumerator SwitchCamera()
    {
        yield return new WaitForSeconds(2.0f);
        endCamera.SetActive(true);
        playerCamera.SetActive(false);

    }
}
