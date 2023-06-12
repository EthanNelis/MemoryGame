using Memory.Models;
using Memory.Models.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Memory.Views
{
    public class TileView : ViewBaseClass<Tile>, IPointerDownHandler
    {       
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            AddEvents();
        }

        private void AddEvents()
        {
            for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                AnimationClip clip = _animator.runtimeAnimatorController.animationClips[i];
                //Debug.Log(clip.name);

                AnimationEvent animationEndEvent = new AnimationEvent();
                animationEndEvent.time = clip.length;
                animationEndEvent.functionName = "AnimationCompleteHandler";
                animationEndEvent.stringParameter = clip.name;

                clip.AddEvent(animationEndEvent);
            }
        }

        public void AnimationCompleteHandler(string name)
        {
            Model.Board.State.TileAnimationEnded(Model);
        }

        public override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Model.State)))
            {
                StartAnimation();
            }
        }

        private void StartAnimation()
        {
            if (Model.State.State == TileStates.Found)
            {
                _animator.Play("Shown");
            }
            if (Model.State.State == TileStates.Hidden)
            {
                _animator.Play("Hidden");
            }
            if (Model.State.State == TileStates.Preview)
            {
                _animator.Play("Shown");
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Model.Board.State.AddPreview(Model);
        }
    }
}

