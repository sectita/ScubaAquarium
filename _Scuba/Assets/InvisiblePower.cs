using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InvisiblePower : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private float powerTime;

    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(DisableButton);
        boxCollider2D = GameObject.FindGameObjectWithTag("Squba").GetComponent<BoxCollider2D>();
        
    }
    
    void DisableButton()
    {
        button.interactable = false;
        boxCollider2D.enabled = false;
        Invoke("PowerInvisible", powerTime);
    }

    void PowerInvisible()
    {
        button.interactable = true;
        boxCollider2D.enabled = true;

    }
}
