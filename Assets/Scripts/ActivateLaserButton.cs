using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLaserButton : MonoBehaviour
{
    [SerializeField] private GameObject laserSource;

    public void ActivateLaser()
    {
        laserSource.SetActive(true);
    }
}
