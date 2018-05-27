using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float range;
    public Transform player;
    public string overlayText = "[E] Interact";

    [HideInInspector]
    public float distance;
    [HideInInspector]
    public bool _inRange = false;

    private float timer = 0f;

    public virtual void Interact ()
    {
        // Will be overridden by inherited class
    }

    public void Update()
    {
        timer += Time.deltaTime;

        distance = Vector3.Distance(player.position, transform.position);
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
