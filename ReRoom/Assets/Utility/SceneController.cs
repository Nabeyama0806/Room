using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    static private bool m_isTransition = false;

    public enum Type
    {
        Title,
        Player,
        Select,
        Battle,
        AddCard,
        Shop,
        Result,
        System,
    }

    //�V�[����������Ԃœǂݍ���
    static public void Redo(Type scene)
    {
        //���ɑJ�ڒ��Ȃ�󂯕t���Ȃ�
        if (m_isTransition) return;

        //�V�[���̓ǂݍ���
        SceneManager.LoadScene(SceneName(scene));
    }

    //�V�[���̒ǉ�
    static public void Load(Type scene)
    {
        //���ɑJ�ڒ��Ȃ�󂯕t���Ȃ�
        if (m_isTransition) return;

        //���ɒǉ��ς݂Ȃ牽�����Ȃ�
        if (SceneManager.GetSceneByName(SceneName(scene)).isLoaded) return;

        //�V�[���̒ǉ��ǂݍ���
        SceneManager.LoadScene(SceneName(scene), LoadSceneMode.Additive);
    }

    //�V�[���̏��O
    static public void UnLoad(Type scene)
    {
        //���ɑJ�ڒ��Ȃ�󂯕t���Ȃ�
        if (m_isTransition) return;

        //�V�[���̏��O
        SceneManager.UnloadSceneAsync(SceneName(scene));
    }

    //�V�[���J��
    static public void Transition(Type prevScene, Type nextScene)
    {
        //���ɑJ�ڒ��Ȃ�󂯕t���Ȃ�
        if (m_isTransition) return;

        //���ɒǉ��ς݂Ȃ牽�����Ȃ�
        if (SceneManager.GetSceneByName(SceneName(nextScene)).isLoaded) return;

        //�V�[���J�ڊJ�n
        m_isTransition = true;

        //�O�̃V�[����BGM���~
        BGM.Instance.Stop();

        //�t�F�[�h�A�E�g
        Fade.FadeOut(1.0f, () =>
        {
            //���̃V�[����ǂݍ���
            SceneManager.LoadScene(SceneName(nextScene), LoadSceneMode.Additive);

            //�O�̃V�[�������O����
            SceneManager.UnloadSceneAsync(SceneName(prevScene));

            //�V�[���J�ڊ���
            m_isTransition = false;

            //�V�[����BGM���Đ�
            BGM.Instance.Play(nextScene);

            //�t�F�[�h�C��
            Fade.FadeIn(1.0f);
        });
    }

    static private string SceneName(Type type)
    {
        switch (type)
        { 
            case Type.Title:
                return "Title";

            case Type.Player:
                return "Player";

            case Type.Select:
                return "Select";

            case Type.Battle:
                return "Battle";

            case Type.AddCard:
                return "AddCard";

            case Type.Shop:
                return "Shop";

            case Type.Result:
                return "Result";

            case Type.System:
                return "System";

            default:
                Debug.Log("�V�[�������݂��܂���B");
                return "Unknown";
        }
    }
}