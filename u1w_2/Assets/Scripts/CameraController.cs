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
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 移動開始するか
    /// </summary>
    public bool startedMoving { private get; set; }

    // Start is called before the first frame update
    private void OnEnable()
    {
        startedMoving = false;
    }

    // Update is called once per frame
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
            //TODO：どの方向に移動するかを決定
            //TODO：目的地までカメラを一定のスピードで移動する
            //TODO：移動完了後、startMovingをfalseにする
            Vector3 position = transform.position;
        }
    }
}
