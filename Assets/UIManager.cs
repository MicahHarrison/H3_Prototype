using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider heathUI;
    public Image playerImage;
    public Text playerName;
    public Text lives;
    public Text coins;

    private Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            heathUI.maxValue = player.maxHealth;
            heathUI.value = heathUI.maxValue;
            playerName.text = player.playerName;
            playerImage.sprite = player.playerImage;
        }
        if (coins != null)
        {
            coins.text = "" + GameControl.instance.currency;
        }
    }
	
	// Update is called once per frame
	void Update () {
        coins.text = "" + GameControl.instance.currency;
    }

    public void UpdateHealth(int amount)
    {
        heathUI.value = amount;
    }

    public void Save()
    {
        GameControl.instance.Save();
    }


}
