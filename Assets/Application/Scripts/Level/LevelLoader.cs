using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    private SceneInstance currentSceneInstance;

    public static LevelLoader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel (int sceneBuildIndex, Action onLoaded = null, List<AssetReference> prefabReferences = null) 
    {
        string sceneName = sceneBuildIndex.ToString();
        AsyncOperationHandle<SceneInstance> operation = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        operation.Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                currentSceneInstance = handle.Result;

                Debug.Log("Сцена успешно загружена!");

                if(prefabReferences != null)
                {
                    LoadPrefabs(prefabReferences);
                }

                onLoaded?.Invoke();
            }
            else
            {
                Debug.LogError("Ошибка загрузки сцены.");
            }
        };
    }


    void LoadPrefabs(List<AssetReference> prefabReferences)
    {
        foreach (AssetReference prefabReference in prefabReferences)
        {
            prefabReference.LoadAssetAsync<GameObject>().Completed += OnPrefabLoaded;
        }
    }

    void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedPrefab = handle.Result;
            Instantiate(loadedPrefab);
        }
        else
        {
            Debug.LogError("Ошибка загрузки префаба.");
        }
    }

    public void UnloadScene()
    {
        Addressables.UnloadSceneAsync(currentSceneInstance);
    }
}
