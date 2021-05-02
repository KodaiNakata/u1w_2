using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ゲーム画面の監督用のクラス
/// </summary>
public class GameSceneDirector : MonoBehaviour
{
    /// <summary>
    /// 残機用のテキスト
    /// </summary>
    [SerializeField]
    private GameObject zankiText;

    /// <summary>
    /// ポーズ用のパネル
    /// </summary>
    [SerializeField]
    private GameObject pausePanel;

    /// <summary>
    /// 結果用のパネル
    /// </summary>
    [SerializeField]
    private GameObject resultPanel;

    /// <summary>
    /// 結果表示用のテキスト
    /// </summary>
    [SerializeField]
    private GameObject resultText;

    /// <summary>
    /// ポストエフェクト用のマテリアル
    /// </summary>
    [SerializeField]
    private Material postEffectMaterial;

    /// <summary>
    /// 遷移時間
    /// </summary>
    [SerializeField]
    private float transitionTime = 1f;

    /// <summary>
    /// ポストエフェクトの進行状況
    /// </summary>
    private readonly int _progress = Shader.PropertyToID("_Progress");

    /// <summary>
    /// インスタンス
    /// </summary>
    public static GameSceneDirector instance { get; private set; }

    /// <summary>
    /// 残機
    /// </summary>
    private int zanki;

    /// <summary>
    /// ポーズ状態か
    /// </summary>
    public bool isPaused { get; set; }

    /// <summary>
    /// クリア状態か
    /// </summary>
    public bool isClear { get; set; }

    /// <summary>
    /// オブジェクトがアクティブになるたびに毎回呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        instance = this;
        zanki = 5;
        isPaused = false;
        isClear = false;
        zankiText.GetComponent<TextMeshProUGUI>().text = "ざんき " + zanki.ToString();
        if (postEffectMaterial != null)
        {
            StartCoroutine(DoTransition());
        }
    }

    /// <summary>
    /// オブジェクトがアクティブ解除になるたびに毎回呼ばれる処理
    /// </summary>
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    private void Update()
    {
        // 残機がゼロのとき
        if (!HasZanki())
        {
            IndicateResult("かんそう ならず...");
            return;
        }
        // クリアしたとき
        else if (isClear)
        {
            IndicateResult("かんそう たっせい!!!");
            return;
        }
        Pause();
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
        StageController.instance.canMove = true;
        GimmickController.instance.canMove = true;
    }

    /// <summary>
    /// 残機が残っているか
    /// </summary>
    /// <returns>true：残っている、false：残っていない</returns>
    private bool HasZanki()
    {
        if (zanki == 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// ポーズ操作をする
    /// </summary>
    private void Pause()
    {
        // 右クリックしたとき
        if (Input.GetMouseButtonDown(1))
        {
            // ポーズ状態にする
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            StageController.instance.canMove = false;
            GimmickController.instance.canMove = false;
        }
    }

    /// <summary>
    /// リザルトの表示
    /// </summary>
    /// <param name="result">結果のテキスト</param>
    private void IndicateResult(string result)
    {
        resultPanel.SetActive(true);
        resultText.GetComponent<TextMeshProUGUI>().text = result;
        Time.timeScale = 0f;
        isPaused = true;
        StageController.instance.canMove = false;
        GimmickController.instance.canMove = false;
    }

    /// <summary>
    /// 残機を減らす
    /// </summary>
    public void DecreaseZanki()
    {
        zanki--;
        zankiText.GetComponent<TextMeshProUGUI>().text = "ざんき " + zanki.ToString();
    }
}
