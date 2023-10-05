using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameManager gameManager;
    private LineRenderer lineRenderer;
    private bool isLaserSpawned = false;
    private void Start()
    {
        laserPrefab = GameObject.Find("LaserSource");
        lineRenderer = laserPrefab.GetComponent<LineRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, -this.transform.up);
        Debug.DrawRay(this.transform.position, -this.transform.up * 2, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Mirror") && !isLaserSpawned)
            {
                MirrorHitMessage(hit);
            }
            else
            {
                Debug.Log("Laser not Spawned");
            }
            //else other components
        }
    }

    private void InstantiateLaser(RaycastHit2D hit, bool hitSideA)
    {
        if (gameManager.currentLaserCount <= gameManager.maxLaserCount)
        {
            isLaserSpawned = true;
            gameManager.currentLaserCount++;
            if (hitSideA)
            {
                GameObject.Instantiate(laserPrefab, hit.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            }
            else
            {
                GameObject.Instantiate(laserPrefab, hit.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, -90f));
            }
            Debug.Log("Laser Spawned");
        }
    }

    private void MirrorHitMessage(RaycastHit2D hit)
    {
        var detect = hit.collider.GetComponent<MirrorDetection>();

        if (!detect.isHit)
        {
            detect.isHit = true;
            bool hitSideA = false;

            if (hit.collider.GetType() == typeof(PolygonCollider2D))
            {
                hitSideA = false;
                InstantiateLaser(hit, hitSideA);
                DrawLine(hit);
            }
            else
            {
                hitSideA = true;
                InstantiateLaser(hit, hitSideA);
                DrawLine(hit);
            }
            
        }
    }

    private void DrawLine(RaycastHit2D hit)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }
}
