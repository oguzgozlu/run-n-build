using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    
    public Dictionary<Collectable.CollectableType, TextMeshProUGUI> TMPHolder = new Dictionary<Collectable.CollectableType, TextMeshProUGUI>();
    public Dictionary<Collectable.CollectableType, GameObject> placeHolder = new Dictionary<Collectable.CollectableType, GameObject>();

    public Dictionary<Collectable.CollectableType, GameObject> playerInventory =
        new Dictionary<Collectable.CollectableType, GameObject>();


    [Header("Stats")] 
    //public float startMoney;
    private float currentMoney;
    public PlayerStatsSO playerStatsSO;
    
    [Header("UI Texts")]
    public TextMeshProUGUI roofTMP;
    public TextMeshProUGUI wallTMP;
    public TextMeshProUGUI windowTMP;
    public TextMeshProUGUI doorTMP;
    public TextMeshProUGUI playerMoneyTMP;
    
    [Header("UI Model Placeholders")]
    public GameObject roofPlaceholder;
    public GameObject wallPlaceholder;
    public GameObject windowPlaceholder;
    public GameObject doorPlaceholder;
    
    
    
    [Header("Prefabs")]
    public GameObject brick;
    public GameObject door;
    [Header("UI Effects")]
    public GameObject brickParent;
    public GameObject doorParent;
    
    

    private void Start()
    {
        

        TMPHolder[Collectable.CollectableType.Door] = doorTMP;
        TMPHolder[Collectable.CollectableType.Roof] = roofTMP;
        TMPHolder[Collectable.CollectableType.Wall] = wallTMP;
        TMPHolder[Collectable.CollectableType.Window] = windowTMP;
        
        placeHolder[Collectable.CollectableType.Door] = doorPlaceholder;
        placeHolder[Collectable.CollectableType.Roof] = roofPlaceholder;
        placeHolder[Collectable.CollectableType.Wall] = wallPlaceholder;
        placeHolder[Collectable.CollectableType.Window] = windowPlaceholder;

        currentMoney = playerStatsSO.GetStartingMoney();
        playerMoneyTMP.text = currentMoney + "$";


    }

    private void Update()
    {
    }
/*
    public void Counter(GameObject key)
    {
        GameObject corObject;
        GameObject corParent;

        if (key.name.StartsWith("Door"))
        {
            corObject = door;
            corParent = doorParent;
        }
        else if (key.name.StartsWith("Brick"))
        {
            corObject = brick;
            corParent = brickParent;
        }
        else
        {
            corObject = door;
            corParent = doorParent;

        }



        counter[corObject] = key.gameObject.GetComponent<Collectable>().price;
        TMPHolder[corObject].text = counter[corObject].ToString() + "$";

        currentMoney -= counter[corObject];
        playerMoneyTMP.text = currentMoney + "$";
        corParent.GetComponent<UIEffects>().PickUp();


    }*/

    void PickUp(GameObject item)
    {
        playerInventory[item.GetComponent<Collectable>().type] = item;
        

    }
    
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionParent = collision.gameObject.transform.parent.gameObject;
        Debug.Log("zaa");
        if (collisionParent.CompareTag("Collectable"))
        {
            //brickHolder.GetComponent<BrickHolder>().addJoint(collision.gameObject);

            

            if (currentMoney >= collisionParent.GetComponent<Collectable>().price)
            {
                //Counter(collision.gameObject);
            
                Destroy(collisionParent.gameObject);
            }
            
            
            
            
            //collision.gameObject.tag = "Collected";
        }
    }
}
