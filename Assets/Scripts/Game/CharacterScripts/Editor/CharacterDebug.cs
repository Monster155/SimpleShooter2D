using UnityEditor;
using UnityEngine;

namespace Game.CharacterScripts
{
    [CustomEditor(typeof(Character))]
    public class CharacterDebug : Editor
    {
        private CharacterHealth _characterHealth;
        private int _damage;

        private void OnEnable()
        {
            var character = (Character) target;
            _characterHealth = character.GetCharacterHealth;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("Current HP", _characterHealth.CurrentHP.ToString());
            EditorGUILayout.LabelField("Current Armor", _characterHealth.CurrentArmor.ToString());
            _damage = EditorGUILayout.IntField("Damage", _damage);
            if (GUILayout.Button("Get Damage")) _characterHealth.GetDamage(_damage);

            serializedObject.ApplyModifiedProperties();
        }
    }
}