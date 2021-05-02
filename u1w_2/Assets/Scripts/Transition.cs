using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 遷移用のクラス
/// </summary>
public class Transition : MonoBehaviour
{
    [SerializeField]
    private Material postEffectMaterial;

    [SerializeField]
    private float transitionTime = 1f;

    private readonly int _progress = Shader.PropertyToID("_Progress");

    /// <summary>
    /// オブジェクトがアクティブになるたびに毎回呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        if (postEffectMaterial != null)
        {
            StartCoroutine(DoTransition());
        }
    }

    /// <summary>
    /// 画面遷移する
    /// </summary>
    /// <returns></returns>
    private IEnumerator DoTransition()
    {
        float t = -1f;
        while (t < transitionTime)
        {
            float progess = t / transitionTime;
            postEffectMaterial.SetFloat(_progress, progess);
            yield return null;
            t += Time.deltaTime;
        }
        postEffectMaterial.SetFloat(_progress, 1f);
    }
}
