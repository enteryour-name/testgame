using KadaXuanwu.UtilityDesigner.Scripts.Execution.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    
    public class ExampleReferences : SceneReferences
    {
        [SerializeField] private List<GameObject> gameObjects;
        [SerializeField] private List<Transform> transforms;

        protected override void RegisterCustomLists()
        {
            AddList(gameObjects);
            AddList(transforms);
        }

    }

