using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDetection : MonoBehaviour
{
    private Collider2D mirrorColliderA;
    private Collider2D mirrorColliderB;
    public bool isHit = false;

    public bool sideAHit = false;

    private void Start()
    {
        mirrorColliderA = GetComponent<Collider2D>();
        mirrorColliderB = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (isHit)
        {
            mirrorColliderA.enabled = !mirrorColliderA.enabled;
            mirrorColliderB.enabled = !mirrorColliderB.enabled;
        }
    }
}
