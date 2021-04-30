using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 忍者のアニメーション関連のクラス
/// </summary>
public class NinjaAnim : StateMachineBehaviour
{
    /// <summary>
    /// アニメーション終了時の処理
    /// </summary>
    /// <param name="animator">アニメータ</param>
    /// <param name="stateInfo">アニメータの状態の情報</param>
    /// <param name="layerIndex">レイヤーの要素番号</param>
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("ThrowShuriken"))
        {
            animator.SetBool("ThrowShuriken", false);
        }
    }
}
