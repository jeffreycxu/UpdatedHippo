using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace GoFish
{
    /// <summary>
    /// SetFaceUp(false) clears card's face value
    /// To display a card's value, call SetCardValue(byte) to assign the Rank and the Suit to the card, then call SetFaceUp(true)
    /// </summary>
    public class AnimalCard : MonoBehaviour
    {

        public SpriteAtlas Atlas;

    
        public string OwnerId;

        //[Serializable]
        public SpriteRenderer spriteRenderer;

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
                        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

                        //spriteRenderer.sprite = Atlas.GetSprite("rat");
            GetComponent<Image>().sprite = Atlas.GetSprite("rat");

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

        public void SetAnimalCardValue(byte value)
        {
            animalId = value;
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

