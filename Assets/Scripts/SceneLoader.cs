using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   //���̍s���ŏ��ɒǉ����Ȃ��ƃV�[���̌Ăяo���͂ł��܂���

public class SceneLoader : MonoBehaviour
{
    public void Load(string scenename) //������scenename����
    {
        SceneManager.LoadScene(scenename);  //�V�[�������[�h���܂�
    }
}