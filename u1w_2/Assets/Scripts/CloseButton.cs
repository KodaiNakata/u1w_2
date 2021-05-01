using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 閉じる用のボタンのクラス
/// </summary>
public class CloseButton : MonoBehaviour
{
    /// <summary>
    /// 閉じる対象のパネルのオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject closePanel;

    /// <summary>
    /// ボタンクリック時の処理
    /// </summary>
    public void OnClick()
    {
        // ポーズ解除
        Time.timeScale = 1f;
        StageController.instance.canMove = true;
        GimmickController.instance.canMove = true;
        GameSceneDirector.instance.isPaused = false;
        closePanel.SetActive(false);
    }
}
