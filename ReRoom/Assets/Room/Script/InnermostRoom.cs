using UnityEngine;

public class InnermostRoom : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        //プレイヤーと接触したら
        if (other.TryGetComponent<PlayerController>(out var controller))
        {
            //コントローラーを無効化
            controller.enabled = false;

            //リザルト画面へ遷移
            SceneController.Transition(SceneType.Game, SceneType.Result);
        }
    }
}
