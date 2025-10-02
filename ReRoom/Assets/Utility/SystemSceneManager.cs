using UnityEngine;

public class SystemSceneManager : MonoBehaviour
{
    [SerializeField] SceneType m_firstScene;

    void Start()
    {
        //BGM���Đ�
        BGM.Instance.Play(m_firstScene);

        //�ŏ��̃V�[����ǂݍ���
        SceneController.Load(m_firstScene);
    }
}
