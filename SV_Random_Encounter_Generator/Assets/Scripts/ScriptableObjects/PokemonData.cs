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
    public int pokedexNumber, evoChainNumder, regionalFormNumber, specialFormNumber;
    public string formattedPokedexNumber, formattedRegionNumber, formattedFormNumber;
    public bool isMonoType;
    public PokemonType type1, type2;
    public bool isScarletExclusive, isVioletExclusive, isLegendary, isParadox, isNotInBaseGame;
    public Sprite icon;
    public string defaulticonPath = "Sprites/Big/pm0000_00_00_00_big", iconPath;
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

        pokemonData.iconPath = pokemonData.defaulticonPath;
        Texture2D iconTexture = Resources.Load<Texture2D>(pokemonData.iconPath);
        Rect iconSection = new Rect();
        iconSection.x = 0;
        iconSection.y = 140;
        iconSection.width = Screen.width / 3;
        iconSection.height = iconSection.width;

        pokemonData.formattedRegionNumber = pokemonData.regionalFormNumber.ToString("00");
        pokemonData.formattedFormNumber = pokemonData.specialFormNumber.ToString("00");

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
            pokemonData.iconPath = "Sprites/Big/pm" + pokemonData.formattedPokedexNumber + "_" + pokemonData.formattedFormNumber + "_" + pokemonData.formattedRegionNumber + "_00_big";
            pokemonData.icon = Resources.Load<Sprite>(pokemonData.iconPath);
            if (pokemonData.icon == null)
            {
                pokemonData.iconPath = pokemonData.defaulticonPath;
                pokemonData.icon = Resources.Load<Sprite>(pokemonData.iconPath);
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
        EditorGUILayout.Separator();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (pokemonData.isScarletExclusive)
        {
            GUILayout.Label("Scarlet Exclusive");
        }
        if (pokemonData.isVioletExclusive)
        {
            GUILayout.Label("Violet Exclusive");
        }
        if (pokemonData.isLegendary)
        {
            GUILayout.Label("Legendary");
        }
        if (pokemonData.isParadox)
        {
            GUILayout.Label("Paradox");
        }
        GUILayout.EndHorizontal();

        if (pokemonData.isNotInBaseGame)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("NOT IN BASE GAME");
            GUILayout.EndHorizontal();
        }

        GUILayout.BeginHorizontal();
        EditorGUILayout.Separator();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUI.DrawTexture(iconSection, pokemonData.icon.texture);
        GUILayout.EndHorizontal();
    }

}
#endif
