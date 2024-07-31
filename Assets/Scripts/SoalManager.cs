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
        _soalText.text = "Soal " + _curNoSoal;
        var noSoal = Random.Range(0, _bankSoal.soal.Length);
        if (!_bankSoal.soal[noSoal].isDone)
        {
            var i = 0;
            foreach (var soal in _bankSoal.soal[noSoal].kata)
            {
                Instantiate(soal, transform.GetChild(i));
                i++;
            }

            _kunciJawabanImage.sprite = _bankSoal.soal[noSoal].kunciJawabanImage;
            _bankSoal.soal[noSoal].isDone = true;
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
                Debug.Log("Soal Habis");
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
            }
        }

        foreach (var slot in _slots)
        {
            Destroy(slot.transform.GetChild(0).gameObject);
        }
        
        Initialize();
    }
}
