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
    public PokemonDatabase pokemonMasterDatabase;
    public List<PokemonData> duplicateMasterDatabase,filteredPokemonDatabase;
    public Toggle scarletToggle, violetToggle, legendariesToggle, paradoxToggle, postLaunchToggle;
    public MonotypeManager typeManager;

    private void Start()
    {
        _type1.sprite = _typeIcons[0];
        _type2.sprite = _typeIcons[0];
        duplicateMasterDatabase = pokemonMasterDatabase.database;
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
        filteredPokemonDatabase = new List<PokemonData>();
        foreach (PokemonData pokemon in duplicateMasterDatabase)
        {
            if (!typeManager.isAnyType)
            {
                if (typeManager.isAnyMono)
                {
                    if (!pokemon.isMonoType)
                    {
                        continue;
                    }
                }
                if(pokemon.type1 != typeManager.monoType && pokemon.type2 != typeManager.monoType)
                {
                    continue;
                }
            }

            if (!postLaunchToggle.isOn)
            {
                if (pokemon.isNotInBaseGame)
                {
                    continue;
                }
            }
            if (!scarletToggle.isOn)
            {
                if (pokemon.isScarletExclusive)
                {
                    continue;
                }
            }
            if (!violetToggle.isOn)
            {
                if (pokemon.isVioletExclusive)
                {
                    continue;
                }
            }
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
            filteredPokemonDatabase.Add(pokemon);
        }
    }

    public PokemonData RandomEncounter()
    {
        PokemonData output = new PokemonData();
        int max = filteredPokemonDatabase.Count - 1;
        output = filteredPokemonDatabase[Random.Range(0, max)];
        if (_currentEncounter != null)
        {
            if (output == _currentEncounter)
            {
                return RandomEncounter();
            }
        }
        return output;
    }
}
