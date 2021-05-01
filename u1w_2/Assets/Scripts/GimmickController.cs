using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックの操作関連のクラス
/// </summary>
public class GimmickController : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static GimmickController instance { get; private set; }

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
        canMove = true;
        isSlow = false;
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
            Vector3 position = transform.position;
            position.x -= speed;
            transform.position = position;
        }
    }
}
