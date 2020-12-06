﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameManager m_GameManager;
    [SerializeField] Transform m_collectables, m_power;
    [SerializeField] Text m_coinsDisplay, m_lifesDisplay;
    [SerializeField] Image m_powerDisplay;

    [SerializeField] Animator UIanim;

    private int currentPower = 0;

    private void Awake()
    {
        UIanim.SetBool("Show", false);
    }

    private void Update()
    {
        if (currentPower != m_GameManager.Power) UIanim.SetBool("Show", true);
        else UIanim.SetBool("Show", false);
        currentPower = m_GameManager.Power;
        m_coinsDisplay.text = m_GameManager.Coins.ToString();
        m_lifesDisplay.text = m_GameManager.lifes.ToString();
       
        float newFill = (1 - ((float)m_GameManager.Power / 8f)) - 0.125f * (float)Mathf.Round(Time.time % 1);

        m_powerDisplay.fillAmount = newFill;
    }
}
