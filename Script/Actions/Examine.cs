using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check items in room
        if (CheckITems(controller, controller.player.currentLocation.items, noun))
            return;

        //check items in inventory
        if(CheckITems(controller, controller.player.inventory, noun))
            return;

        controller.CurrentText.text = "You can't see a " + noun;

    }

    private bool CheckITems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractWith(controller, "examine"))
                    return true;
                controller.CurrentText.text = "You see " + item.description;
                return true; 
            }
        }
        return false;
    }
}
