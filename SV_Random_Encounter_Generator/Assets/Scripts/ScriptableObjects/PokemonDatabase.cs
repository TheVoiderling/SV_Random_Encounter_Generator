using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Objects/Pokemon Database")]
public class PokemonDatabase : ScriptableObject
{
    public List<PokemonData> database;
}
