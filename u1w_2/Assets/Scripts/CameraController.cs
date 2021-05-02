using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの操作関連のクラス
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// カメラのy座標の最大値
    /// </summary>
    [SerializeField]
    private float maxPosY;

    /// <summary>
    /// カメラのy座標の最小値
    /// </summary>
    [SerializeField]
    private float minPosY;

    /// <summary>
    /// カメラの移動速度
    /// </summary>
    private const float cMoveSpeed = 0.5f;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static CameraController instance { get; private set; }

    /// <summary>
    /// 移動開始するか
    /// </summary>
    public bool startedMoving { private get; set; }

    /// <summary>
    /// 移動方向
    /// </summary>
    public Direction direction { private get; set; }

    /// <summary>
    /// オブジェクトがアクティブになるたびに毎回呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        instance = this;
        startedMoving = false;
    }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    private void Update()
    {
        MoveCamera();
    }

    /// <summary>
    /// カメラの移動処理
    /// </summary>
    private void MoveCamera()
    {
        if (startedMoving)
        {
            Vector3 position = transform.position;

            // 上方向へ動くとき
            if (direction == Direction.UP)
            {
                position.y += cMoveSpeed;
            }
            else
            {
                position.y -= cMoveSpeed;
            }

            if (FinishedMoving(position))
            {
                // カメラの上下移動を終了
                startedMoving = false;

                // ステージのスクロールを再開
                StageController.instance.canMove = true;
                // ギミックのスクロールを再開
                GimmickController.instance.canMove = true;
            }

            transform.position = position;
        }
    }

    /// <summary>
    /// 移動完了したか
    /// </summary>
    /// <returns>true：移動完了、false：移動未完了</returns>
    private bool FinishedMoving(Vector3 position)
    {
        if (direction == Direction.UP)
        {
            if (position.y >= maxPosY)
            {
                return true;
            }
        }
        else
        {
            if (position.y <= minPosY)
            {
                return true;
            }
        }
        return false;
    }
}
