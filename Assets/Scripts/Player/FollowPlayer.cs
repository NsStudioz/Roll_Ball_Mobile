using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab = null;
    private readonly string PLAYER_TAG = "Player";
    
    private void Start() => FollowTargetPlayer();

    private void FollowTargetPlayer()
    {
        playerPrefab = GameObject.FindGameObjectWithTag(PLAYER_TAG);

        var vCamera = GetComponent<CinemachineVirtualCamera>();

        vCamera.Follow = playerPrefab.transform;
    }

    private void OnDestroy()
    {
        playerPrefab = null;
    }

}
