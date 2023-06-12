using Memory.Models;
using Memory.Models.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Memory.Views
{
    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
        public PlayerView PlayerView1 { get => GameObject.Find("Player1").GetComponent<PlayerView>(); set { PlayerView1 = value; PlayerView1.Model = this.Model.Player1; } }
        
        public PlayerView PlayerView2 { get => GameObject.Find("Player2").GetComponent<PlayerView>(); set { PlayerView2 = value; PlayerView2.Model = this.Model.Player2; } }

        public void SetUpMemoryBoardView(MemoryBoard model, GameObject tilePrefab, Material[] materials)
        {
            Model = model;
            foreach (Tile tile in Model.Tiles)
            {
                float tileWidth = 0.5f;
                float offsetFactor = 2f;
                float x = (tile.Row - Model.Rows / 2f + tileWidth) * offsetFactor;
                float y = 0f;
                float z = (tile.Column - Model.Columns / 2f + tileWidth) * offsetFactor;

                Vector3 position = new Vector3(x, y, z);
                TileView tileView = Instantiate(tilePrefab, position, tilePrefab.transform.rotation, gameObject.transform).GetComponent<TileView>();
                tileView.Model = tile;
                tileView.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = materials[tile.MemoryCardId];
            }
        }

        public override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "State")
            {
                if(Model.State.State == BoardStates.NoPreview)
                {
                    Model.ToggleActivePlayer();
                }
                if (Model.State.State == BoardStates.TwoFound)
                {
                    if (PlayerView1.Model.IsActivePlayer)
                    {
                        PlayerView1.Model.Score++;
                    }
                    else
                    {
                        PlayerView2.Model.Score++;
                    }
                }
                if (Model.State.State == BoardStates.Finished)
                {
                    PlayerView1.Model.IsActivePlayer = false;
                    PlayerView2.Model.IsActivePlayer = false;
                }


            }

        }

        private void Update()
        {
            PlayerView1.Model.Elapsed += Time.deltaTime;
            PlayerView2.Model.Elapsed += Time.deltaTime;
        }
    }
}
