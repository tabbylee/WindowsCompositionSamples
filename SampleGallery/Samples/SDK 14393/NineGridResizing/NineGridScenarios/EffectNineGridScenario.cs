﻿using Microsoft.Graphics.Canvas.Effects;
using Windows.UI.Composition;

namespace CompositionSampleGallery.Samples.SDK_14393.NineGridResizing.NineGridScenarios
{
    sealed internal class EffectNineGridScenario : INineGridScenario
    {
        private readonly CompositionEffectBrush _nineGridEffectBrush;
        private readonly string _text;

        public EffectNineGridScenario(Compositor compositor, CompositionNineGridBrush sourceNineGridBrush, string text)
        {
            var saturationEffect = new SaturationEffect
            {
                Saturation = 0f,
                Source = new CompositionEffectSourceParameter("sourceNineGridBrush"),
            };
            var saturationFactory = compositor.CreateEffectFactory(saturationEffect);
            _nineGridEffectBrush = saturationFactory.CreateBrush();
            _nineGridEffectBrush.SetSourceParameter("sourceNineGridBrush", sourceNineGridBrush); //takes a ninegrid source as input

            _text = text;
        }

        public CompositionBrush Brush
        {
            get
            {
                return _nineGridEffectBrush;
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
        }

        public void Selected(SpriteVisual hostVisual)
        {
            hostVisual.Brush = _nineGridEffectBrush;
        }
    }
}
