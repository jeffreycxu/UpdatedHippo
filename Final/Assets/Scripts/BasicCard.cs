using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.U2D;

namespace GoFish
{
    /// <summary>
    /// SetFaceUp(false) clears card's face value
    /// To display a card's value, call SetCardValue(byte) to assign the Rank and the Suit to the card, then call SetFaceUp(true)
    /// </summary>
    public class BasicCard : MonoBehaviour
    {
    
        public SpriteAtlas Atlas;


        public string OwnerId;

        //[Serializable]
        public SpriteRenderer spriteRenderer;

        bool faceUp = false;

        //animal
        public byte basicCardID;

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

        }

        public void SetCardValue(byte value)
        {
            basicCardID = value;
        }

        void UpdateSprite()
        {
            Debug.Log(spriteRenderer == null);
            Debug.Log(spriteRenderer);
            if (faceUp)
            {
                spriteRenderer.sprite = Atlas.GetSprite(SpriteName());
            }
            else
            {
                spriteRenderer.sprite = Atlas.GetSprite(Constants.CARD_BACK_SPRITE);
            }
        }

        string SpriteName()
        {
            if (basicCardID == 0) { //from the setanimalcardvalue func
                return "attack";
            }
            else {
                return "defend";
            }

        }


        public void SetDisplayingOrder(int order)
        {
            spriteRenderer.sortingOrder = order;
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

