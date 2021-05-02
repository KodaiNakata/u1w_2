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
    /// インスタンス
    /// </summary>
    public static StageController instance { get; private set; }

    /// <summary>
    /// ステージの座標
    /// </summary>
    private Vector3 stagePosition;

    /// <summary>
    /// 動ける状態か
    /// </summary>
    public bool canMove { private get; set; }

    /// <summary>
    /// スロー状態か
    /// </summary>
    public bool isSlow { private get; set; }

    /// <summary>
    /// オブジェクトがアクティブになるたびに毎回呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        instance = this;
        canMove = false;
        isSlow = false;
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
        if (canMove)
        {
            float speed = moveSpeed;
            if (isSlow)
            {
                speed /= 2f;
            }
            stagePosition.x -= speed;
            if (stagePosition.x <= minPosX)
            {
                stagePosition.x = 0f;
            }
            transform.position = stagePosition;
        }
    }
}
