using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.CurrentText.text = "Type a Verb followed by a noun (e.g. \"go north\")";
        controller.CurrentText.text += "\nAllowed verbs:\nGo, Examine, Get, Give, Use, Inventory, TalkTo, Say, Read, Help";

    }
}
