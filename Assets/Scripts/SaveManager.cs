using System;
using System.IO;
using Controllers;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BalanceController _balanceController;
    [SerializeField] private MinionController _minionController;
    [SerializeField] private UpgradeController _upgradeController;
    [SerializeField] private int _timeInterval;
    private GameData _gameData;
    private string _path;
    private float _time;

    private void Start()
    {
        if (_timeInterval == null)
        {
            _timeInterval = 10;
        }
        _time = 0;
        _path = Application.streamingAssetsPath + "/GameData.json";
        LoadData();
    }

    private void FixedUpdate()
    {
        _time += Time.deltaTime;
        if (_time >= _timeInterval)
        {
            SaveData();
            _time -= _timeInterval;
        }
    }

    private void SaveData()
    {
        if (_gameData != null)
        {
            _gameData.Money = _balanceController.GetBalanceValue();
            _gameData.Modifier = _playerController.GetModifier();
            _gameData.MinionsCount = _minionController.GetMinionsCount();
            _gameData.CostOfImprovingClickPower = _upgradeController.GetImprovementCostClick();
            _gameData.NewMinionCost = _upgradeController.GetCostNewMinion();
            _gameData.IsMusic = true;
            _gameData.IsSounds = true;
        }
        else
        {
            _gameData = new GameData();
        }

        File.WriteAllText(_path, JsonUtility.ToJson(_gameData));
    }
    private void LoadData()
    {
        if (File.Exists(_path))
        {
            _gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(_path));
        }
        else
        {
            SaveData();
        }
        _balanceController.SetBalanceValue(_gameData.Money);
        _playerController.SetModifier(_gameData.Modifier);
        _minionController.SetMinionsCount(_gameData.MinionsCount);
        _upgradeController.SetImprovementCostClick(_gameData.CostOfImprovingClickPower);
        _upgradeController.SetCostNewMinion(_gameData.NewMinionCost);
        //music
        //sounds
    }
    
    [Serializable]
    private class GameData
    {
        public ulong Money;
        public ulong Modifier;
        public ushort MinionsCount;
        public ulong CostOfImprovingClickPower;
        public ulong NewMinionCost;
        public bool IsMusic;
        public bool IsSounds;

        public GameData()
        {
            Money = 0;
            Modifier = 10;
            MinionsCount = 0;
            CostOfImprovingClickPower = 100;
            NewMinionCost = 100;
            IsMusic = true;
            IsSounds = true;
        }
    }
}
