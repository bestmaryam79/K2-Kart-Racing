using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{

    public bool collectedTreasure;
    int counter;
    public TextMeshProUGUI textChest;

    public Collect(bool collectedTreasure)
    {
        this.collectedTreasure = collectedTreasure;
    }

    // Start is called before the first frame update
    void Start()
    {
        counter = 0; 
    }

    // Update is called once per frame
    void Update()

    {
        

    }
    public void CollectedTreasureFunction ()
    {
        counter++;
        textChest.text = ("Treasure Chests " + counter.ToString());
        Debug.Log("The collected treasure function has just been called " + counter);

    }
}








/*
private void OnTriggerEnter(Collider other)
{
    if.(other.gameObject.tag == "TreasureChest")
        {
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
        other.transform.GetChild(1).GetChild(1).GetComponent<chest_lvl1>().enabled = false;
        for (int i = 1; i < 3; i++)
        {
            other.transform.GetChild(2).GetChild(i).GetComponent<chest_lvl1>().enabled = false; //Treasure chest
        }
        other.GameObject.GetComponent<Animator>().SetBool("Enlarge", false); //reset to start process

        StartCoroutine(getItem());
        ItemUIAnim.SetBool("Scroll", true);
        ItemUIScroll.SetBool("Scroll", true);

        //re-enable
        yield return new WaitForSecond(1);
        other.transform.GetChild(1).GetChild(1).GetComponent<chest_lvl1>().enabled = true;
        for (int i = 1) ; i < 3; i++)
        {
    other.transform.GetChild(2).GetChild(i).GetComponent<chest_lvl1>().enabled = true;
}
other.gameObject.GetComponent<Animator>().SetBool("Enlarge", true); // Show the tresure chest spawning  while it is there
other.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        }
        


    public void GetItem()
{
    if (!hasItem)
    {
        index = Random.Range(0, itemGameobjects.Lengths);
        yourSprite.sprite = itemSprites[index];
        yield return new WaitForSeconds(4f);

        itemGameObjects[index].SetActive(true);
        hasItem = true;

    }
}
public void useItem()
{

    if (Input.GetKey(KeyCode.RightShift))
    {
        hasItem = false;
        ItemUIAnim.SetBool("ItemIn", false);
        ItemUiScroll.SetBool("Scroll", false):
        itemGameobjects[index].SetActive(false);
        }
    }

*/
