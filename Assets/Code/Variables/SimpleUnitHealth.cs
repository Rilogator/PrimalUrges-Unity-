// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace RoboRyanTron.Unite2017.Variables
{
    public class SimpleUnitHealth : MonoBehaviour
    {
        public Slider hpMeter;

        public FloatVariable HP;

        public bool ResetHP;

        public FloatReference StartingHP;

        private void Start()
        {
            if (ResetHP)
                HP.SetValue(StartingHP);

            hpMeter.value = HP.Value / StartingHP.Value;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {            
            DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
            if (damage != null)
            {
                HP.ApplyChange(-damage.DamageAmount);
                hpMeter.value = HP.Value / StartingHP.Value;
            }            
        }
    }
}