using UnityEngine;
using TMPro;

public class ExitManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_count;
    [SerializeField] TextMeshProUGUI m_time;

    public void Start()
    {
        //正解数を表示
        m_count.text = 
            GameSceneManager.Instance.MaxRoom.ToString()
            + " / " 
            + GameSceneManager.Instance.TotalLoopCount.ToString("D1");

        //プレイ時間を表示
        float time = GameSceneManager.Instance.PlayTime;
        int minute = (int)(time / 60);
        int second = (int)(time % 60);
        m_time.text = minute.ToString("D2") + ":" + second.ToString("D2");
    }

    private void OnTriggerExit(Collider other)
    {
        //プレイヤーと接触したら
        if (other.TryGetComponent<PlayerController>(out var controller))
        {
            //コントローラーを無効化
            controller.enabled = false;

            //リザルト画面へ遷移
            SceneController.Transition(SceneType.Game, SceneType.Title);
        }
    }
}
