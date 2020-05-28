﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score;

    public SaveData(ScoreManager scoreManager)
    {
        score = scoreManager.score;
    }
}
