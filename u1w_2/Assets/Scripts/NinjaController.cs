using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方向の列挙体
/// </summary>
public enum Direction
{
    UP,
    DOWN
}

/// <summary>
/// 忍者の操作関連のクラス
/// </summary>
public class NinjaController : MonoBehaviour
{
    /// <summary>
    /// 忍者のy座標の最大値
    /// </summary>
    [SerializeField]
    private float maxPosY;

    /// <summary>
    /// 忍者のy座標の最小値
    /// </summary>
    [SerializeField]
    private float minPosY;

    /// <summary>
    /// 忍者のアニメータ
    /// </summary>
    private Animator ninjaAnim;

    /// <summary>
    /// 音源
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// 最初の1フレームに入る前の開始処理
    /// </summary>
    private void Start()
    {
        ninjaAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    private void Update()
    {
        InputMouse();
    }

    /// <summary>
    /// 衝突が起きた瞬間時の処理
    /// </summary>
    /// <param name="collision">衝突オブジェクト</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gimmick"))
        {
            // ダメージを受けるアニメーションへ
            ninjaAnim.SetBool("Damaged", true);

            GimmickController.instance.isSlow = true;
            StageController.instance.isSlow = true;

            // 残機を減らす
            GameSceneDirector.instance.DecreaseZanki();
        }
    }

    /// <summary>
    /// 衝突が終わった瞬間時の処理
    /// </summary>
    /// <param name="collision">衝突オブジェクト</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        GimmickController.instance.isSlow = false;
        StageController.instance.isSlow = false;
    }

    /// <summary>
    /// マウス入力処理
    /// </summary>
    private void InputMouse()
    {
        // ダメージを受けている状態は操作を受け付けない
        if (ninjaAnim.GetBool("Damaged"))
        {
            return;
        }

        // 回転扉を開いていない状態で左クリックしたとき
        if (Input.GetMouseButtonDown(0) && !ninjaAnim.GetBool("RotateDoor"))
        {
            // 回転するアニメーションへ
            ninjaAnim.SetBool("RotateDoor", true);
            // ステージの移動処理を一時停止
            StageController.instance.canMove = false;
            // ギミックの移動処理を一時停止
            GimmickController.instance.canMove = false;
        }
    }

    /// <summary>
    /// ステージの道を変更する処理
    /// </summary>
    /// <param name="direct">移動の方向</param>
    private void ChangeLoad(Direction direct)
    {
        // カメラの上下移動を開始
        CameraController.instance.direction = direct;
        CameraController.instance.startedMoving = true;
    }

    /// <summary>
    /// 忍者の効果音を再生する
    /// </summary>
    private void PlayNinjaSE(AudioClip audioClip)
    {
        audioSource.volume = SoundManager.instance.seVolume;
        audioSource.PlayOneShot(audioClip);
    }
}
