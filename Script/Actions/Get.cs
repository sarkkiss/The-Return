using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        foreach (Item item in controller.player.currentLocation.items)
        {
            if (item.itemEnabled && item.itemName == noun)
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.CurrentText.text = "You take the " + noun;
                    return;
                }
            }
        }
        controller.CurrentText.text = "You can't get that.";
    }
}
