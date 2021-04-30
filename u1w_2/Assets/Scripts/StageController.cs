using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの操作関連のクラス
/// </summary>
public class StageController : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// ステージのx座標の最小値
    /// </summary>
    [SerializeField]
    private float minPosX;

    /// <summary>
    /// ステージの座標
    /// </summary>
    private Vector3 stagePosition;

    /// <summary>
    /// オブジェクトがアクティブになるたびに毎回呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        stagePosition = new Vector3(0f, 0f);
        transform.position = stagePosition;
    }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    private void Update()
    {
        MoveStage();
    }

    /// <summary>
    /// ステージを動かす
    /// </summary>
    private void MoveStage()
    {
        stagePosition.x -= moveSpeed;
        if (stagePosition.x <= minPosX)
        {
            stagePosition.x = 0f;
        }
        transform.position = stagePosition;
    }
}
