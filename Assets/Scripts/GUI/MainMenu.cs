using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // allows you to change or interact with your scene

public class MainMenu : MonoBehaviour
{
    // regions keep your code clean; when you start one you must end one to make little collapsable blocks of code
    #region Variables and Data 
    private enum MenuState // enum is comma separted list of indentifyier / id / element
    {
        MainPanel ,
        OptionsPanel,
        PlayPanel,
        AreYouSurePanel
    }
    [SerializeField]MenuState _menuState = MenuState.MainPanel;
    #endregion
    #region Unity Event Behaviours
    private void OnGUI()
    {
        switch (_menuState)
        {
            case MenuState.MainPanel:
                MainPanel();
                break; // Like a return but instead of sending you back to start it lets you continue
            case MenuState.OptionsPanel:
                OptionsPanel();
                break;
            case MenuState.PlayPanel:
                PlayPanel();
                break;
            case MenuState.AreYouSurePanel:
                AreYouSurePanel();
                break;
            default:
                _menuState = MenuState.MainPanel;
                break;
        }
    }
    #endregion
    #region GUI Panels
    void MainPanel()
    {
        GUI.Box(new Rect(UIHandler.ScreenPlacement(0, 0, 16, 9)), "Main Menu Panel");
        GUI.Box(new Rect(UIHandler.ScreenPlacement(4, 0.25f, 8, 2)), "Game Title"); // mix between float and int; float always needs to be ended with f to tell its a float
        GUI.Box(new Rect(UIHandler.ScreenPlacement(5, 2.5f, 6, 6.25f)), "Button Box");
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 3.25f, 4, 0.75f)), "Play"))
        {
            _menuState = MenuState.PlayPanel;
        }
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 5.25f, 4, 0.75f)), "Options"))
        {
            _menuState = MenuState.OptionsPanel;
        }
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 7.25f, 4, 0.75f)), "Exit"))
        {
            _menuState = MenuState.AreYouSurePanel;
        }
    }
    void OptionsPanel()
    {
        GUI.Box(new Rect(UIHandler.ScreenPlacement(0, 0, 16, 9)), "Options Panel");
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 7.25f, 4, 0.75f)), "Back"))
        {
            _menuState = MenuState.MainPanel;
        }
    }
    void PlayPanel()
    {
        GUI.Box(new Rect(UIHandler.ScreenPlacement(0, 0, 16, 9)), "Play Panel");
        GUI.Box(new Rect(UIHandler.ScreenPlacement(4, 0.5f, 8, 8)), "Button Box");
        GUI.Box(new Rect(UIHandler.ScreenPlacement(5, 1.25f, 6, 1.5f)), "PlayPanel");

        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 3.5f, 4, 0.75f)), "Continue"))
        {
            Debug.Log("In future we will load our lasted played saved game");
        }
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 4.75f, 4, 0.75f)), "New Game"))
        {
            Debug.Log("Change Scene to Customisation scene and start a new game");
            ChangeSceneByIndexValue(1);
        }
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 6, 4, 0.75f)), "Load"))
        {
            Debug.Log("In future we will load from a list of saved games");
        }
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(6, 7.25f, 4, 0.75f)), "Back"))
        {
            _menuState = MenuState.MainPanel;
        }
    }

    void AreYouSurePanel()
    {
        GUI.Box(new Rect(UIHandler.ScreenPlacement(0, 0, 16, 9)), "Are You Sure Panel");
        GUI.Box(new Rect(UIHandler.ScreenPlacement(0, 0, 16, 9)), "AreYouSurePanel");
        GUI.Box(new Rect(UIHandler.ScreenPlacement(4, 2.25f, 8, 4.5f)), "AreYouSurePanel");
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(5f, 4.25f, 2.75f, 0.75f)), "Yes"))
        {
            Debug.Log("Exit");
            ExitToDesktop();
        }
        if (GUI.Button(new Rect(UIHandler.ScreenPlacement(8.25f, 4.25f, 2.75f, 0.75f)), "No"))
        {
            _menuState = MenuState.MainPanel;
        }
    }
    #endregion
    #region Scene Management
    void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    void ChangeSceneByIndexValue(int sceneIndexValue)
    {
        SceneManager.LoadScene(sceneIndexValue);
    }
    void ExitToDesktop()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    
        #endif
    }
    #endregion
}
