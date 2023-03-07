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
    private static int numberOfColloums = 9;

    [MenuItem("Utilities/Generate Pokeomn Data")]
    public static void GenerateDataObjects()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + _dataCSVPath);
        bool firstLineChecked = false;
        PokemonDatabase database = ScriptableObject.CreateInstance<PokemonDatabase>();
        database.database = new List<PokemonData>();
        foreach(string s in allLines)
        {
            if (!firstLineChecked)
            {
                firstLineChecked = true;
            }
            else
            {
                string[] splitData = s.Split(',');
                if (splitData.Length != numberOfColloums)
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
                if(int.Parse(splitData[5]) == 1)
                {
                    pokemon.isScarletExclusive = true;
                }
                if (int.Parse(splitData[5]) == 2)
                {
                    pokemon.isVioletExclusive = true;
                }
                pokemon.isLegendary = ParseBinaryBool(splitData[6]);
                pokemon.isParadox = ParseBinaryBool(splitData[7]);
                pokemon.isNotInBaseGame = ParseBinaryBool(splitData[8]);
                FindIcon(pokemon);
                AssetDatabase.CreateAsset(pokemon, $"Assets/PokemonData/{pokemon.pokemonName}.asset");
                database.database.Add(pokemon);
            }
        }
        AssetDatabase.CreateAsset(database, $"Assets/Database.asset");
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

        if (input == "Dragon")
        {
            return PokemonType.DRAGON;
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
            return PokemonType.GHOST;
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

    public static void FindIcon(PokemonData pokemonData)
    {
        pokemonData.formattedPokedexNumber = pokemonData.pokedexNumber.ToString("0000");
        pokemonData.icon = Resources.Load<Sprite>("Sprites/Big/pm" + pokemonData.formattedPokedexNumber + "_00_00_00_big");
        if (pokemonData.icon == null)
        {
            pokemonData.icon = Resources.Load<Sprite>("Sprites/Big/pm" + pokemonData.formattedPokedexNumber + "_11_00_00_big");
        }
        if (pokemonData.icon == null)
        {
            pokemonData.icon = Resources.Load<Sprite>("Sprites/Big/pm0000_00_00_00_big");
        }
    }

    public static bool ParseBinaryBool(string input)
    {
        if(int.Parse(input) == 1)
        {
            return true;
        }
        return false;
    }
}
