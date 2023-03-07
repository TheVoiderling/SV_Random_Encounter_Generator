using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonotypeManager : MonoBehaviour
{
    public bool isAnyType, isAnyMono;
    public PokemonType monoType;

    public void ToggleAnyType(Toggle state)
    {
        isAnyType = state.isOn;
        if (isAnyType)
        {
            monoType = PokemonType.NONE;
        }
    }

    public void ToggleAnyMono(Toggle state)
    {
        isAnyMono = state.isOn;
        if (isAnyMono)
        {
            monoType = PokemonType.NONE;
        }
    }

    public void ToggleBug(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.BUG;
        }
    }

    public void ToggleDark(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.DARK;
        }
    }

    public void ToggleDragon(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.DRAGON;
        }
    }

    public void ToggleElectric(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.ELECTRIC;
        }
    }

    public void ToggleFairy(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.FAIRY;
        }
    }

    public void ToggleFighting(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.FIGHTING;
        }
    }

    public void ToggleFire(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.FIRE;
        }
    }

    public void ToggleFlying(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.FLYING;
        }
    }

    public void ToggleGhost(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.GHOST;
        }
    }

    public void ToggleGrass(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.GRASS;
        }
    }

    public void ToggleGround(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.GROUND;
        }
    }

    public void ToggleIce(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.ICE;
        }
    }

    public void ToggleNormal(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.NORMAL;
        }
    }

    public void TogglePoison(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.POISON;
        }
    }

    public void TogglePsychic(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.PSYCHIC;
        }
    }

    public void ToggleRock(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.ROCK;
        }
    }

    public void ToggleSteel(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.STEEL;
        }
    }

    public void ToggleWater(Toggle state)
    {
        if (state.isOn)
        {
            monoType = PokemonType.WATER;
        }
    }
}
