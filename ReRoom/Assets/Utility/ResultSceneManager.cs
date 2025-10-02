using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] PlayData m_playData;

    [SerializeField] List<TextMeshProUGUI> m_testList;

    private void Start()
    {
        //結果表示
        m_testList[0].text = m_playData.deleteFakeCount.ToString();
        m_testList[1].text = m_playData.roomNumber.ToString();
        m_testList[2].text = m_playData.playTime.ToString("F1");

        //シーン遷移
        StartCoroutine(SceneChange());
    }

    private IEnumerator SceneChange()
    {
        //3秒待機
        yield return new WaitForSeconds(3.0f);

        //シーン遷移
        SceneController.Transition(SceneType.Result, SceneType.Game);
    }
}
