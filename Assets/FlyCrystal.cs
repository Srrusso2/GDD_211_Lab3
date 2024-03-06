using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCrystal : Item
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AbilityAvailable == true)
        {
            Debug.Log("Fly Available!");
        }
    }
}
