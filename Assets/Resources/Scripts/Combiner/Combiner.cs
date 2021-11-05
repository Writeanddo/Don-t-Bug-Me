﻿using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    public List<Recipe> Recipes;

    public void Combine(GameObject componentA, GameObject componentB)
    {
        var recipe = FindRecipe(componentA, componentB);

        if (recipe != null)
        {
            MaybeDestroyGhost(componentA);
            MaybeDestroyGhost(componentB);
            Destroy(componentA);
            Destroy(componentB);

            if (recipe.Result != null)
            {
                recipe.Result.transform.position = componentA.transform.position;
                recipe.Result.SetActive(true);
            }

            recipe.OnCombination.Invoke();
        }
    }

    private Recipe FindRecipe(GameObject ingredientA, GameObject ingredientB) =>
        Recipes.Find(recipe => recipe.ComponentA == ingredientA && recipe.ComponentB == ingredientB || recipe.ComponentB == ingredientA && recipe.ComponentA == ingredientB);

    private void MaybeDestroyGhost(GameObject go)
    {
        var ghost = go.GetComponent<Draggable>()?.Ghost;

        if (ghost != null)
        {
            Destroy(ghost);
        }
    }
}
