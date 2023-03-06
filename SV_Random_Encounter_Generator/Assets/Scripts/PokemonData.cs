using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(menuName = "Custom Objects/Pokemon Data")]
public class PokemonData : ScriptableObject
{
    public string pokemonName;
    public int pokedexNumber, evoChainNumder;
    public string formattedPokedexNumber;
    public bool isMonoType;
    public PokemonType type1, type2;
    public Texture2D icon;
}

#if UNITY_EDITOR
[CustomEditor(typeof(PokemonData))]
class CustomDisplay : Editor
{
    public override void OnInspectorGUI()
    {
        var pokemonData = (PokemonData)target;
        if (pokemonData == null) return;
        Undo.RecordObject(pokemonData, "Change Pokemon Data");

        Texture2D iconTexture = Resources.Load<Texture2D>("Sprites/Big/pm0000_00_00_00_big");
        Rect iconSection = new Rect();
        iconSection.x = 0;
        iconSection.y = 100;
        iconSection.width = Screen.width / 3;
        iconSection.height = iconSection.width;


        GUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        pokemonData.pokemonName = EditorGUILayout.TextField(pokemonData.pokemonName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Pokedex Number: ");
        EditorGUI.BeginChangeCheck();
        pokemonData.pokedexNumber = EditorGUILayout.IntField(pokemonData.pokedexNumber);
        if (EditorGUI.EndChangeCheck())
        {
            pokemonData.formattedPokedexNumber = pokemonData.pokedexNumber.ToString("0000");
            pokemonData.icon = Resources.Load<Texture2D>("Sprites/Big/pm" + pokemonData.formattedPokedexNumber + "_00_00_00_big");
            if(pokemonData.icon == null)
            {
                pokemonData.icon = Resources.Load<Texture2D>("Sprites/Big/pm" + pokemonData.formattedPokedexNumber + "_11_00_00_big");
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Is Mono Type? ");
        pokemonData.isMonoType = EditorGUILayout.Toggle(pokemonData.isMonoType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        pokemonData.type1 = (PokemonType)EditorGUILayout.EnumPopup("Type 1:", pokemonData.type1);
        GUILayout.EndHorizontal();

        if (!pokemonData.isMonoType)
        {
            GUILayout.BeginHorizontal();
            pokemonData.type2 = (PokemonType)EditorGUILayout.EnumPopup("Type 2:", pokemonData.type2);
            GUILayout.EndHorizontal();
        }
        else
        {
            pokemonData.type2 = PokemonType.NONE;
        }

        GUILayout.BeginHorizontal();
        if (pokemonData.icon == null)
        {
            GUI.DrawTexture(iconSection, iconTexture);
        }
        else
        {
            GUI.DrawTexture(iconSection, pokemonData.icon);
        }
        GUILayout.EndHorizontal();
    }
}
#endif
