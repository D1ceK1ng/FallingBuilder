using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
public class CreatorPlayerName : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGrouopOfUI;
    [SerializeField] private CanvasGroup _canvasGroupOfCreatorPlayerName;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TMP_InputField _inputField;
    private void Awake() 
    {
        _canvasGrouopOfUI.ChangeStateOfCanvasGroup(false);
        _canvasGroupOfCreatorPlayerName.ChangeStateOfCanvasGroup(true);
        TryLoadingName();
    }
    private void TryLoadingName()
    {
      SavablePlayerName savablePlayerName = Loader<SavablePlayerName>.Load(new SavablePlayerName());
      if (savablePlayerName == null)
      {
         return;
      }
      if (savablePlayerName.PlayerName != "")
      {
        CloseMenu(savablePlayerName.PlayerName);
      }
      
    }
    public void TrySavingName()
    {
        if(_inputField.text != "")
        {
         SavePlayerName();
        }
    }
    private void SavePlayerName() 
    {
        LootLockerSDKManager.SetPlayerName(_inputField.text, (responce) => 
        {
            if (responce.success)
            {
                Saver<SavablePlayerName>.Save(new SavablePlayerName(_inputField.text));
                CloseMenu(_inputField.text);
            }
        });
    }
    public void CloseMenu(string name)
    {
        _playerName.text = name;
        _canvasGrouopOfUI.ChangeStateOfCanvasGroup(true);
        _canvasGroupOfCreatorPlayerName.ChangeStateOfCanvasGroup(false);
    }
}
