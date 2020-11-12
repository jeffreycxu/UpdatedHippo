﻿using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.U2D;

namespace GoFish
{
    /// <summary>
    /// SetFaceUp(false) clears card's face value
    /// To display a card's value, call SetCardValue(byte) to assign the Rank and the Suit to the card, then call SetFaceUp(true)
    /// </summary>
    public class Card : MonoBehaviour
    {
        public static Ranks GetRank(byte value)
        {
            return (Ranks)(value / 4 + 1);
        }

        public static Suits GetSuit(byte value)
        {
            return (Suits)(value % 4);
        }

        public SpriteAtlas Atlas;

        public Suits Suit = Suits.NoSuits;
        public Ranks Rank = Ranks.NoRanks;

        public string OwnerId;

        //[Serializable]
        public SpriteRenderer spriteRenderer;

        bool faceUp = false;
        bool animalFaceUp = false; //if you want to set the animal profile to be face up 
        //animal
        public byte animalId;

        void Awake()
        {
            //Awake is called when the script instance is being loaded.
            // spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            UpdateSprite();

        }

        public void SetFaceUp(bool value)
        {
            faceUp = value;
            UpdateSprite();

            // Setting faceup to false also resets card's value.
            if (value == false)
            {
                Rank = Ranks.NoRanks;
                Suit = Suits.NoSuits;
            }
        }

        public void SetAnimalFaceUp(bool value)
        {
            animalFaceUp = value;
            UpdateAnimalSprite();

            // Setting faceup to false also resets card's value.
            if (value == false)
            {
                // Rank = Ranks.NoRanks;
                // Suit = Suits.NoSuits;
            }
        }

        public void SetCardValue(byte value)
        {
            // 0-3 are 1's
            // 4-7 are 2's
            // ...
            // 48-51 are kings's
            Rank = (Ranks)(value / 4 + 1);

            // 0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48 are Spades(0)
            Suit = (Suits)(value % 4);
        }

        public void SetAnimalCardValue(byte value)
        {
            animalId = value;
        }

        void UpdateSprite()
        {
            if (faceUp)
            {
                spriteRenderer.sprite = Atlas.GetSprite(SpriteName());
            }
            else
            {
                spriteRenderer.sprite = Atlas.GetSprite(Constants.CARD_BACK_SPRITE);
            }
        }

        void UpdateAnimalSprite()
        {
            Debug.Log(spriteRenderer == null);
            Debug.Log(spriteRenderer);
            if (animalFaceUp)
            {
                spriteRenderer.sprite = Atlas.GetSprite(AnimalSpriteName());
            }
            else
            {
                spriteRenderer.sprite = Atlas.GetSprite(Constants.CARD_BACK_SPRITE);
            }
        }

        string GetRankDescription()
        {
            FieldInfo fieldInfo = Rank.GetType().GetField(Rank.ToString());
            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes[0].Description;
        }

        string SpriteName()
        {
            string testName = $"card{Suit}{GetRankDescription()}";
            return testName;
        }

        string AnimalSpriteName()
        {
            if (animalId == 0) { //from the setanimalcardvalue func
                return "rat";
            }
            else {
                return "boar";
            }
        }

        public void SetDisplayingOrder(int order)
        {
            //spriteRenderer.sortingOrder = order;
        }

        public void OnSelected(bool selected)
        {
            if (selected)
            {
                transform.position = (Vector2)transform.position + Vector2.up * Constants.CARD_SELECTED_OFFSET;
            }
            else
            {
                transform.position = (Vector2)transform.position - Vector2.up * Constants.CARD_SELECTED_OFFSET;
            }
        }
    }
}

