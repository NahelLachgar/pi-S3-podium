﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using Model;


namespace UI
{
    internal class K_O
    {
        private List<Sprite> animation_ko = new List<Sprite>();
        private Sprite _KO = new Sprite();
        private float _timerKO = 0;
        private int _iKO = 0;
        private bool _finish = true; 



        internal K_O()
        {

            // Sprite for draw the animation of "K.O" when a player dies
            for ( int i = 1; i <= 38; i++ )
            {
                Texture texture = new Texture("../../../../Ui/Resources/Img/k_o/" + i + ".png");
                texture.Smooth = true;
                Sprite _ko = new Sprite(texture);
                _ko.Scale = new Vector2f(3.072f, 1.728f);
                _ko.Position = new Vector2f(( 1920f / 2f ) - ( _ko.Texture.Size.X / 2f * _ko.Scale.X ), ( 1080f / 2f ) - ( _ko.Texture.Size.Y / 2f * _ko.Scale.Y ));

                animation_ko.Add(_ko);
            }
        }


        internal void AnimationKO(Game game)
        {
            if ( ( game._fighter1.Health == 0 || game._fighter2.Health == 0 ) && _timerKO < game._clock.ElapsedTime.AsSeconds() && _iKO < 38)
            {
                _KO = animation_ko[_iKO];
                _iKO++;
                _timerKO = game._clock.ElapsedTime.AsSeconds() + 0.0400f;
                if ( animation_ko.Count == _iKO )
                {
                    _finish = true;
                    _KO = new Sprite();
                }
                else _finish = false;

                _finish = ( animation_ko.Count == _iKO );
            }

        }

        internal Sprite KO => _KO;

        internal bool Finish => _finish;
    }
}
