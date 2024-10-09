using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Installers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Handler
{
    public static class SaveGameStateHandler
    {
        public static void SaveGameInfo(int rows, int columns, int score, int combo)
        {
            
            PlayerPrefs.SetInt("GridRows", rows);
            PlayerPrefs.SetInt("GridColumns", columns);
            PlayerPrefs.SetInt("PlayerScore", score);
            PlayerPrefs.SetInt("PlayerCombo", combo);

            PlayerPrefs.Save();
        }

        public static GameInfo LoadGameInfo()
        {
            int rows = PlayerPrefs.GetInt("GridRows", 2); 
            int columns = PlayerPrefs.GetInt("GridColumns", 2);
            

            int score = PlayerPrefs.GetInt("PlayerScore", 0); 
            int combo = PlayerPrefs.GetInt("PlayerCombo", 0);

            return new GameInfo() { rows = rows, columns =  columns, score = score, combo = combo };
        }

        public static void SaveGridElements(List<CardView> cardViews)
        {
            var gridElementWrapper = new GridElementWrapper { elements = new() };
            foreach (var cardView in cardViews)
            {
                string cardName = cardView.gameObject.name;
                int spriteIndex = int.Parse(Regex.Replace(cardName, "[^0-9]", ""));
                var newElement = new GridElement() { elementName = cardName, isSpriteRendererEnabled = cardView.SpriteRenderer.enabled, spriteIndex = spriteIndex };

                gridElementWrapper.elements.Add(newElement);
            }

            string json = JsonUtility.ToJson(gridElementWrapper);

            PlayerPrefs.SetString("GridElements", json);
            PlayerPrefs.Save();

            Debug.Log("Grid elements saved: " + json);
        }

        public static List<GridElement> LoadGridElements()
        {
            if (PlayerPrefs.HasKey("GridElements"))
            {
                string json = PlayerPrefs.GetString("GridElements");

                GridElementWrapper wrapper = JsonUtility.FromJson<GridElementWrapper>(json);

                return wrapper.elements;
            }

            return new List<GridElement>();
        }

        public static void LoadGridState(List<CardView> gridGameObjects, MainSceneInstaller.CardType[] sprites, Sprite cardBack)
        {
            var loadedElements = LoadGridElements();

            for (int i = 0; i < loadedElements.Count; i++)
            {
                GridElement element = loadedElements[i];
                CardView gridObject = gridGameObjects[i];

                SpriteRenderer spriteRenderer = gridObject.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = element.isSpriteRendererEnabled;
                gridObject.SpriteRenderer.sprite = cardBack;
                gridObject.CardSprite = sprites[element.spriteIndex].CardSprite;
                gridObject.gameObject.name = element.elementName;
            }
        }

        [System.Serializable]
        private class GridElementWrapper
        {
            public List<GridElement> elements;
        }

        [System.Serializable]
        public class GridElement
        {
            public string elementName;
            public bool isSpriteRendererEnabled;
            public int spriteIndex;
        }

        [System.Serializable]
        public class GameInfo
        {
            public int rows, columns, score, combo;
        }

    }
}