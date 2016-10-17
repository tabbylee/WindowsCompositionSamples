﻿using Windows.UI;
using Windows.UI.Composition;

namespace CompositionSampleGallery.Samples.SDK_14393.NineGridResizing.NineGridScenarios
{
    sealed internal class MaskNineGridScenario : INineGridScenario
    {
        private readonly CompositionMaskBrush _nineGridMaskBrush;
        private readonly string _text;

        public MaskNineGridScenario(Compositor compositor, CompositionSurfaceBrush surfaceBrush, string text)
        {
            CompositionNineGridBrush brush = compositor.CreateNineGridBrush();
            brush.Source = surfaceBrush;
            brush.SetInsets(60.0f);
            brush.IsCenterHollow = true;

            _nineGridMaskBrush = compositor.CreateMaskBrush();
            _nineGridMaskBrush.Mask = brush;
            _nineGridMaskBrush.Source = compositor.CreateColorBrush(Colors.Black);

            _text = text;
        }

        public CompositionBrush Brush
        {
            get
            {
                return _nineGridMaskBrush;
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
            hostVisual.Brush = _nineGridMaskBrush;
        }
    }
}
