using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    public Text maxhealth;
    public Text maxfupa;
    public Text currenthealth;
    public Text currentfupa;
    public Text currency;
    public Text shopdialouge;
    public Text Thealthlvlcost;
    public Text Tfupalvlcost;
    public Text Thealthfillcost;
    public Text Tfupafillcost;
    public Text itemdescription;

    public int healthlvlcost;
    public int fupalvlcost;
    public int healthfillcost;
    public int fupafillcost;
    [TextArea(3, 10)]
    public string[] sentences;

    private int item;

    // Use this for initialization
    void Start () {
        maxhealth.text = "Max Health: " + GameControl.instance.maxhealth;
        maxfupa.text = "Max Fupa: " + GameControl.instance.maxfupa;
        currenthealth.text = "Current Health: " + GameControl.instance.currenthealth;
        currentfupa.text = "Current Fupa: " + GameControl.instance.currentfupa;
        currency.text = "" + GameControl.instance.currency;
        shopdialouge.text = "Take a look around and let me know what you want :)";
        Thealthlvlcost.text = "  " + healthlvlcost * GameControl.instance.healthlvl;
        Tfupalvlcost.text = "  " + fupalvlcost * GameControl.instance.fupalvl;
        Thealthfillcost.text = "  " + healthfillcost;
        Tfupafillcost.text = "  " + fupafillcost;
    }

    public void HealthUp()
    {
        itemdescription.text = sentences[0];
        item = 0;    
    }
    public void FupaUp()
    {
        itemdescription.text = sentences[1];       
        item = 1;               
    }
    public void HealthFill ()
    {
        itemdescription.text = sentences[2];        
        item = 2;        
    }
    public void FupaFill()
    {
        itemdescription.text = sentences[3];
        item = 3;
    }
    public void Buy()
    {
        switch (item)
        {
            case 0:
                Debug.Log("HealthUp");
                if (GameControl.instance.healthlvl < GameControl.instance.maxhealthlvl)
                {
                    if (GameControl.instance.currency >= (healthlvlcost * GameControl.instance.healthlvl))
                    {
                        GameControl.instance.currency -= healthlvlcost * GameControl.instance.healthlvl;
                        currency.text = "" + GameControl.instance.currency;
                        GameControl.instance.healthlvl += 1;
                        GameControl.instance.maxhealth += 5;
                        Thealthlvlcost.text = "  " + healthlvlcost * GameControl.instance.healthlvl;
                        maxhealth.text = "Max Health: " + GameControl.instance.maxhealth;
                        shopdialouge.text = "Max Health Raised ";
                    }
                    else
                    {
                        shopdialouge.text = "Not Enough Fupa Coins. :( ";
                    }
                }
                else
                {
                    shopdialouge.text = "Your at you max HP!";
                }
                break;
            case 1:
                if (GameControl.instance.fupalvl < GameControl.instance.maxfupalvl)
                {
                    if (GameControl.instance.currency >= (fupalvlcost * GameControl.instance.fupalvl))
                    {
                        GameControl.instance.currency -= fupalvlcost * GameControl.instance.fupalvl;
                        currency.text = "" + GameControl.instance.currency;
                        GameControl.instance.fupalvl += 1;
                        GameControl.instance.maxfupa += 5;
                        Tfupalvlcost.text = "  " + fupalvlcost * GameControl.instance.fupalvl;
                        maxfupa.text = "Max Fupa: " + GameControl.instance.maxfupa;
                        shopdialouge.text = "Max Fupa Raised ";
                        GameControl.instance.currentfupa = GameControl.instance.maxfupa;
                        currentfupa.text = "Current Fupa: " + GameControl.instance.currentfupa;


                    }
                    else
                    {
                        shopdialouge.text = "Not Enough Fupa Coins. :( ";
                    }
                }
                else
                {
                    shopdialouge.text = "Your at you max FUPA!";
                }  
                break;
            case 2:
                if (GameControl.instance.maxhealth != GameControl.instance.currenthealth)
                {
                    if (GameControl.instance.currency >= healthfillcost)
                    {
                        GameControl.instance.currency -= healthfillcost;
                        currency.text = "" + GameControl.instance.currency;
                        GameControl.instance.currenthealth = GameControl.instance.maxhealth;
                        currenthealth.text = "Current Health: " + GameControl.instance.currenthealth;
                        shopdialouge.text = "Health Refilled ";

                    }
                    else
                    {
                        shopdialouge.text = "Not Enough Fupa Coins. :( ";
                    }
                }
                else
                {
                    shopdialouge.text = "Your HP is already full!";
                } 
                break;
            case 3:
                if (GameControl.instance.maxfupa != GameControl.instance.currentfupa)
                {
                    if (GameControl.instance.currency >= fupafillcost)
                    {
                        GameControl.instance.currency -= fupafillcost;
                        currency.text = "" + GameControl.instance.currency;
                        GameControl.instance.currentfupa = GameControl.instance.maxfupa;
                        currentfupa.text = "Current Fupa: " + GameControl.instance.currentfupa;
                        shopdialouge.text = "Fupa Power Restored ";

                    }
                    else
                    {
                        shopdialouge.text = "Not Enough Fupa Coins. :( ";
                    }
                }
                else
                {
                    shopdialouge.text = "Your fupa power is already full!";
                }
                break;
            default:
                break;// code to be executed if n doesn't match any cases
        }
    }
    public void Back()
    {
        GameControl.instance.Prev();
    }
}
