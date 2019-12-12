using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // Detect whether JohnLemon is within range.
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        // If the other collider's transform position is same as the current transform of JohnLemon
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the other collider's transform position is same as the current transform of JohnLemon
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            // transform.position refers to the GameObject's position (GO of this script)
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            // raycastHit will be a storage of raycast hit info
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
