using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;

    public bool itemEnabled = true;

    public Interaction[] interactions;

    public Item targetItem = null;

    public bool playerCanTalkTo = false;

    public bool playerCanGiveTo = false;

    public bool PlayerCanRead = false;

    public bool InteractWith(GameController controller, string actionKeyword, string noun  = "")
    {
        foreach(Interaction i in interactions)
        {
            if (i.action.keyword == actionKeyword)
            {
                if (noun != " " && noun.ToLower() != i.textToMatch.ToLower())
                    continue;

                foreach(Item disableItem in i.itemsToDisable)
                    disableItem.itemEnabled = false;

                foreach (Item enableItem in i.itemsToEnable)
                    enableItem.itemEnabled = true;

                foreach (Connection disableConnection in i.connectionToDisable)
                    disableConnection.connectionEnabled = false;

                foreach (Connection enableConnection in i.connectionToEnable)
                    enableConnection.connectionEnabled = true;

                if (i.teleportLocation != null)
                    controller.player.Teleport(controller, i.teleportLocation);

                controller.CurrentText.text = i.response;
                controller.DisplayLocation(true);

                return true;
            }
        }
        return false;
    }
}
