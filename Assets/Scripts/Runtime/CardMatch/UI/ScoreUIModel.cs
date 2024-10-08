using TMPro;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class ScoreUIModel
    {
        [Inject(Id = "scoreValueText")]
        public TextMeshProUGUI ScoreTextValue;
        [Inject(Id = "comboValueText")]
        public TextMeshProUGUI ComboTextValue;
        public int ScoreValue;
        public int ComboValue;
    }
}