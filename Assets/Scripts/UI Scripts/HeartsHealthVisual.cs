using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthVisual : MonoBehaviour
{
    [SerializeField] private Sprite heartFullSprite;
    [SerializeField] private Sprite heartHalfSprite;
    [SerializeField] private Sprite heartEmptySprite;

    private List<HeartImage> heartImageList;
    private HeartsHealthSystem heartsHealthSystem;

    void Awake() {
        heartImageList = new List<HeartImage>();
    }

    // Start is called before the first frame update
    void Start()
    {
        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(3);
        SetHeartsHealthSystem(heartsHealthSystem);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Took damage for 1 point(s).");
            heartsHealthSystem.TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Healed for 1 point(s).");
            heartsHealthSystem.Heal(1);
        }
    }

    public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem) {
        this.heartsHealthSystem = heartsHealthSystem;

        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(0, 0);
        for (int i = 0; i < heartList.Count; i++) {
            HeartsHealthSystem.Heart heart = heartList[i];
            CreateHeartImage(heartAnchoredPosition).SetHeartState(heart.GetStates());
            heartAnchoredPosition += new Vector2(30, 0);
        }
        // Register to the damage event and heal event
        heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
        heartsHealthSystem.OnHealed += HeartsHealthSystem_OnHealed;
    }

    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e) {
        // Health system was damaged
        RefreshAllHearts();
    }

    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e) {
        // Health system was healed
        RefreshAllHearts();
    }

    private void RefreshAllHearts() {
        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        for (int i = 0; i < heartImageList.Count; i++) {
            HeartImage heartImage = heartImageList[i];
            HeartsHealthSystem.Heart heart = heartList[i];
            heartImage.SetHeartState(heart.GetStates());
        }
    }
    
    private HeartImage CreateHeartImage(Vector2 anchoredPosition) {
        // Create heart object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;

        // Location and size of the heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(28, 28); // Adjust heartsize

        // Set the sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartFullSprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;
    }

    // Represemts a single Heart
    public class HeartImage {

        private Image heartImage;
        private HeartsHealthVisual heartsHealthVisual;

        public HeartImage(HeartsHealthVisual heartsHealthVisual, Image heartImage) {
            this.heartsHealthVisual = heartsHealthVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartState(int state) {
            switch (state) {
                case 0: heartImage.sprite = heartsHealthVisual.heartEmptySprite; break; // Empty heart
                case 1: heartImage.sprite = heartsHealthVisual.heartHalfSprite; break;  // Half heart
                case 2: heartImage.sprite = heartsHealthVisual.heartFullSprite; break;  // Full heart
            }
        }
    }
}
