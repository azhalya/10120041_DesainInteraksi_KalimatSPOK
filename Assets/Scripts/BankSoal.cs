using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bank Soal")]
public class BankSoal : ScriptableObject
{
    public Soal[] soal;
    
    [Serializable]
    public struct Soal
    {
        public bool isDone;
        public DraggableObject[] kata;
    }
}
