﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 音量のスライダー用のクラス
/// </summary>
public class SoundSlider : MonoBehaviour
{
    /// <summary>
    /// 音の種類
    /// </summary>
    [SerializeField]
    private SoundKind soundKind;

    /// <summary>
    /// スライダーのオブジェクト
    /// </summary>
    [SerializeField]
    private Slider slider;

    /// <summary>
    /// スライダーの値変更時の処理
    /// </summary>
    public void OnValueChanged()
    {
        if (soundKind == SoundKind.BGM)
        {
            SoundManager.instance.bgmVolume = slider.value;
            return;
        }
        SoundManager.instance.seVolume = slider.value;
    }
}