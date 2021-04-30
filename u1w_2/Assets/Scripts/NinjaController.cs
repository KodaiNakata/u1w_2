using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 忍者の操作関連のクラス
/// </summary>
public class NinjaController : MonoBehaviour
{
    /// <summary>
    /// 方向の列挙体
    /// </summary>
    enum Direction
    {
        UP,
        DOWN
    }

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
    /// マウス入力処理
    /// </summary>
    private void InputMouse()
    {
        // 手裏剣を投げていない状態で左クリックしたとき
        if (Input.GetMouseButtonDown(0) && !ninjaAnim.GetBool("ThrowShuriken"))
        {
            // 手裏剣を投げるアニメーションへ
            ninjaAnim.SetBool("ThrowShuriken", true);
            //TODO：手裏剣生成処理を行う
        }
        // 回転扉を開いていない状態で右クリックしたとき
        else if (Input.GetMouseButtonDown(1) && !ninjaAnim.GetBool("RotateDoor"))
        {
            // 回転するアニメーションへ
            ninjaAnim.SetBool("RotateDoor", true);
            //TODO：ステージの移動処理を一時停止
        }
    }

    /// <summary>
    /// ステージの道を変更する処理
    /// </summary>
    /// <param name="direct">移動の方向</param>
    private void ChangeLoad(Direction direct)
    {
        if (direct == Direction.UP)
        {
            //TODO：カメラの上移動を開始
        }
        else
        {
            //TODO：カメラの下移動を開始
        }
    }

    /// <summary>
    /// 忍者の効果音を再生する
    /// </summary>
    private void PlayNinjaSE(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
