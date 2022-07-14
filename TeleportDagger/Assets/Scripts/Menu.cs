using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private InputField _playerName;

    private const string saveKey = "saveName";

    private void Start()
    {
        Load();
    }

    public void OnEndEditName()
    {
        Save();
    }

    public void ScenePlay()
    {
        SceneManager.LoadScene(1);
    }

    private void Load()
    {
        var data = SaveSystem.Load<SaveData.PlayerProfile>(saveKey);

        _playerName.SetTextWithoutNotify(data.name);
    }

    private void Save()
    {
        SaveSystem.Save(saveKey, GetSaveName());
    }

    private SaveData.PlayerProfile GetSaveName()
    {
        var data = new SaveData.PlayerProfile()
        {
            name = _playerName.text
        };
        return data;
    }
}
