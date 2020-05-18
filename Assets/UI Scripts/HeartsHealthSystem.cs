using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsHealthSystem {

    public const int MAX_HEART_STATE_AMOUNT = 2;

    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private List<Heart> heartList;

    public HeartsHealthSystem(int heartAmount) {
        heartList = new List<Heart>();
        for (int i = 0; i < heartAmount; i++) {
            Heart heart = new Heart(2);
            heartList.Add(heart);
        }
        // DEBUG TEST: MAKES THE LAST HEART EMPTY
        //heartList[heartList.Count-1].SetStates(0);
    }

    public List<Heart> GetHeartList() {
        return heartList;
    }

    public void TakeDamage(int damageAmount) {
        // Cycle through all hearts starting from the end
        for (int i = heartList.Count - 1; i >= 0; i--) {
            Heart heart = heartList[i];
            // Check if the heart fully depletes from damageAmount
            if (damageAmount > heart.GetStates()) {
                // Heart cannot take the hit, empty it and go to the next one
                damageAmount -= heart.GetStates();
                heart.TakeDamage(heart.GetStates());
            } else {
                // Heart can take the hit, absorb and break out of cycle
               heart.TakeDamage(damageAmount);
               break; 
            }
        }
        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);
    }

    public void Heal(int healAmount) {
        for (int i = 0; i < heartList.Count; i++) {
            Heart heart = heartList[i];
            int missingStates = MAX_HEART_STATE_AMOUNT - heart.GetStates();
            if (healAmount > missingStates) {
                healAmount -= missingStates;
                heart.Heal(missingStates);
            } else {
                heart.Heal(healAmount);
                break;
            }
        }
        if (OnHealed != null) OnHealed(this, EventArgs.Empty);
    }

    // Represents a heart
    public class Heart {

        private int state;

        public Heart(int state) {
            this.state = state;
        }

        public int GetStates() {
            return state;
        }

        public void SetStates(int state) {
            this.state = state;
        }

        public void TakeDamage(int damageAmount) {
            if (damageAmount >= state) {
                state = 0;
            } else {
                state -= damageAmount;
            }
        }

        public void Heal(int healAmount) {
            if (state + healAmount > MAX_HEART_STATE_AMOUNT) {
                state = MAX_HEART_STATE_AMOUNT;
            } else {
                state += healAmount;
            }
        }
    }
}
