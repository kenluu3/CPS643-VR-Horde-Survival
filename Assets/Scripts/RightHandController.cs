using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightHandController : HandController
{
    void Start()
    {
        heldWeapon = transform.Find("Sword").gameObject;
    }
}