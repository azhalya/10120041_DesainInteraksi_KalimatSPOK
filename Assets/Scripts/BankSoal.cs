using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Bank Soal")]
public class BankSoal : ScriptableObject
{
    public Soal[] soal;
    
    [Serializable]
    public struct Soal
    {
        public bool isDone;
        public Sprite kunciJawabanImage;
        [CanBeNull] public Sprite deskripsiGambar;
        public DraggableObject[] kata;
    }
}
