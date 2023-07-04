using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfineCamera : MonoBehaviour
{

    [SerializeField] private GameObject backgroundTilesetPrefab = null;
    private string BACKGROUND_TILESET_TAG = "Background";

    void Awake()
    {
        ConfineCameraToLevel();
    }

    private void ConfineCameraToLevel()
    {
        var vCameraConfiner = GetComponent<CinemachineConfiner>();

        if (vCameraConfiner.m_BoundingShape2D == null)
        {
            backgroundTilesetPrefab = GameObject.FindGameObjectWithTag(BACKGROUND_TILESET_TAG);
            PolygonCollider2D collider2D = backgroundTilesetPrefab.GetComponent<PolygonCollider2D>();
            vCameraConfiner.m_BoundingShape2D = collider2D;
        }
    }

    private void OnDestroy()
    {
        backgroundTilesetPrefab = null;
    }

}
