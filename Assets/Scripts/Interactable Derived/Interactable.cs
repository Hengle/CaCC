using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float range;
    public string overlayText = "[E] Interact";

    [HideInInspector]
    public float distance;
    [HideInInspector]
    public bool _inRange = false;

    private float timer = 0f;

    private void OnEnable()
    {
        InteractionManager.instance.AddToInteractables(this);
    }

    void OnDisable()
    {
        InteractionManager.instance.RemoveFromInteractables(this);
    }

    public virtual void Interact ()
    {
        // Will be overridden by inherited class
    }

    public void Update()
    {
        timer += Time.deltaTime;

        distance = Vector3.Distance(GlobalVar.instance.runtime.player.transform.position, transform.position);
        if (distance <= range)
        {
            timer = 0;
            _inRange = true;
        }
        else
        {
            _inRange = false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
