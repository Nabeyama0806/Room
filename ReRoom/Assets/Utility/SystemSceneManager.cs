using UnityEngine;

public class SystemSceneManager : MonoBehaviour
{
    [SerializeField] SceneController.Type m_firstScene;

    void Start()
    {
        //�^�C�g���V�[���̓ǂݍ���
        SceneController.Load(m_firstScene);
    }
}
