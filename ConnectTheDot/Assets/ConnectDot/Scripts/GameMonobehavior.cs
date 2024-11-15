using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameMonobehavior : MonoBehaviour
{
    private DotConnectAudioController _audioController;
    private DotConnectUIManager _uiManager;
  



    public DotConnectAudioController Ac
    {
        get
        {
            if (_audioController == null)
            {
                _audioController = DotConnectAudioController.Instance;
            }
            return _audioController;
        }
    }

    public DotConnectUIManager Um
    {
        get
        {
            if (_uiManager == null)
            {
                _uiManager = DotConnectUIManager.Instance;
            }
            return _uiManager;
        }
    }







}
