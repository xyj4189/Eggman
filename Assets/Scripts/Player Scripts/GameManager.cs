﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public event System.Action<PlayerScript> OnLocalPlayerJoined;
    private GameObject gameObject;

    private static GameManager m_instance;

    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameManager();
                m_instance.gameObject = new GameObject ("_gameManager");
                m_instance.gameObject.AddComponent<InputController>();

            }
            return m_instance;
        }
    }
    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }

    private PlayerScript m_LocalPlayer;
    public PlayerScript LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;
            if(OnLocalPlayerJoined != null)
                    OnLocalPlayerJoined(m_LocalPlayer);
        }
    }
}
