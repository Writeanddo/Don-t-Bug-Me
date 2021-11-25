﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void UnloadSceneAsync(string scene, Action<AsyncOperation> onCompleted)
    {
        var unload = SceneManager.UnloadSceneAsync(scene);

        unload.completed += onCompleted;
    }

    public static void SwitchScene(LevelData currentLevel, LevelData newLevel)
    {
        if (currentLevel)
        {
            SwitchScene(currentLevel.Name, newLevel.Name);
        }
    }

    public static void SwitchScene(string currentScene, string newScene) =>
        UnloadSceneAsync(currentScene, action => SceneManager.LoadScene(newScene, LoadSceneMode.Additive));

    public static void MaybeLoadScene(string scene)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }
}