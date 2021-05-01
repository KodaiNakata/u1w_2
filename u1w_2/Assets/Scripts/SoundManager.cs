using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音の列挙体
/// </summary>
public enum SoundKind
{
    BGM,
    SE
}

/// <summary>
/// サウンドを管理するクラス
/// </summary>
public class SoundManager
{
    /// <summary>
    /// BGMの音量
    /// </summary>
    public float bgmVolume { get; set; } = 0.5f;

    /// <summary>
    /// SEの音量
    /// </summary>
    public float seVolume { get; set; } = 0.5f;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static SoundManager instance { get; private set; } = new SoundManager();

    private SoundManager()
    {
        instance = this;
    }
}
