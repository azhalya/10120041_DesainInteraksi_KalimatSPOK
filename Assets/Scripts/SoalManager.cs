using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SoalManager : MonoBehaviour
{
    [SerializeField] private BankSoal _bankSoal;
    [SerializeField] private TMP_Text _soalText;
    [SerializeField] private ObjectSlot[] _slots;
    [SerializeField] private int _score;
    [SerializeField] private Image _kunciJawabanImage;

    [SerializeField] private int _curNoSoal;

    [SerializeField] private GameObject _benarPanel;
    [SerializeField] private GameObject _salahPanel;
    [SerializeField] private GameObject _selesaiPanel;

    [SerializeField] private TMP_Text _scoreText;

    private int _curScore;
    private int _noSoal;

    private void Awake()
    {
        for (int i = 0; i < _bankSoal.soal.Length; i++)
        {
            _bankSoal.soal[i].isDone = false;
        }
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log(_score);
        _soalText.text = "Soal " + _curNoSoal;
        _noSoal = Random.Range(0, _bankSoal.soal.Length);
        if (!_bankSoal.soal[_noSoal].isDone)
        {
            var i = 0;
            foreach (var soal in _bankSoal.soal[_noSoal].kata)
            {
                Instantiate(soal, transform.GetChild(i));
                i++;
            }

            _kunciJawabanImage.sprite = _bankSoal.soal[_noSoal].kunciJawabanImage;
            _bankSoal.soal[_noSoal].isDone = true;
            _curNoSoal++;
        }
        else
        {
            if (_curNoSoal <= 3)
            {
                Initialize();
            }
            else
            {
                _selesaiPanel.SetActive(true);
                _scoreText.text = ((_score * 100) / 12).ToString();
            }
        }
    }
    
    public void OnSubmit()
    {
        foreach (var slot in _slots)
        {
            if (!slot.GetComponentInChildren<DraggableObject>())
            {
                Debug.Log("Belum Penuh");
                return;
            }
            if (slot.GetComponentInChildren<DraggableObject>().kalimat.ToString() == slot._kalimat.ToString())
            {
                _score++;
                _curScore++;
            }
        }

        foreach (var slot in _slots)
        {
            Destroy(slot.transform.GetChild(0).gameObject);
        }

        if (_curScore == 4)
        {
            _benarPanel.SetActive(true);
        }
        else
        {
            _salahPanel.SetActive(true);
        }
    }

    public void OnNextSoal()
    {
        _curScore = 0;
        Initialize();
    }

    public void OnRestart()
    {
        _bankSoal.soal[_noSoal].isDone = false;
        _curScore = 0;
        _score = (_curNoSoal - 2) * 4;
        _curNoSoal--;
        Initialize();
    }
}
