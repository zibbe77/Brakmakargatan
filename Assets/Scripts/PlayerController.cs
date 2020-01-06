using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public string controlPrefix = "P1";

    public string VerticalAxis
    {
        private set { }
        get
        {
            return controlPrefix + "Vertical";
        }
    }

    public string HorizontalAxis
    {
        private set { }
        get
        {
            return controlPrefix + "Horizontal";
        }
    }

    public string PunchAxis
    {
        private set { }
        get
        {
            return controlPrefix + "Fire1";
        }
    }

    public string KickAxis
    {
        private set { }
        get
        {
            return controlPrefix + "Fire2";
        }
    }
}
