using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GenerateEncounter : MonoBehaviour
{
    [SerializeField] private PokemonData _currentEncounter;
    [SerializeField] private TextMeshProUGUI _pokemonName;
    [SerializeField] private Image _pokemonSprite, _type1, _type2;
    [SerializeField] private Sprite[] _typeIcons;
    public PokemonDatabase pokemonMasterDatabase, filteredPokemonDatabase;
    public bool isScarletExclusive, isVioletExclusive, isOnlyBaseGame;
    public Toggle legendariesToggle, paradoxToggle, postLaunchToggle;

    private void Start()
    {
        _type1.sprite = _typeIcons[0];
        _type2.sprite = _typeIcons[0];
    }

    public void FindEncounter()
    {
        FilterDatabase();
        _currentEncounter = RandomEncounter();
        ConvertDataToDisplay();
    }

    public void ConvertDataToDisplay()
    {
        _pokemonName.text = _currentEncounter.pokemonName;
        _pokemonSprite.sprite = _currentEncounter.icon;
        _type1.sprite = _typeIcons[(int)_currentEncounter.type1];
        _type2.sprite = _typeIcons[(int)_currentEncounter.type2];
    }

    private void FilterDatabase()
    {
        filteredPokemonDatabase.database = new List<PokemonData>();
        foreach (PokemonData pokemon in pokemonMasterDatabase.database)
        {
            if (!legendariesToggle.isOn)
            {
                if (pokemon.isLegendary)
                {
                    continue;
                }
            }
            if (!paradoxToggle.isOn)
            {
                if (pokemon.isParadox)
                {
                    continue;
                }
            }
            if (postLaunchToggle)
            {
                if (pokemon.isNotInBaseGame)
                {
                    continue;
                }
            }
            filteredPokemonDatabase.database.Add(pokemon);
        }
    }

    public PokemonData RandomEncounter()
    {
        PokemonData output = new PokemonData();
        int max = filteredPokemonDatabase.database.Count - 1;
        output = filteredPokemonDatabase.database[Random.Range(0, max)];
        if(_currentEncounter != null)
        {
            if (output == _currentEncounter)
            {
                return RandomEncounter();
            }
        }
        return output;
    }
}
