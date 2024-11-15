﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;
public class DotConnectLoading : MonoBehaviour
{
    public Image LoadingFill_UI;
    public float TimeDuration;
    
    public event Action OnLoadingUpdate;
    [SerializeField] private TMP_Text _textLoading;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        OnLoadingUpdate += UpdateLoadingText;
        LoadingFill();
    }

    void LoadingFill()
    {
        LoadingFill_UI.DOFillAmount(1f, TimeDuration).OnUpdate(() =>
        {
            OnLoadingUpdate?.Invoke();
        }).OnComplete(() =>
        {
            SceneManager.LoadScene("MainMenuDotConnect");
        });


    }

    void UpdateLoadingText()
    {
        float percent = LoadingFill_UI.fillAmount * 100f;
        _textLoading.text = $"{percent:0}%";
    }

    private void OnDestroy()
    {
        OnLoadingUpdate -= UpdateLoadingText;

    }
}