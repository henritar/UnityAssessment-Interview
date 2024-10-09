﻿using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class ScoreUIModel
    {
        [Inject(Id = "scoreValueText")]
        public TextMeshProUGUI ScoreTextValue;
        [Inject(Id = "comboValueText")]
        public TextMeshProUGUI ComboTextValue;
        [Inject(Id = "saveGameButton")]
        public Button SaveGameButton;
        public int ScoreValue;
        public int ComboValue;
    }
}