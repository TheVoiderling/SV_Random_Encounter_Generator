using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataGenerator
{
    private static string _dataCSVPath = "/Editor/CSVs/Pokemon SV Data - Data.csv";

    [MenuItem("Utilities/Generate Enemies")]
    public static void GenerateDataObjects()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + _dataCSVPath);
        bool firstLineChecked = false;
        foreach(string s in allLines)
        {
            if (!firstLineChecked)
            {
                firstLineChecked = true;
            }
            else
            {
                string[] splitData = s.Split(',');
                if (splitData.Length != 5)
                {
                    Debug.Log(s + " has formatting errors");
                    return;
                }
                PokemonData pokemon = ScriptableObject.CreateInstance<PokemonData>();
                pokemon.pokedexNumber = int.Parse(splitData[0]);
                pokemon.pokemonName = splitData[1];
                pokemon.type1 = ParseTypeNameToEnum(splitData[2]);
                pokemon.type2 = ParseTypeNameToEnum(splitData[3]);
                if (pokemon.type2 == PokemonType.NONE)
                {
                    pokemon.isMonoType = true;
                }
                pokemon.evoChainNumder = int.Parse(splitData[4]);

                AssetDatabase.CreateAsset(pokemon, $"Assets/PokemonData/{pokemon.pokemonName}.asset");
            }
        }
        AssetDatabase.SaveAssets();
    }

    public static PokemonType ParseTypeNameToEnum(string input)
    {
        if (input == "None")
        {
            return PokemonType.NONE;
        }

        if (input == "Bug")
        {
            return PokemonType.BUG;
        }

        if (input == "Dark")
        {
            return PokemonType.DARK;
        }

        if (input == "Electric")
        {
            return PokemonType.ELECTRIC;
        }

        if (input == "Fairy")
        {
            return PokemonType.FAIRY;
        }

        if (input == "Fighting")
        {
            return PokemonType.FIGHTING;
        }

        if (input == "Fire")
        {
            return PokemonType.FIRE;
        }

        if (input == "Flying")
        {
            return PokemonType.FLYING;
        }

        if (input == "Ghost")
        {
            return PokemonType.BUG;
        }

        if (input == "Grass")
        {
            return PokemonType.GRASS;
        }

        if (input == "Ground")
        {
            return PokemonType.GROUND;
        }

        if (input == "Ice")
        {
            return PokemonType.ICE;
        }

        if (input == "Normal")
        {
            return PokemonType.NORMAL;
        }

        if (input == "Poison")
        {
            return PokemonType.POISON;
        }

        if (input == "Psychic")
        {
            return PokemonType.PSYCHIC;
        }

        if (input == "Rock")
        {
            return PokemonType.ROCK;
        }

        if (input == "Steel")
        {
            return PokemonType.STEEL;
        }

        if (input == "Water")
        {
            return PokemonType.WATER;
        }

        return PokemonType.NONE;
    }
}
