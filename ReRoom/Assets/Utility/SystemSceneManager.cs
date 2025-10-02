using UnityEngine;

public class SystemSceneManager : MonoBehaviour
{
    [SerializeField] SceneType m_firstScene;

    void Start()
    {
        //BGM‚ğÄ¶
        BGM.Instance.Play(m_firstScene);

        //Å‰‚ÌƒV[ƒ“‚ğ“Ç‚İ‚Ş
        SceneController.Load(m_firstScene);
    }
}
