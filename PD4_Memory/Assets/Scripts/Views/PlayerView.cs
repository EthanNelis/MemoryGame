using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Memory.Views
{
    public class PlayerView : ViewBaseClass<Player>
    {
        [SerializeField]
        private Text _nameText;

        [SerializeField]
        private Text _scoreText;

        [SerializeField]
        private Text _elapsedText;

        public override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsActivePlayer")
            {
                if (Model.IsActivePlayer)
                {
                    _nameText.fontStyle = FontStyle.Bold;
                    _nameText.color = Color.green;
                }
                else
                {
                    _nameText.fontStyle = FontStyle.Normal;
                    _nameText.color = Color.black;
                }
            }

            if (e.PropertyName == "Score")
            {
                _scoreText.text = "Score: " + Model.Score.ToString();
            }

            if (e.PropertyName == "Elapsed")
            {
                _elapsedText.text = Model.mm + ":" + Model.ss + ":" + Model.ms;
            }

        }
    }
    

}



