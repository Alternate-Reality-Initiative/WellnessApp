using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Player _player;

    void Start(){
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void SwitchScene(string scene) {
        //_player = GameObject.Find("Player").GetComponent<Player>();
        _player.SavePlayer();
        SceneManager.LoadSceneAsync(scene);
    } 

    // void OnApplicationPause(){
    //     _player = GameObject.Find("Player").GetComponent<Player>();
    //     _player.SavePlayer();
    //     Debug.Log("_player.waterLevel");
    // }
    private void OnApplicationPause(bool pause)
    {
        if (pause){
            _player.SavePlayer();
        }
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus){
            _player.SavePlayer();
        }
    }
    // private void OnApplicationQuit(){
    //     //_player = GameObject.Find("Player").GetComponent<Player>();
    //     _player.SavePlayer();
    //     //Debug.Log("_player.waterLevel");
    // }
}

