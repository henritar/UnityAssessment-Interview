﻿using UnityEngine;
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
        [Inject(Id = "resetButton")]
        public Button ResetButton;
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
        [Inject(Id = "FiveFiveToggle")]
        public Toggle FiveFiveToggle;
        [Inject(Id = "SixSixToggle")]
        public Toggle SixSixToggle;

    }
}