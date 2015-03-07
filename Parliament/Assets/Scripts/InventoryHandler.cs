using UnityEngine;
using System.Collections;

public class InventoryHandler : MonoBehaviour
{
    public HotbarSlot[] Slots;
    private HotbarSlot CurrentSlot;

	// Use this for initialization
	void Start ()
	{
	    SetSlot(1);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void SetSlot(int slotNum)
    {
        
    }
}
