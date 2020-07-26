﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPrefab;
    public GameObject playerPrefab;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    public void SpawnPlayer(int id, string username, Vector3 position, Quaternion rotation)
    {
        GameObject player;
        if(id == Client.instance.clientID)
        {
            player = Instantiate(localPrefab, position, rotation);
            player.name = "Local Player";
        }
        else
        {
            player = Instantiate(playerPrefab, position, rotation);
            player.name = $"Player #{id}";
        }

        PlayerManager manager = player.GetComponent<PlayerManager>();

        manager.id = id;
        manager.username = username;
        players.Add(id, manager);
    }
}
