using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoalManager : MonoBehaviour
{
    [SerializeField] private ObjectSlot[] _slots;
    [SerializeField] private int _score;
    
    public void OnSubmit()
    {
        foreach (var slot in _slots)
        {
            if (!slot.GetComponentInChildren<DraggableObject>()) continue;
            if (slot.GetComponentInChildren<DraggableObject>().kalimat.ToString() == slot._kalimat.ToString())
            {
                _score++;
            }
        }
        Debug.Log(_score);
    }
}
