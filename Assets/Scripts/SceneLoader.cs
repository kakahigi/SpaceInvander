using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   //この行を最初に追加しないとシーンの呼び出しはできません

public class SceneLoader : MonoBehaviour
{
    public void Load(string scenename) //引数にscenenameを代入
    {
        SceneManager.LoadScene(scenename);  //シーンをロードします
    }
}