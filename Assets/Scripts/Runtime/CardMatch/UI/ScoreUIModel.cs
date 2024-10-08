using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class ScoreUIModel
    {
        [Inject(Id = "scoreValueText")]
        public TextMeshProUGUI ScoreValue;
        [Inject(Id = "comboValueText")]
        public TextMeshProUGUI ComboValue;
    }
}