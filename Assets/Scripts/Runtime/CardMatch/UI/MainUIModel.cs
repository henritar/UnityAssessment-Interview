using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class MainUIModel
    {
        [Inject(Id = "mainUICanvas")]
        public Canvas MainUICanvas;
        [Inject(Id = "startGameButton")]
        public Button StartGameButton;
        [Inject(Id = "loadGameButton")]
        public Button LoadGameButton;
        [Inject(Id = "settingsButton")]
        public Button SettingsButton;
        [Inject(Id = "quitButton")]
        public Button QuitButton;
        [Inject(Id = "TwoTwoToggle")]
        public Toggle TwoTwoToggle;
        [Inject(Id = "ThreeThreeToogle")]
        public Toggle ThreeThreeToogle;
        [Inject(Id = "FourThreeToggle")]
        public Toggle FourThreeToggle;
        [Inject(Id = "FiveFourToggle")]
        public Toggle FiveFourToggle;

    }
}